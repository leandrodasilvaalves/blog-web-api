using Blog.Api.Domain.Contracts.Entities;
using Blog.Api.Infra.Data.Models;

namespace Blog.Api.Infra.Mappers;

public interface IMapper<TEntity, TModel>
    where TEntity : Entity 
    where TModel : DbModel
{
    TModel ToModel(TEntity entity);
    TEntity ToEntity(TModel model);
}
