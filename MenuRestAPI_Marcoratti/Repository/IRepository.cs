using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Repository
{
    public interface IRepository<T> {

        IQueryable<T> Get();   // T significa algo genérico (Algo qualquer)

        T GetById(Expression<Func<T, bool>> predicate);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
