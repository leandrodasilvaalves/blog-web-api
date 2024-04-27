using Blog.Api.Application.Mappers;
using Blog.Api.Domain.Entities;
using Blog.UnitTests.Fixtures.Attributes;

using FluentAssertions;

namespace Blog.UnitTests.Application.Mappers;

public class AuthorMappersTests
{
    [Theory]
    [AuthorsAutoData]
    public void ShouldMappAuthorEntityToRegisterAuthorResponse(Author author)
    {
        var response = AuthorMappers.MapFrom(author);

        response.Id.Should().Be(author.Id);
        response.Name.Should().Be(author.Name);
        response.Email.Should().Be(author.Email);
        response.CreatedAt.Should().Be(author.CreatedAt);
    }
}