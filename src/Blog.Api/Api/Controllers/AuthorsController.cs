using Blog.Api.Application.Authors.RegisterAuthors;

using Microsoft.AspNetCore.Mvc;

namespace Blog.Api.Api.Controllers
{
    [ApiController]
    [Route("api/v1/authors")]
    public class AuthorsController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] RegisterAuthorRequest request, [FromServices] IRegisterAuthorHandler handler)
        {
            var response = await handler.HandleAsync(request, HttpContext.RequestAborted);
            return response.IsSuccess ? Created(string.Empty, response.Value) : UnprocessableEntity(response.Errors);
        }
    }
}