using Snackis1.Data.Enum;

namespace Snackis1.Data.Entities
{
    public class Report
    {
        public int Id { get; set; }
        public string Reason { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public ReportStatus Status { get; set; } = ReportStatus.Pending;


        public string ReporterId { get; set; } = "";    //FK. Till användaren som rapporterat inlägg

        public ApplicationUser? Reporter { get; set; }  // Nav propp

        public int? PostId { get; set; }        // FK
        public Post? Post { get; set; }         // Nav propp


        public string ReportedPostTitle { get; set; } = "";  // Sparad kopia av inläggets rubrik, för historik Adminpanel
        public string ReportedPostAuthor { get; set; } = ""; // Sparad kopia av inläggets skapare, för historik Adminpanel



    }
}
