using Blog.Api.Domain.Contracts.DTOs;

namespace Blog.Api.Infra.Data.Models;

public class AuthorDbModel : DbModel
{
    public string Name { get; set; }
    public string Email { get; set; }

    public static explicit operator AuthorDto(AuthorDbModel model) => new()
    {
        Id = model.Id,
        Name = model.Name,
        Email = model.Email,
        Status = model.Status,
        CreatedAt = model.CreatedAt,
        UpdatedAt = model.UpdatedAt,
    };
}
