using System.Linq.Expressions;

namespace MallorCarApplication.Common.Interfaces;

public interface IRepository<T>
{
    Task<T?> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = new());

    Task<T> GetSingleWithIncludesAsync(
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = new(), 
        params Expression<Func<T, object>>[] includes);
    
    Task<IList<T>> GetManyAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken = new());
    
    Task<IList<T>> GetManyWithIncludesAsync(
        Expression<Func<T, bool>> filter, 
        CancellationToken cancellationToken = new(), 
        params Expression<Func<T, object>>[] includes);
    
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
}