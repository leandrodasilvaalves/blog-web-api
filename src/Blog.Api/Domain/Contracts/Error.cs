using FluentResults;

namespace Blog.Api.Domain.Contracts;

public class Error(string message) : IError
{
    public List<IError> Reasons => [];

    public string Message { get; } = message;

    public Dictionary<string, object> Metadata => [];
}