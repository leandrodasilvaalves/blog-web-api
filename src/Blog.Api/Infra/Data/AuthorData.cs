using Blog.Api.Domain.Data;
using Blog.Api.Domain.Entities;
using Blog.Api.Infra.Data.Context.Mongo;
using Blog.Api.Infra.Data.Models;
using Blog.Api.Infra.Mappers;

namespace Blog.Api.Infra.Data;

public class AuthorData : DbData<Author, AuthorDbModel>, IAuthorData
{
    public AuthorData(IMongoDbContext<AuthorDbModel> context,
        IMapper<Author, AuthorDbModel> mapper) : base(context, mapper) { }
}