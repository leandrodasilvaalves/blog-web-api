using Blog.Api.Domain.Contracts.Requests;

namespace Blog.Api.Application.Authors.RegisterAuthors;

public class RegisterAuthorRequest : IRegisterAuthorRequest
{
    public string Name { get; set; }
    public string Email { get; set; }
}