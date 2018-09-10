using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dungeon
{
    // The player is either the DM or any other actor in the session
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<PlayerSession> PlayerSessions { get; set; }
    }
}