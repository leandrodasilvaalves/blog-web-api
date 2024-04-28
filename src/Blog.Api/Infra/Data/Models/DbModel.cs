using Blog.Api.Domain.Contracts.Enums;

namespace Blog.Api.Infra.Data.Models;

public abstract class DbModel
{
    public string Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Status Status { get; set; }
}