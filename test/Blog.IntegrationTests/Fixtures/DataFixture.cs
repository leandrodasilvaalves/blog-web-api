using Blog.Api.Infra.Data;
using Blog.Api.Infra.Mappers;
using Blog.IntegrationTests.Fakes;

using NSubstitute;

namespace Blog.IntegrationTests.Fixtures;

public class DataFixture
{
    private readonly IMapper<FakeEntity, FakeModel> _mapper;
    public DataFixture()
    {
        _mapper = Substitute.For<IMapper<FakeEntity, FakeModel>>();
        ConfigureMap();
        Data = new(new MongoContextFixture().Context, _mapper);
    }

    public DbData<FakeEntity, FakeModel> Data { get; }

    private void ConfigureMap()
    {
        _mapper
            .Map(Arg.Any<FakeEntity>())
            .Returns(x =>
            new FakeModel
            {
                Id = x.Arg<FakeEntity>().Id,
                Foo = x.Arg<FakeEntity>().Foo,
                Bar = x.Arg<FakeEntity>().Bar
            });

        _mapper
            .Map(Arg.Any<FakeModel>())
            .Returns(x =>
            new FakeEntity(x.Arg<FakeModel>().Id)
            {
                Foo = x.Arg<FakeModel>().Foo,
                Bar = x.Arg<FakeModel>().Bar
            });
    }
}