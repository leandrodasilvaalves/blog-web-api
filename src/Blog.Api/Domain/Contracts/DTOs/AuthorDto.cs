using Blog.Api.Domain.Contracts.Enums;

namespace Blog.Api.Domain.Contracts.DTOs
{
    public class AuthorDto
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Status Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}