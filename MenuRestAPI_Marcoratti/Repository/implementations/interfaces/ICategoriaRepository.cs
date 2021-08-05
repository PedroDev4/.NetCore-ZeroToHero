using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MenuRestAPI_Marcoratti.Pagination;
using MenuRestAPI_Marcoratti.Models;

namespace MenuRestAPI_Marcoratti.Repository.implementations.interfaces
{
    public interface ICategoriaRepository : IRepository<Category> // Inteface vai ter os metodos da interface herdada
    {
        IEnumerable<Category> GetCategoriasProdutos();
        PagedList<Category> GetCategoriesPagination(CategoriesParameters categoriesParameters);

    }
}
