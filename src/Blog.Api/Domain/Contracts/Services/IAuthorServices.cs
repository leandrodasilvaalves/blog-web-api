using Blog.Api.Domain.Contracts.Requests;
using Blog.Api.Domain.Entities;

using FluentResults;

namespace Blog.Api.Domain.Contracts.Services;

public interface IAuthorServices
{
    Task<Result<Author>> RegisterAsync(IRegisterAuthorRequest request, CancellationToken cancellationToken);
}