using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyShop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected ShoppingContext _context;
        protected DbSet<T> table = null;

        public GenericRepository(ShoppingContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }
        public virtual void Delete(int id)
        {
            T existing = table.Find(id);
           table.Remove(existing);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }
        public async Task <IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null, 
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);
            if (orderBy != null)
                query = orderBy(query);
            return await query.ToListAsync();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);
            if (orderBy != null)
                query = orderBy(query);
            return query.ToList();
        }

        public async Task<T> GetByIDAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public virtual T Add(T obj)
        {
            table.Add(obj);
            return obj;
        }

        public void save()
        {
            _context.SaveChanges();
        }

        public virtual T Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            return obj;
        }
        
        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await table.Where(filter).ToListAsync();
        }
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return  table.Where(filter).ToList();
        }


    }
}
