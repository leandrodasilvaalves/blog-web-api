using Blog.Api.Application.Authors.RegisterAuthors;

namespace Blog.Api.Application.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection self)
    {
        self.AddScoped<IRegisterAuthorHandler, RegisterAuthorHandler>();
        return self;
    }
}
