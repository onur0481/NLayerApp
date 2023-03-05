
using System.Linq.Expressions;


namespace NLayer.core.Repositories
{
    public interface IGenericRepositories<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GettAll();
        IQueryable<T> Where(Expression<Func<T,bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
