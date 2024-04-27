using AutoFixture;
using AutoFixture.Xunit2;

using Blog.UnitTests.Fixtures.Customizations.Application;
using Blog.UnitTests.Fixtures.Customizations.Domain.Entities;
using Blog.UnitTests.Fixtures.Customizations.Domain.Services;

namespace Blog.UnitTests.Fixtures.Attributes;

public class AuthorsAutoDataAttribute : AutoDataAttribute
{
    public AuthorsAutoDataAttribute() : base(() => Factory()) { }

    private static Fixture Factory()
    {
        var fixture = new Fixture();

        fixture.Behaviors
            .OfType<ThrowingRecursionBehavior>().ToList()
            .ForEach(b => fixture.Behaviors.Remove(b));
        fixture.Behaviors.Add(new OmitOnRecursionBehavior());

        fixture.Customize(new AuthorCustomizations());
        fixture.Customize(new AuthorServicesCustomizations());
        fixture.Customize(new AuthorHandlersCustomizations());
        return fixture;
    }
}
