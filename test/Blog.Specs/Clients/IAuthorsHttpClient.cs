using Blog.Api.Application.Authors.RegisterAuthors;

using Refit;

namespace Blog.Specs.Clients
{
    public interface IAuthorsHttpClient
    {
        [Post("/authors")]
        Task<ApiResponse<RegisterAuthorResponse>> RegisterAsync([Body] RegisterAuthorRequest request);
    }
}