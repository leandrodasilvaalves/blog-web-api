using Blog.Api.Domain.Contracts.DTOs;
using Blog.Api.Domain.Entities;
using Blog.Api.Infra.Data.Models;

namespace Blog.Api.Infra.Mappers;

public class AuthorMappers : IMapper<Author, AuthorDbModel>
{
    public Author ToEntity(AuthorDbModel model)
    {
        var dto = (AuthorDto)model;
        return new Author(dto);
    }

    public AuthorDbModel ToModel(Author entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Email = entity.Email,
        CreatedAt = entity.CreatedAt,
        Status = entity.Status,
        UpdatedAt = entity.UpdatedAt,
    };
}