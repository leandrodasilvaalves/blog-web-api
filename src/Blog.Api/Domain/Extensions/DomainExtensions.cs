using Blog.Api.Domain.Contracts.Services;
using Blog.Api.Domain.Services;

namespace Blog.Api.Domain.Extensions;

public static class DomainExtensions
{
    public static IServiceCollection AddDomain(this IServiceCollection self)
    {
        self.AddScoped<IAuthorServices, AuthorServices>();
        return self;
    }
}