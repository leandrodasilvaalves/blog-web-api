using Blog.Api.Application.Authors.RegisterAuthors;

using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Api.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorsController : ControllerBase
    {
        [HttpPost]
        public Task<IActionResult> PostAsync([FromBody] RegisterAuthorRequest request)
        {
            var response = new RegisterAuthorResponse
            {
                Id = $"{Guid.NewGuid()}",
                Name = request.Name,
                Email = request.Email,
                CreatedAt = DateTime.UtcNow,
            };
            return Task.FromResult<IActionResult>(Created(string.Empty, response));
        }
    }
}