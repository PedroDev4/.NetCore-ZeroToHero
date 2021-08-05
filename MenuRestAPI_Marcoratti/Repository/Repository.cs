using MenuRestAPI_Marcoratti.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;

        public Repository(AppDbContext context) {

            this._dbContext = context;
        }
        
        public IQueryable<T> Get() { 
       
            return _dbContext.Set<T>().AsNoTracking();
        }

        public T GetById(Expression<Func<T, bool>> predicate) {

            return _dbContext.Set<T>().SingleOrDefault(predicate);
        }

        public T GetFirst() {
            return _dbContext.Set<T>().FirstOrDefault();
        }

        public void Add(T entity) {

            _dbContext.Set<T>().Add(entity);
        }

        public void Update(T entity) {

            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity) {

            _dbContext.Set<T>().Remove(entity);
        }
    }
}
