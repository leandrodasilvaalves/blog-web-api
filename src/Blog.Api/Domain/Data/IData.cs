using Blog.Api.Domain.Contracts.Entities;

namespace Blog.Api.Domain.Data;

public interface IData<TEntity> where TEntity : Entity
{
    Task InsertAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> GetByIdAsync(string id, CancellationToken cancellationToken);
}