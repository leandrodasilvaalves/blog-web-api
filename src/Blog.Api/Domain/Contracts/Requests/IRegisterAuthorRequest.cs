namespace Blog.Api.Domain.Contracts.Requests;

public interface IRegisterAuthorRequest
{
    string Name { get; }
    string Email { get; }
}
