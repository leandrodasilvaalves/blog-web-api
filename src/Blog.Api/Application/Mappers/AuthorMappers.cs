using Blog.Api.Application.Authors.RegisterAuthors;
using Blog.Api.Domain.Entities;

namespace Blog.Api.Application.Mappers;

public class AuthorMappers
{
    public static RegisterAuthorResponse MapFrom(Author author) => new()
    {
        Id = author.Id,
        Name = author.Name,
        Email = author.Email,
        CreatedAt = author.CreatedAt,
    };
}