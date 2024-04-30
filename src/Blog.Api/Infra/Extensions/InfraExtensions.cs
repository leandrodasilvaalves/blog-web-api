using Blog.Api.Domain.Data;
using Blog.Api.Domain.Entities;
using Blog.Api.Infra.Data;
using Blog.Api.Infra.Data.Context.Mongo;
using Blog.Api.Infra.Data.Models;
using Blog.Api.Infra.Mappers;

using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Blog.Api.Infra.Extensions;

public static class InfraExtensions
{
    public static IServiceCollection AddInfra(this IServiceCollection self, IConfiguration config)
    {
        self.AddData();
        self.AddMongo(config);
        self.AddMappers();
        return self;
    }

    private static IServiceCollection AddData(this IServiceCollection self)
    {
        self.AddSingleton<IAuthorData, AuthorData>();
        return self;
    }

    private static IServiceCollection AddMappers(this IServiceCollection self)
    {
        self.AddSingleton<IMapper<Author, AuthorDbModel>, AuthorMapper>();
        return self;
    }

    public static IServiceCollection AddMongo(this IServiceCollection self, IConfiguration config)
    {
        var options = new MongoConfig();
        config.GetSection(MongoConfig.SectionName).Bind(options);

        self.AddSingleton(options);
        self.AddSingleton(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));
        return self;
    }
}