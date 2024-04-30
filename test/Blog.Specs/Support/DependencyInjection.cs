using Blog.Api.Infra.Data.Context.Mongo;

using Microsoft.Extensions.DependencyInjection;

using SolidToken.SpecFlow.DependencyInjection;

namespace Blog.Specs.Support;

public static class DependencyInjection
{
    [ScenarioDependencies]
    public static IServiceCollection CreateServices()
    {
        var services = new ServiceCollection();

        var mongoConfig = new MongoConfig
        {
            ConnectionString = "mongodb://rootuser:rootpassword@localhost:27017",
            DatabaseName = "blog"
        };
        services.AddSingleton(mongoConfig);
        services.AddSingleton(typeof(IMongoDbContext<>), typeof(MongoDbContext<>));

        return services;
    }
}