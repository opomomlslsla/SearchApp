using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repositories;

internal abstract class BaseRepository<TEntity>(Context context) : IRepository<TEntity> where TEntity : BaseEntity
{
    public virtual async Task<ICollection<TEntity>> GetAllAsync()
    {
        return await context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<ICollection<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await context.Set<TEntity>().Where(predicate).ToListAsync();
    }
}
