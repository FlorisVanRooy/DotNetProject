using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WineCode.Data;

namespace WineCode.DAL
{
    public class GenericRepository<T> : IRepository<T> where T:class
    {
        private WineContext _context;
        private DbSet<T> _table;

        public GenericRepository(WineContext context) { 
            _context = context;
            _table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetByID(int id)
        {
            return _table.Find(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Delete(int id)
        {
            T existing = _table.Find(id);
            if (existing != null)
            {
                _table.Remove(existing);
            }
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        // Get methode om een specifieke lijst aan objecten terug te geven (met includes)
        // zie winescontroller voor gebruik
        //public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        //{
        //    IQueryable<T> query = _table;

        //    foreach (Expression<Func<T, object>> include in includes)
        //    {
        //        query = query.Include(include);
        //    }

        //    if (filter != null)
        //        query = query.Where(filter);

        //    if (orderBy != null)
        //        query = orderBy(query);

        //    return query.ToList();
        //}

        public IEnumerable<T> Get(
    Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
    List<Expression<Func<T, object>>> includes = null,
    List<Func<IQueryable<T>, IQueryable<T>>> thenIncludes = null)  // Add a list for ThenIncludes
        {
            IQueryable<T> query = _table;

            // Apply Includes
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Apply ThenIncludes
            if (thenIncludes != null)
            {
                foreach (var thenInclude in thenIncludes)
                {
                    query = thenInclude(query);
                }
            }

            // Apply filter
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Apply ordering
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query.ToList();
        }




    }
}
