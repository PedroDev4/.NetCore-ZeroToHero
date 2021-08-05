using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Pagination
{
    public class PagedList<T> : List<T>    { // Classe genérica
    
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool hasPrevious => CurrentPage > 1; // Prop com valor definido
        public bool hasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int totalItems, int pageNumber, int pageSize) { // Constructor
        
            TotalCount = totalItems;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(totalItems / (double) pageSize);
            
            AddRange(items);
        }
        
        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize) {

            var count = source.Count();

            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedList<T>(items, count, pageNumber ,pageSize);

        }

    }
}