using Blog.Specs.Docker;

using Ductus.FluentDocker.Services;

using TechTalk.SpecFlow;

namespace Blog.Specs.Hooks;

[Binding]
public class ContainersHooks
{
    private static ICompositeService Containers { get; set; }

    [BeforeTestRun]
    public static void BeforeAllTests()
    {
        Containers = new Ductus.FluentDocker.Builders.Builder()
                            .UseContainer()
                            .UseCompose()
                            .FromFile(DockerCompose.GetFiles())
                            .ForceBuild()
                            .RemoveOrphans()
                            .WaitForHttp("api", "http://localhost:5326/swagger")
                            .Build()
                            .Start();
    }

    [AfterTestRun]
    public static void AfterAllTests()
    {
        Containers.Dispose();
    }
}