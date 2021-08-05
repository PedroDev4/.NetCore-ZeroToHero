using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuRestAPI_Marcoratti.Context;
using MenuRestAPI_Marcoratti.Repository.implementations.interfaces;
using MenuRestAPI_Marcoratti.Models;
using MenuRestAPI_Marcoratti.Pagination;

namespace MenuRestAPI_Marcoratti.Repository.implementations
{
    public class ProdutoRepository : Repository<Product>, IProdutosRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context) {
            // Constructor apenas pega o db Context da classe base
        }

        public PagedList<Product> GetProducts(ProductsParameters productsParameters) {
       
            /* return Get().OrderBy(properties => properties.name).Skip((productsParameters.PageNumber - 1) * productsParameters.PageSize)
            .Take(productsParameters.PageSize).ToList(); */

            return PagedList<Product>.ToPagedList(Get().OrderBy(properties => properties.category_id), productsParameters.PageNumber, productsParameters.PageSize);
        }

        public IEnumerable<Product> GetProductsByPrice() {
        
            return Get().OrderBy(product => product.price).ToList();
        }
    }
}
