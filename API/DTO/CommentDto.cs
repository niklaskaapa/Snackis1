namespace Snackis1.API.DTO
{
    public class CommentDto
    {
        public string Content { get; set; } = "";
        public string Author { get; set; } = "";

        public string UserId { get; set; } = "";

        public string? ProfileImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
