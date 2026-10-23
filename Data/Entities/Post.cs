

namespace Snackis1.Data.Entities
{
    public class Post
    {

        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Content { get; set; } = "";

        public DateTime CreatedAt { get; set; }


        public string UserId { get; set; } = "";     // FK i Identity

        public ApplicationUser? User { get; set; }  // Nav propp. 

        public int CategoryId { get; set; }             //FK

        // Nav properties
        public Category? Category { get; set; }        

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

        public ICollection<Report> Reports { get; set; } = new List<Report>();

    }
}
