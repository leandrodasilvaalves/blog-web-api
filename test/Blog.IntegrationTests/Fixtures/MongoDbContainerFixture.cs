using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;

namespace Blog.IntegrationTests.Fixtures;

public class MongoDbContainerFixture : IDisposable
{
    public const string User = "testuser";
    public const string Pass = "testpass";
    public const int HostPort = 27018;

    public MongoDbContainerFixture()
    {
        string[] env = [
            $"MONGO_INITDB_ROOT_USERNAME={User}",
            $"MONGO_INITDB_ROOT_PASSWORD={Pass}"
        ];

        Container = new Builder().UseContainer()
            .UseImage("mongo")
            .ExposePort(HostPort, 27017)
            .WithEnvironment(env)
            .Build()
            .Start();
    }

    private IContainerService Container { get; }

    public void Dispose() => Container.Dispose();
}
