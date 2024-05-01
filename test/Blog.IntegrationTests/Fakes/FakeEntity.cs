using Blog.Api.Domain.Contracts.Entities;

namespace Blog.IntegrationTests.Fakes;

public class FakeEntity : Entity, IEquatable<FakeModel>
{
    public FakeEntity() => Id = $"{Guid.NewGuid()}";

    public FakeEntity(string id) { Id = id; }

    public string Foo { get; set; }
    public string Bar { get; set; }

    public override int GetHashCode() => Id.GetHashCode();

    public override bool Equals(object obj) =>
        obj is FakeModel fakeModel && Equals(fakeModel);

    public bool Equals(FakeModel other) =>
        Id == other.Id && Foo == other.Foo && Bar == other.Bar;
}