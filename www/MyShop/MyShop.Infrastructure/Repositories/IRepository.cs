using System.Linq.Expressions;

namespace MyShop.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);
        Task<T> GetByIDAsync(int id);
        T Add(T obj);
        void Delete(int id);
        T Update(T obj);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter);
        void save();



        //Added by me
        IEnumerable<T> All();
        IEnumerable<T> Find(Expression<Func<T, bool>> filter);
    }
}
