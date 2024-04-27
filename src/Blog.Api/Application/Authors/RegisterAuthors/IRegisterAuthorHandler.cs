using FluentResults;

namespace Blog.Api.Application.Authors.RegisterAuthors;

public interface IRegisterAuthorHandler
{
    Task<Result<RegisterAuthorResponse>> HandleAsync(RegisterAuthorRequest request, CancellationToken cancellationToken);
}
