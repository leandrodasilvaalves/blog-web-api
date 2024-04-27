using Blog.Api.Domain.Contracts.Requests;
using Blog.Api.Domain.Contracts.Services;
using Blog.Api.Domain.Entities;

using FluentResults;

namespace Blog.Api.Domain.Services;

public class AuthorServices : IAuthorServices
{
    public Task<Result<Author>> RegisterAsync(IRegisterAuthorRequest request, CancellationToken cancellationToken)
    {
        var author = new Author();
        author.Create(request);

        return Task.FromResult(Result.Ok(author));
    }
}
