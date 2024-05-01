using Blog.Api.Domain.Contracts.DTOs;
using Blog.Api.Domain.Entities;

namespace Blog.Api.Infra.Data.Models;

public class AuthorDbModel : DbModel, IEquatable<Author>
{
    public string Name { get; set; }
    public string Email { get; set; }

    public override int GetHashCode() => Id.GetHashCode();

    public override bool Equals(object obj)
    {
        if (obj is Author author)
        {
            return Equals(author);
        }
        return base.Equals(obj);
    }

    public bool Equals(Author other)
    {
        return Name == other.Name && Email == other.Email;
    }

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
