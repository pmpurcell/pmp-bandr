﻿namespace BandrBackEnd.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int participantId { get; set; }
        public string body { get; set; }
        public DateTime timeSent { get; set; }
    }
}