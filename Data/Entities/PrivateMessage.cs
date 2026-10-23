namespace Snackis1.Data.Entities
{
    public class PrivateMessage
    {

        public int Id { get; set; }

        public string Content { get; set; } = "";

        public DateTime SentAt { get; set; }

        public bool IsRead { get; set; }


        public string SenderId { get; set; } = "";       // FK i Identity. Id avsändare

        public string ReceiverId { get; set; } = "";    // FK i Identity. Id mottagare

        //Nav properties
        public ApplicationUser? Sender { get; set; }     

        public ApplicationUser? Receiver { get; set; }


    }
}
