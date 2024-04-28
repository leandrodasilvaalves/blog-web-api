using Blog.Specs.Docker;

using TechTalk.SpecFlow;

namespace Blog.Specs.Hooks;

[Binding]
public class ContainersHooks
{
    [BeforeTestRun]
    public static void BeforeAllTests() => DockerCompose.Up();

    [AfterTestRun]
    public static void AfterAllTests() => DockerCompose.Down();
}