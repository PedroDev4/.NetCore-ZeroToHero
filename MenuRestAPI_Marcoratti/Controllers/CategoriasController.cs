using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MenuRestAPI_Marcoratti.Models;
using MenuRestAPI_Marcoratti.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MenuRestAPI_Marcoratti.DTOs;
using AutoMapper;
using MenuRestAPI_Marcoratti.Repository;
using MenuRestAPI_Marcoratti.Pagination;
using Newtonsoft.Json;

namespace MenuRestAPI_Marcoratti.Controllers
{
    [ApiController]
    [Route("/api/[Controller]")]
    public class CategoriasController : ControllerBase
    {

        private readonly IUnitOfWork _uof;
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public CategoriasController(IUnitOfWork dbcontext, IConfiguration configuration, ILogger<CategoriasController> logger, IMapper mapper) {
        
            this._uof = dbcontext; // Depedency Inversion & Injection
            this._config = configuration;
            this._logger = logger;
            this._mapper = mapper;
            
        }

        [HttpGet("autor")]
        public ActionResult<string> getAutor() {

            var autor = this._config["autor"];
            var connection = this._config["ConnectionStrings:DefaultConnection"];
            return $"Autor: {autor} // {connection}"; // Lendo valores de arquivo JSON, da IConfiguration
        }


        [HttpGet("relations")]
        public ActionResult<IEnumerable<CategoryReturnDTO>> GetCategoriesProducts() {

            _logger.LogInformation("============ GET api/categorias/relations ============");

            // Método "Include" inclui os os products na busca de categorias
            var categoriesProducts = this._uof.CategoriaRepository.GetCategoriasProdutos().ToList();

            var categoriesProductsDTO = this._mapper.Map<List<CategoryReturnDTO>>(categoriesProducts);

            return categoriesProductsDTO;
            
        }

        [HttpGet("hello/{name}")]
        public ActionResult<string> GetHello([FromServices] IMyService myService, string name) {
            // throw new Exception("error");

            return myService.hello(name);
        }


        [HttpGet]            // Tipo de Retorno
        public ActionResult<IEnumerable<CategoryReturnDTO>> GetAll([FromQuery] CategoriesParameters categoriesParameters){
            try {

                var categories = this._uof.CategoriaRepository.GetCategoriesPagination(categoriesParameters);
                var categoriesDTO = this._mapper.Map<List<CategoryReturnDTO>>(categories);

                 var metadata = new {
                    categories.TotalCount,
                    categories.PageSize,
                    categories.CurrentPage,
                    categories.TotalPages,
                    categories.hasNext,
                    categories.hasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return categoriesDTO;

            } catch (Exception){
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged in database access");
            }
                
        }

        [HttpGet("{id}", Name = "ObterCategory")]
        public ActionResult<CategoryReturnDTO> GetById (int id) {
            try {

                var category = this._uof.CategoriaRepository.GetById(product => product.id == id); // Condição de busca

                _logger.LogInformation($"============ GET api/categorias/id = {category.id} ============");

                if (category == null) {
                    _logger.LogInformation($"============ GET api/categorias/id = NOTFOUND ============");

                    return NotFound($"Category with id: {id} was not found");
                }

                var categoryDTO = this._mapper.Map<CategoryReturnDTO>(category);

                return categoryDTO;
            
            } catch (Exception) {
            
                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged in database access");
            }

        }

        [HttpPost]
        public ActionResult<CategoryReturnDTO> Post ([FromBody] CategoryReturnDTO categoryDTO) {
            try {

                var category = this._mapper.Map<Category>(categoryDTO);

                if (!ModelState.IsValid) {
                
                    return BadRequest(ModelState);
                }

                this._uof.CategoriaRepository.Add(category);
                this._uof.Commit();

                categoryDTO = this._mapper.Map<CategoryReturnDTO>(category);

                return new CreatedAtRouteResult("ObterCategory", new { id = categoryDTO.id }, categoryDTO);

            } catch (Exception){

                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged trying to create a new category");
            }
            
        }

        [HttpPut("{id}")]
        public ActionResult<CategoryReturnDTO> Put (int id, [FromBody] CategoryReturnDTO categoryDTO) {

            try {

                var category = this._mapper.Map<Category>(categoryDTO);

                if (!ModelState.IsValid) {
                
                    return BadRequest(ModelState);
                }

                if (id != category.id) {
                
                    return BadRequest($"The provided id: {id}, does not match with Req.body id: {category.id} ");
                }

                this._uof.CategoriaRepository.Update(category); // Indicando o estado da entidade para alterado
                this._uof.Commit();
                
                categoryDTO = this._mapper.Map<CategoryReturnDTO>(category);

                return Ok(categoryDTO);

            } catch (Exception) {

                return StatusCode(StatusCodes.Status500InternalServerError, "An error has surged trying to update category");
            }
           
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (int id) {
        
            try {
                // var product = this._context.products.FirstOrDefault(product => product.id == id);

                var category =  this._uof.CategoriaRepository.GetById(product => product.id == id); // Find usado somente para buscas por chave primarias

                if (category == null)
                {
                    return NotFound("Category was not found");
                }

                this._uof.CategoriaRepository.Delete(category);
                this._uof.Commit();

                return Ok($"Category with id: {id} was succesifully deleted");
            } catch (Exception) {
            
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao tentar remover uma categoria");
            }
            
        }

    }
}
