using Blog.Api.Domain.Contracts.DTOs;
using Blog.Api.Domain.Entities;
using Blog.Api.Infra.Data.Models;

namespace Blog.Api.Infra.Mappers;

public class AuthorMapper : IMapper<Author, AuthorDbModel>
{
    public Author Map(AuthorDbModel source) =>
        source is null ? default : new Author((AuthorDto)source);

    public AuthorDbModel Map(Author source) =>
        source is null ? default : new()
        {
            Id = source.Id,
            Name = source.Name,
            Email = source.Email,
            CreatedAt = source.CreatedAt,
            Status = source.Status,
            UpdatedAt = source.UpdatedAt,
        };
}
