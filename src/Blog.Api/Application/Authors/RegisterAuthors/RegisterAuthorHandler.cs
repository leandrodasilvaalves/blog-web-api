using Blog.Api.Application.Mappers;
using Blog.Api.Domain.Contracts.Services;

using FluentResults;

namespace Blog.Api.Application.Authors.RegisterAuthors;

public class RegisterAuthorHandler : IRegisterAuthorHandler
{
    private readonly IAuthorServices _authorServices;

    public RegisterAuthorHandler(IAuthorServices authorServices)
    {
        _authorServices = authorServices ?? throw new ArgumentNullException(nameof(authorServices));
    }

    public async Task<Result<RegisterAuthorResponse>> HandleAsync(RegisterAuthorRequest request, CancellationToken cancellationToken)
    {
        var result = await _authorServices.RegisterAsync(request, cancellationToken);

        return result.IsSuccess ?
            Result.Ok(AuthorMappers.MapFrom(result.Value)) :
            Result.Fail(result.Errors);
    }
}