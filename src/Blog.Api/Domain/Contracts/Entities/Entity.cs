using Blog.Api.Domain.Contracts.Enums;

namespace Blog.Api.Domain.Contracts.Entities;

public class Entity
{
    public string Id { get; private set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public Status Status { get; protected set; }

    public void NewId() => Id = $"{Guid.NewGuid()}";
}
