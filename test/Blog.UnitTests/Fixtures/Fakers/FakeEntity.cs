using Blog.Api.Domain.Contracts.Entities;

using FluentResults;

namespace Blog.UnitTests.Fixtures.Fakers;

public class FakeEntity : Entity
{
    public void AddFakeError(IError? error) => AddError(error);
    public void AddFakeErrors(IEnumerable<IError> errors) => AddErrors(errors);
    public void ClearFakeErrors() => ClearErrors();
}