using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WineCode.DAL
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        void Insert(T obj);
        void Delete(int id);
        void Update(T obj);
        //IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>,
        //                                            IOrderedQueryable<T>> orderBy = null,
        //                                            params Expression<Func<T, object>>[] includes);
        public IEnumerable<T> Get(
    Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
    List<Expression<Func<T, object>>> includes = null,
    List<Func<IQueryable<T>, IQueryable<T>>> thenIncludes = null);
    }
}
