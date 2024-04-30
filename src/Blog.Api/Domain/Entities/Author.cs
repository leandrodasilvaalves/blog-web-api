using System.ComponentModel.DataAnnotations;

using Blog.Api.Domain.Contracts.DTOs;
using Blog.Api.Domain.Contracts.Entities;
using Blog.Api.Domain.Contracts.Enums;
using Blog.Api.Domain.Contracts.Requests;

namespace Blog.Api.Domain.Entities;

public class Author : Entity
{
    public Author() { }
    public Author(AuthorDto dto)
    {
        Id = dto.Id;
        Name = dto.Name;
        Email = dto.Email;
        Status = dto.Status;
        CreatedAt = dto.CreatedAt;
        UpdatedAt = dto.UpdatedAt;
        Validate();
    }

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
        UpdatedAt = CreatedAt;
        Status = Status.ACTIVE;
        Validate();
    }
}