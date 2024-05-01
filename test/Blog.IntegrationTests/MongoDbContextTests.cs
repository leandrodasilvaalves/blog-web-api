using AutoFixture.Xunit2;

using Blog.Api.Infra.Data;
using Blog.Api.Infra.Data.Context.Mongo;
using Blog.IntegrationTests.Fakes;
using Blog.IntegrationTests.Fixtures;

using FluentAssertions;

using MongoDB.Driver;

namespace Blog.IntegrationTests;

public class MongoDbContextTests : BaseMongoTests
{
    private readonly IMongoDbContext<FakeModel> _mongo;
    private readonly DbData<FakeEntity, FakeModel> _sut;

    public MongoDbContextTests(MongoContextFixture mongoFixture, DataFixture dataFixture)
    {
        _mongo = mongoFixture.Context;
        _sut = dataFixture.Data;
    }

    [Theory]
    [AutoData]
    public async Task ShouldInsertDataIntoMongodbAsync(FakeEntity entity)
    {
        await _sut.InsertAsync(entity, CancellationToken.None);

        var model = await _mongo.Collection.Find(x => x.Id == entity.Id).FirstOrDefaultAsync();

        model.Should().NotBeNull();
        model.Should().Be(entity);
    }

    [Theory]
    [AutoData]
    public async Task ShouldGetDataInMongoFromEntityId(FakeModel model)
    {
        await _mongo.Collection.InsertOneAsync(model);

        var entity = await _sut.GetByIdAsync(model.Id, CancellationToken.None);

        entity.Should().NotBeNull();
        entity.Should().Be(model);
    }

    [Theory]
    [AutoData]
    public async Task ShouldGetOneRecordFromMongoWhenExists(FakeModel model)
    {
        await _mongo.Collection.InsertOneAsync(model);

        var entity = await _sut.GetOneAsync(x => x.Foo == model.Foo, CancellationToken.None);

        entity.Should().NotBeNull();
        entity.Should().Be(model);
    }
}