namespace BandrBackEnd.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int swiperId { get; set; }
        public bool swiperMatch { get; set; } = false;
        public int recId { get; set; }
        public bool recMatch { get; set; } = false;
    }
}
