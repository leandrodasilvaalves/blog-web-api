using System.ComponentModel.DataAnnotations;

using Blog.Api.Domain.Contracts.Entities;

using FluentResults;

namespace Blog.UnitTests.Fixtures.Fakers;

public class FakeEntity : Entity
{
    public FakeEntity()
    {
        NewId();
        Foo = "Bar";
    }

    [Required]
    public string Foo { get; set; }

    public void AddFakeError(IError? error) => AddError(error);
    public void AddFakeErrors(IEnumerable<IError> errors) => AddErrors(errors);
    public void ClearFakeErrors() => ClearErrors();
    public void FakeValidate() => Validate();
}