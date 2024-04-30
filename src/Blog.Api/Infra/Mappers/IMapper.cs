using Blog.Api.Domain.Contracts.Entities;
using Blog.Api.Infra.Data.Models;

namespace Blog.Api.Infra.Mappers;

public interface IMapper<TEntity, TModel>
    where TEntity : Entity 
    where TModel : DbModel
{
    TModel Map(TEntity entity);
    TEntity Map(TModel model);
}
