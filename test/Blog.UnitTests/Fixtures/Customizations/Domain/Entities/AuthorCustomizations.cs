using AutoFixture;

using Blog.Api.Application.Authors.RegisterAuthors;
using Blog.Api.Domain.Entities;

namespace Blog.UnitTests.Fixtures.Customizations.Domain.Entities;

public class AuthorCustomizations : ICustomization
{
    public void Customize(IFixture fixture)
    {
        var author = fixture.Create<Author>();
        var request = fixture.Create<RegisterAuthorRequest>();
        author.Create(request);

        fixture.Register(() => author);
    }
}