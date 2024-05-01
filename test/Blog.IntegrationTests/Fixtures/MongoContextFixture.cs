using Blog.Api.Domain.Contracts.Entities;
using Blog.Api.Infra.Data.Context.Mongo;
using Blog.IntegrationTests.Fakes;

namespace Blog.IntegrationTests.Fixtures;

public class MongoContextFixture
{
    public MongoContextFixture()
    {
        var connectionString =
            string.Format("mongodb://{0}:{1}@localhost:{2}",
                MongoDbContainerFixture.User,
                MongoDbContainerFixture.Pass,
                MongoDbContainerFixture.HostPort);

        var mongoConfig = new MongoConfig
        {
            ConnectionString = connectionString,
            DatabaseName = "blog"
        };

        Context = new MongoDbContext<FakeModel>(mongoConfig);
    }

    public IMongoDbContext<FakeModel> Context { get; }
}

[CollectionDefinition("MongoDb")]
public class MongoDbCollection :
    ICollectionFixture<MongoDbContainerFixture>,
    ICollectionFixture<MongoContextFixture>,
    ICollectionFixture<DataFixture>

{ }

[Collection("MongoDb")]
public class BaseMongoTests { }