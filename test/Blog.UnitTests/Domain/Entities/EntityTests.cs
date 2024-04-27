using AutoFixture;
using AutoFixture.Xunit2;

using Blog.UnitTests.Fixtures.Fakers;

using FluentAssertions;

using FluentResults;

namespace Blog.UnitTests.Domain.Entities;

public class EntityTests
{
    [Theory]
    [AutoData]
    public void ShouldAddError(FakeEntity sut, IFixture fixture)
    {
        var error = fixture.Create<Error>();
        sut.AddFakeError(error);

        sut.HasError().Should().BeTrue();
        sut.Errors.Should().Contain(error);
    }

    [Theory]
    [AutoData]
    public void ShouldNotAddErrorWhenIsNull(FakeEntity sut)
    {
        sut.AddFakeError(null);
        sut.HasError().Should().BeFalse();
    }


    [Theory]
    [AutoData]
    public void ShouldAddManyErrors(FakeEntity sut, IFixture fixture)
    {
        var errors = fixture.CreateMany<Error>();
        sut.AddFakeErrors(errors);

        sut.HasError().Should().BeTrue();
        errors.ToList().ForEach(e => sut.Errors.Should().Contain(e));
    }

    [Theory]
    [AutoData]
    public void ShouldNotAddErrorWhenCollectionIsEmpty(FakeEntity sut)
    {
        sut.AddFakeErrors([]);
        sut.HasError().Should().BeFalse();
    }

    [Theory]
    [AutoData]
    public void ShouldCleanErrors(FakeEntity sut, IFixture fixture)
    {
        var errors = fixture.CreateMany<Error>();
        sut.AddFakeErrors(errors);

        sut.ClearFakeErrors();

        sut.HasError().Should().BeFalse();
    }
}