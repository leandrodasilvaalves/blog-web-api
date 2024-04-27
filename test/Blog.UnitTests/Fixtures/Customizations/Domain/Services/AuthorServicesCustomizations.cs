using AutoFixture;

using Blog.Api.Domain.Contracts.Requests;
using Blog.Api.Domain.Contracts.Services;
using Blog.Api.Domain.Entities;

using FluentResults;

using NSubstitute;

namespace Blog.UnitTests.Fixtures.Customizations.Domain.Services;

public class AuthorServicesCustomizations : ICustomization
{
    public void Customize(IFixture fixture)
    {
        var authorServices = Substitute.For<IAuthorServices>();
        authorServices.RegisterAsync(Arg.Any<IRegisterAuthorRequest>(), Arg.Any<CancellationToken>())
            .Returns(Result.Ok(fixture.Create<Author>()));

        fixture.Register(() => authorServices);
    }
}