using AutoFixture;

using Blog.Api.Application.Authors.RegisterAuthors;
using Blog.Api.Domain.Entities;

using Bogus;

namespace Blog.UnitTests.Fixtures.Customizations.Domain.Entities;

public class AuthorCustomizations : ICustomization
{
    public void Customize(IFixture fixture)
    {

        var request = new Faker<RegisterAuthorRequest>()
            .RuleFor(e => e.Name, f => f.Person.FullName)
            .RuleFor(e => e.Email, f => f.Person.Email.ToLower())
            .Generate();

        var author = fixture.Create<Author>();
        author.Create(request);

        fixture.Register(() => request);
        fixture.Register(() => author);
    }
}