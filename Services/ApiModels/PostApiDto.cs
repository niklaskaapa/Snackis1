namespace Snackis1.Services.ApiModels
{
    public class PostApiDto
    {
        public string Title { get; set; } = "";

        public string Content { get; set; } = "";

        public string Author { get; set; } = "";

        public string UserId { get; set; } = "";

        public string? ProfileImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<CommentApiDto> Comments { get; set; } = new();

        // För brödsmulenavigeringen 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = "";
        public string ForumTitle { get; set; } = "";


    }

    public class CommentApiDto
    {
        public string Content { get; set; } = "";

        public string Author { get; set; } = "";

        public string UserId { get; set; } = "";

        public string? ProfileImageUrl { get; set; }

        public DateTime CreatedAt { get; set; }
    }

}
