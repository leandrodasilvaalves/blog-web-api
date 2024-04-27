using Blog.Api.Domain.Contracts.Entities;
using Blog.Api.Domain.Contracts.Requests;

namespace Blog.Api.Domain.Entities;

public class Author : Entity
{
    public string Name { get; private set; }
    public string Email { get; private set; }

    public void Create(IRegisterAuthorRequest request)
    {
        NewId();
        Name = request.Name;
        Email = request.Email;
        CreatedAt = DateTime.UtcNow;
        Status = Contracts.Enums.Status.ACTIVE;
    }
}