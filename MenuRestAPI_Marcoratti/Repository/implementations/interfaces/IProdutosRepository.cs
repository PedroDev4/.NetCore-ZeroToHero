using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuRestAPI_Marcoratti.Models;
using MenuRestAPI_Marcoratti.Pagination;

namespace MenuRestAPI_Marcoratti.Repository.implementations.interfaces
{
    public interface IProdutosRepository : IRepository<Product>
    {
        PagedList<Product> GetProducts(ProductsParameters productsParameters);
        IEnumerable<Product> GetProductsByPrice();

    }
}
