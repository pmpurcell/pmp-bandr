namespace BandrBackEnd.Models
{
    public class User
    {
        public int Id { get; set; }
        public String firebaseUid { get; set; }
        public String photo { get; set; }
        
        public String userName { get; set; }

        public int userAge {  get; set; }

        public String? userBio { get; set; }

        public String? location { get; set; }

        public String skillLevel { get; set; }

        public bool isBlocked { get; set; }
    }
}
