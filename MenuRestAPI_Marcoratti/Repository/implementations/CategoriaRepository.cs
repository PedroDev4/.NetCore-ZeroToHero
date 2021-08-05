using MenuRestAPI_Marcoratti.Context;
using MenuRestAPI_Marcoratti.Models;
using MenuRestAPI_Marcoratti.Pagination;
using MenuRestAPI_Marcoratti.Repository.implementations.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Repository.implementations
{
    public class CategoriaRepository : Repository<Category>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context) {
            
        }

        public IEnumerable<Category> GetCategoriasProdutos() {
        
            return Get().Include(data => data.Products);
        }

        public PagedList<Category> GetCategoriesPagination(CategoriesParameters categoriesParameters)
        {
            return PagedList<Category>.ToPagedList(Get().OrderBy(properties => properties.id), categoriesParameters.PageNumber, categoriesParameters.PageSize);
        }
    }
}
