using System.ComponentModel.DataAnnotations;

using Blog.Api.Application.Authors.RegisterAuthors;
using Blog.Api.Domain.Contracts.DTOs;
using Blog.Api.Domain.Entities;
using Blog.UnitTests.Fixtures.Attributes;

using FluentAssertions;

namespace Blog.UnitTests.Domain.Entities;

public class AuthorTests
{
    [Theory]
    [AutoInlineData("")]
    [AutoInlineData(DataType.Text, 1)]
    [AutoInlineData(DataType.Text, 21)]
    public void ShouldHaveErrorWhenAuthorNameIsInvalid(string name, Author sut, RegisterAuthorRequest request)
    {
        request.Name = name;
        sut.Create(request);
        sut.HasError().Should().BeTrue();
    }

    [Theory]
    [AutoInlineData(DataType.Text, 10)]
    [AutoInlineData(DataType.EmailAddress, 151)]
    public void ShouldHaveErrorWhenAuthorEmailIsInvalid(string email, Author sut, RegisterAuthorRequest request)
    {
        request.Email = email;
        sut.Create(request);
        sut.HasError().Should().BeTrue();
    }

    [Theory]
    [AutoInlineData]
    public void ShouldNotHaveErrorWhenAutorObjectIsValid(Author sut, RegisterAuthorRequest request)
    {
        sut.Create(request);
        sut.HasError().Should().BeFalse();
    }

    [Theory]
    [AuthorsAutoData]
    public void ShouldCreateAnAuthorEntityFromAuthorDto(AuthorDto dto)
    {
        var author = new Author(dto);

        author.Id.Should().Be(dto.Id);
        author.Name.Should().Be(dto.Name);
        author.Email.Should().Be(dto.Email);
        author.Status.Should().Be(dto.Status);
        author.CreatedAt.Should().Be(dto.CreatedAt);
        author.UpdatedAt.Should().Be(dto.UpdatedAt);
    }
}