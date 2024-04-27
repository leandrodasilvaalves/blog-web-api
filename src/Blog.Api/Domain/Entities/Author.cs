using System.ComponentModel.DataAnnotations;

using Blog.Api.Domain.Contracts.Entities;
using Blog.Api.Domain.Contracts.Requests;

namespace Blog.Api.Domain.Entities;

public class Author : Entity
{
    [Required]
    [Length(2, 20)]
    public string Name { get; private set; }

    [Required]
    [EmailAddress]
    [MaxLength(150)]
    public string Email { get; private set; }

    public void Create(IRegisterAuthorRequest request)
    {
        NewId();
        Name = request.Name;
        Email = request.Email;
        CreatedAt = DateTime.UtcNow;
        Status = Contracts.Enums.Status.ACTIVE;
        Validate();
    }
}