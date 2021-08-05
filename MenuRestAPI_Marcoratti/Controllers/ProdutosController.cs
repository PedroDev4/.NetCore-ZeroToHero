using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MenuRestAPI_Marcoratti.Context;
using MenuRestAPI_Marcoratti.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MenuRestAPI_Marcoratti.Filters;
using MenuRestAPI_Marcoratti.Repository;
using AutoMapper;
using MenuRestAPI_Marcoratti.DTOs;
using MenuRestAPI_Marcoratti.Pagination;
using Newtonsoft.Json;

namespace MenuRestAPI_Marcoratti.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IMapper _mapper;

        public ProdutosController(IUnitOfWork dbcontext, IMapper mapper)
        {
            this._uof = dbcontext; // Depedency Inversion
            this._mapper = mapper;
        }

        
        [HttpGet]            // Tipo de Retorno
        [ServiceFilter(typeof(ApiLoggingFilter))] // Apllying filter on Action
        public ActionResult<IEnumerable<ProductReturnDTO>> GetAll ([FromQuery] ProductsParameters productsParameters) {

            try {

                var products = this._uof.ProdutosRepository.GetProducts(productsParameters);

                var metadata = new {
                    products.TotalCount,
                    products.PageSize,
                    products.CurrentPage,
                    products.TotalPages,
                    products.hasNext,
                    products.hasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                var productsReturnDTO = this._mapper.Map<List<ProductReturnDTO>>(products);
                // Mapear dados do MODEL para uma LIST de DTOS

                return productsReturnDTO;

            } catch (Exception) {
     
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged in database access");       
            }
            
        }

        [HttpGet("order/price")]
        public ActionResult<IEnumerable<ProductReturnDTO>> GetByPrice() {

            var products =  this._uof.ProdutosRepository.GetProductsByPrice().ToList();
            var productsDTO = this._mapper.Map<List<ProductReturnDTO>>(products); 

            return productsDTO;
            // Mapper vai passar os dados do model consultado para DTO, assim retornamos o DTO
        }

        [HttpGet("first")]
        // [HttpGet("test/{value:alpha}")] Método Action consegue atender 1+ endpoints do mesmo tipo & restrição de apenas valores alphanúmericos 
        public ActionResult<ProductReturnDTO> GetFirst() {

            try {

                var firstProduct = this._uof.ProdutosRepository.Get().FirstOrDefault();
                

                if (firstProduct == null) { 
                    return NotFound("Could not find any product");
                }

                var firstProductDTO = this._mapper.Map<ProductReturnDTO>(firstProduct);

                return Ok(firstProductDTO);

            } catch (Exception) {
            
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged in database access");
            }
        
        }

        // * Recebendo + Route params -> "{id}/{param2}". Route param não obrigatório -> "{id}/{param2?}"
        // * Definir um valor padrão para o Route param -> "{id}/{param2=Node}"
        [HttpGet("{id:int}", Name = "ObterProdutor")] 
        public ActionResult<ProductReturnDTO> GetById(int id) {  // [BindRequired][FromQuery]string name

            try {

                var product = this._uof.ProdutosRepository.GetById(product => product.id == id); // Condição de busca
               
                if (product == null) {
              
                    return NotFound($"The product with id: {id} was not found ");
                }
                                                 // PARA QUAL DTO   // DE QUAL FONTE DE DADOS
                var productDTO = this._mapper.Map<ProductReturnDTO>(product);

                return Ok(productDTO);

            } catch (Exception) {
            
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged in database access");
            }
           
        }

        [HttpPost]
        public ActionResult<ProductReturnDTO> Post([FromBody] ProductReturnDTO productDTO) {

            try {

                var product = _mapper.Map<Product>(productDTO);

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                 this._uof.ProdutosRepository.Add(product);
                 this._uof.Commit();

                productDTO = _mapper.Map<ProductReturnDTO>(product);

                return new CreatedAtRouteResult("ObterProdutor", new { id = productDTO.id }, productDTO);

            } catch (Exception) {
            
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged trying to create a new product");
            }

        }

        [HttpPut("{id}")]
        public ActionResult<ProductReturnDTO> Put (int id, [FromBody]ProductReturnDTO productDTO) {

            try {
            
                if (!ModelState.IsValid) {
                
                    return BadRequest(ModelState);
                }

                if (id != productDTO.id) {
                    
                    return BadRequest($"The provided id: {id}, does not match with Req.body id: {productDTO.id} ");
                }

                var product = _mapper.Map<Product>(productDTO);
                productDTO = _mapper.Map<ProductReturnDTO>(product);

                this._uof.ProdutosRepository.Update(product); // Indicando o estado da entidade para alterado
                this._uof.Commit();

                return Ok(productDTO);

            } catch (Exception) {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged trying to update product");
            }
           
        }

        [HttpDelete("{id}")]
        public ActionResult<ProductReturnDTO> DeleteAsync (int id) {

            try {

                // var product = this._context.products.FirstOrDefault(product => product.id == id);
                var product = this._uof.ProdutosRepository.GetById(produto => produto.id == id);

                if (product == null)
                {
                    return NotFound($"Product with id: {id} was not found");
                }

                this._uof.ProdutosRepository.Delete(product);
                this._uof.Commit();

                var productDTO = _mapper.Map<ProductReturnDTO>(product);

                return Ok(productDTO);

            } catch (Exception) {
           
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged trying to delete product");
            }

        }

    }
}
