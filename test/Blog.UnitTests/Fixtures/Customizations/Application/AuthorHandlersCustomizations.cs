using AutoFixture;

using Blog.Api.Application.Authors.RegisterAuthors;
using Blog.Api.Domain.Contracts.Services;

using FluentResults;

using NSubstitute;

namespace Blog.UnitTests.Fixtures.Customizations.Application;

public class AuthorHandlersCustomizations : ICustomization
{
    public void Customize(IFixture fixture)
    {
        fixture.Register(() => Substitute.For<IError>());
        fixture.Register(() => new RegisterAuthorHandler(fixture.Create<IAuthorServices>()));
    }
}