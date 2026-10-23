namespace Snackis1.API.DTO
{
    public class PostDto
    {
        public string Title { get; set; } = "";

        public string Content { get; set; } = "";

        public string Author { get; set; } = "";

        public string UserId { get; set; } = "";

        public string? ProfileImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<CommentDto> Comments { get; set; } = new();


        // För brödsmulenavigeringen 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
        public string ForumTitle { get; set; } = "";

    }
}
