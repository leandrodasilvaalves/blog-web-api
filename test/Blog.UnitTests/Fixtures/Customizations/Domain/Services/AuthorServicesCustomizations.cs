using AutoFixture;

using Blog.Api.Domain.Contracts.Requests;
using Blog.Api.Domain.Contracts.Services;
using Blog.Api.Domain.Data;
using Blog.Api.Domain.Entities;
using Blog.Api.Domain.Services;

using FluentResults;

using NSubstitute;

namespace Blog.UnitTests.Fixtures.Customizations.Domain.Services;

public class AuthorServicesCustomizations : ICustomization
{
    public void Customize(IFixture fixture)
    {
        var authorServiceSubstitute = Substitute.For<IAuthorServices>();
        authorServiceSubstitute.RegisterAsync(Arg.Any<IRegisterAuthorRequest>(), Arg.Any<CancellationToken>())
            .Returns(Result.Ok(fixture.Create<Author>()));

        fixture.Register(() => authorServiceSubstitute);

        var authorDataSubstitute = Substitute.For<IAuthorData>();
        fixture.Register(() => authorDataSubstitute);
        fixture.Register(() => new AuthorServices(authorDataSubstitute));
    }
}