using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

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

    [Required]
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

    protected void Validate()
    {
        var validationResults = new List<ValidationResult>();
        var result = Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);
        if (result is false)
        {
            var errors = validationResults.Select(e => new Error(e.ErrorMessage));
            AddErrors(errors);
        }
    }
}