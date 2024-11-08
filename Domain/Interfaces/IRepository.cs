using Domain.Entities;
using System.Linq.Expressions;

namespace Domain.Interfaces;

public interface IRepository<TEntity> where TEntity :  BaseEntity
{
    Task<ICollection<TEntity>> GetAllAsync();
    Task<ICollection<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> predicate);
}
