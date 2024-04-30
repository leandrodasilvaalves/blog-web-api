using System.Linq.Expressions;

using Blog.Api.Domain.Contracts.Requests;
using Blog.Api.Domain.Contracts.Services;
using Blog.Api.Domain.Data;
using Blog.Api.Domain.Entities;

using FluentResults;

namespace Blog.Api.Domain.Services;

public class AuthorServices : IAuthorServices
{
    private readonly IAuthorData _authorData;

    public AuthorServices(IAuthorData authorData)
    {
        _authorData = authorData ?? throw new ArgumentNullException(nameof(authorData));
    }

    public async Task<Result<Author>> RegisterAsync(IRegisterAuthorRequest request, CancellationToken cancellationToken)
    {
        Expression<Func<Author, bool>> predicate = x => x.Name == request.Name || x.Email == request.Email;
        var existsAuthor = await _authorData.GetOneAsync(predicate, cancellationToken);
        if (existsAuthor is { })
        {
            return Result.Fail<Author>(new Error("Already exists an author with this name or e-mail."));
        }

        var author = new Author();
        author.Create(request);

        if (author.HasError())
        {
            return Result.Fail<Author>(author.Errors);
        }
        await _authorData.InsertAsync(author, cancellationToken);
        return Result.Ok(author);
    }
}
