using System.Linq.Expressions;
using MallorCarApplication.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MallorCar.Infrastructure.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSet<T> _table;

    public Repository(DbContext dbContext)
    {
        _table = dbContext.Set<T>();
    }
    
    public async Task<T?> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = new())
    {
        var source = await _table.SingleOrDefaultAsync(predicate, cancellationToken);

        return source;
    }

    public async Task<T> GetSingleWithIncludesAsync(
        Expression<Func<T, bool>> filter,
        CancellationToken cancellationToken = new(),
        params Expression<Func<T, object>>[] includes
    )
    {
        var custom = _table.AsQueryable();
        
        return await includes.Aggregate(custom, (current, includeProperty) 
            => current.Include(includeProperty)).SingleAsync(filter, cancellationToken);
    }
    public async Task<IList<T>> GetManyAsync(Expression<Func<T, bool>>? filter, CancellationToken cancellationToken = new())
    {
        var filteredResult = filter != null ? _table.Where(filter) : _table.AsQueryable();

        return await filteredResult.ToListAsync(cancellationToken);
    }

    public async Task<IList<T>> GetManyWithIncludesAsync(
        Expression<Func<T, bool>>? filter,
        CancellationToken cancellationToken,
        params Expression<Func<T, object>>[] includes
    )
    {
        var custom = filter != null ? _table.Where(filter) : _table.AsQueryable();
        
        return await includes.Aggregate(custom, (current, includeProperty) 
            => current.Include(includeProperty)).ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _table.AddAsync(entity, cancellationToken);
    }
}