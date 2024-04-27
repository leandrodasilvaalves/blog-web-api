using System.Collections.ObjectModel;

using Blog.Api.Domain.Contracts.Enums;

using FluentResults;

namespace Blog.Api.Domain.Contracts.Entities;

public abstract class Entity
{
    protected Entity()
    {
        Errors = new(_errors);
    }

    private readonly List<IError> _errors = [];
    public string Id { get; private set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime UpdatedAt { get; protected set; }
    public Status Status { get; protected set; }
    public ReadOnlyCollection<IError> Errors { get; }

    public void NewId() => Id = $"{Guid.NewGuid()}";

    public bool HasError() => _errors.Count > 0;

    protected void AddError(IError error)
    {
        if (error is { })
        {
            _errors.Add(error);
        }
    }

    protected void AddErrors(IEnumerable<IError> errors)
    {
        if (errors.Any())
        {
            _errors.AddRange(errors);
        }
    }

    protected void ClearErrors() => _errors.Clear();
}