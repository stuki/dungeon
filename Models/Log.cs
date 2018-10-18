using System;

namespace dungeon.Models
{
    // Log can contain either history, actions, points of interest,
    // messages, player joins
    public class Log
    {
        public int Id { get; set; }
        public Session Session { get; set; }
        public int PlayerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Message { get; set; }
        public string Tag { get; set; }
    }
}