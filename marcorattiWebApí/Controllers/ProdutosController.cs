using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using marcorattiWebApí.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using marcorattiWebApí.Context;


namespace marcorattiWebApí.Controllers {
    
    [ApiController]
    [Route("api/[Controller]")]
    public class ProdutosController : ControllerBase {
        
        private readonly AppDbContext _context;

        public ProdutosController (AppDbContext context) {  
	        
            this._context = context; // Depedency Inversion

	    }
    
        [HttpGet]           // Tipo de retorno
        public ActionResult<IEnumerable<Product>> Get() { 
        
            return this._context.products.AsNoTracking().ToList();
        
        }

        [HttpGet("{id}",Name="ObterProduto"),]
        public ActionResult<Product> GetById(int id) { 
        
            var product =  this._context.products.AsNoTracking().FirstOrDefault(product => product.id == id); // Condição de busca

            if(product == null) { 
            
                return NotFound();

            }

            return product;

        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody]Product product) { 
        
            if(!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            this._context.products.Add(product);
            this._context.SaveChanges();

            return new CreatedAtRouteResult("ObterProduto", new { id = product.id }, product);

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]Product product) {
        
            if(!ModelState.IsValid) { 
                return BadRequest(ModelState);
            }

            if(id != product.id) { 
                
                return BadRequest();
            
            }

            this._context.Entry(product).State = EntityState.Modified; // Indicando o estado da entidade para alterado
            this._context.SaveChanges();

            return Ok();
        
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id) { 
        
            // var product = this._context.products.FirstOrDefault(product => product.id == id);
            var product = this._context.products.Find(id); // Find usado somente para busca por chave primaria da table

            if(product == null) { 
                return NotFound();  
            }

            this._context.products.Remove(product);
            this._context.SaveChanges();

            return Ok();

        }
    
    }

} 