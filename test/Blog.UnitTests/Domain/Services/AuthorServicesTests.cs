using System.Linq.Expressions;

using Blog.Api.Application.Authors.RegisterAuthors;
using Blog.Api.Domain.Data;
using Blog.Api.Domain.Entities;
using Blog.Api.Domain.Services;
using Blog.UnitTests.Fixtures.Attributes;

using FluentAssertions;

using NSubstitute;

namespace Blog.UnitTests.Domain.Services;

public class AuthorServicesTests
{
    [Theory]
    [AuthorsAutoData]
    public async Task ShouldNotCreateAnAuthorWhenEntityIsValidAsync(AuthorServices sut, RegisterAuthorRequest request, IAuthorData authorData)
    {
        request.Name = "";

        var result = await sut.RegisterAsync(request, CancellationToken.None);

        result.IsFailed.Should().BeTrue();
        await authorData.Received().GetOneAsync(Arg.Any<Expression<Func<Author, bool>>>(), Arg.Any<CancellationToken>());
        await authorData.DidNotReceive().InsertAsync(Arg.Any<Author>(), Arg.Any<CancellationToken>());

    }

    [Theory]
    [AuthorsAutoData]
    public async Task ShouldNotCreateAnAuthorWhenEmailOrNameAlreadyExists(AuthorServices sut, RegisterAuthorRequest request, Author author, IAuthorData authorData)
    {
        authorData.GetOneAsync(Arg.Any<Expression<Func<Author, bool>>>(), Arg.Any<CancellationToken>())
            .Returns(author);

        var result = await sut.RegisterAsync(request, CancellationToken.None);

        result.IsFailed.Should().BeTrue();
        await authorData.Received().GetOneAsync(Arg.Any<Expression<Func<Author, bool>>>(), Arg.Any<CancellationToken>());
        await authorData.DidNotReceive().InsertAsync(Arg.Any<Author>(), Arg.Any<CancellationToken>());
    }

    [Theory]
    [AuthorsAutoData]
    public async Task ShouldCreateAnAuthorWhenEntityValidAsync(AuthorServices sut, RegisterAuthorRequest request, IAuthorData authorData)
    {
        var result = await sut.RegisterAsync(request, CancellationToken.None);

        result.IsSuccess.Should().BeTrue();
        await authorData.Received().GetOneAsync(Arg.Any<Expression<Func<Author, bool>>>(), Arg.Any<CancellationToken>());
        await authorData.Received().InsertAsync(Arg.Any<Author>(), Arg.Any<CancellationToken>());
    }
}