using Blog.Api.Application.Extensions;
using Blog.Api.Domain.Extensions;

namespace Blog.Api.Api.Extensions;

public static class ApiExtensions
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection self)
    {
        self.AddApplication();
        self.AddDomain();
        return self;
    }
}
