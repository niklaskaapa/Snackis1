namespace Snackis1.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public string UserId { get; set; } = "";        // FK i Identity

        public ApplicationUser? User { get; set; }   // Nav Property

        public int PostId { get; set; }
        public Post? Post { get; set; }


    }
}
