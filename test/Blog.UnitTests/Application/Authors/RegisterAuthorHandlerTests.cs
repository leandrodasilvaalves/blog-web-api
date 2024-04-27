using AutoFixture;

using Blog.Api.Application.Authors.RegisterAuthors;
using Blog.Api.Domain.Contracts.Requests;
using Blog.Api.Domain.Contracts.Services;
using Blog.UnitTests.Fixtures.Attributes;

using FluentAssertions;

using FluentResults;

using NSubstitute;

namespace Blog.UnitTests.Application.Authors;

public class RegisterAuthorHandlerTests
{
    [Theory]
    [AuthorsAutoData]
    public async Task ShouldFailWhenDomainServiceReturnsError(RegisterAuthorHandler sut,
                                                              RegisterAuthorRequest request,
                                                              IAuthorServices domainService,
                                                              IFixture fixture)
    {
        domainService
            .RegisterAsync(Arg.Any<IRegisterAuthorRequest>(), Arg.Any<CancellationToken>())
            .Returns(Result.Fail(fixture.CreateMany<IError>()));

        var result = await sut.HandleAsync(request, CancellationToken.None);

        result.IsFailed.Should().BeTrue();
        await domainService.Received().RegisterAsync(Arg.Any<IRegisterAuthorRequest>(), Arg.Any<CancellationToken>());
    }

    [Theory]
    [AuthorsAutoData]
    public async Task ShouldBeSuccessWhenDomainServicesReturnSuccess(RegisterAuthorHandler sut,
                                                                     RegisterAuthorRequest request,
                                                                     IAuthorServices domainService)
    {
        var result = await sut.HandleAsync(request, CancellationToken.None);
    
        result.IsSuccess.Should().BeTrue();
        await domainService.Received().RegisterAsync(Arg.Any<IRegisterAuthorRequest>(), Arg.Any<CancellationToken>());
    }
}
