namespace BandrBackEnd.Models
{
    public class Message
    {
        public int Id { get; set; }

        public int matchId { get; set; }
        public int participantId { get; set; }

        public User participant { get; set; }
        public string body { get; set; }
        public DateTime timeSent { get; set; }
    }
}
