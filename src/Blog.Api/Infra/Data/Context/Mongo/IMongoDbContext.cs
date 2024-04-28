using MongoDB.Driver;

namespace Blog.Api.Infra.Data.Context.Mongo;

public interface IMongoDbContext<T> where T : class
{
    IMongoCollection<T> Collection { get; }
}
