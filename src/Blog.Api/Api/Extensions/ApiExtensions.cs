using Blog.Api.Application.Extensions;
using Blog.Api.Domain.Extensions;
using Blog.Api.Infra.Extensions;

namespace Blog.Api.Api.Extensions;

public static class ApiExtensions
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection self, IConfiguration config)
    {
        self.AddApplication();
        self.AddDomain();
        self.AddInfra(config);
        return self;
    }
}
