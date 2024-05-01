using Blog.Api.Domain.Entities;
using Blog.Api.Infra.Data.Models;
using Blog.Api.Infra.Mappers;
using Blog.UnitTests.Fixtures.Attributes;

using FluentAssertions;

namespace Blog.UnitTests.Infra.Mappers
{
    public class AuthorMapperTests
    {
        [Theory]
        [AuthorsAutoData]
        public void ShouldMapEntityToDbModel(AuthorMapper sut, Author entity)
        {
            var model = sut.Map(entity);
            model.Should().Be(entity);
        }

        [Theory]
        [AuthorsAutoData]
        public void ShouldNotMapWhenEntityIsNull(AuthorMapper sut)
        {
            Author? entity = null;
            var model = sut.Map(entity);
            model.Should().BeNull();
        }

        [Theory]
        [AuthorsAutoData]
        public void ShouldMapDbModelToEntity(AuthorMapper sut, AuthorDbModel model)
        {
            var entity = sut.Map(model);
            model.Should().Be(entity);
        }

        [Theory]
        [AuthorsAutoData]
        public void ShouldNotMapWhenDbModelIsNull(AuthorMapper sut)
        {
            AuthorDbModel? model = null;
            var entity = sut.Map(model);
            entity.Should().BeNull();
        }
    }
}