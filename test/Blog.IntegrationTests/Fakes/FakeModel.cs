using Blog.Api.Infra.Data.Models;

namespace Blog.IntegrationTests.Fakes;

public class FakeModel : DbModel, IEquatable<FakeEntity>
{
    public string Foo { get; set; }
    public string Bar { get; set; }

    public override int GetHashCode() => Id.GetHashCode();

    public override bool Equals(object obj) =>
        obj is FakeEntity fakeEntity && Equals(fakeEntity);

    public bool Equals(FakeEntity other) =>
        Id == other.Id && Foo == other.Foo && Bar == other.Bar;
}
