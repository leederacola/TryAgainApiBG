using System;
using System.Collections.Generic;

namespace TryAgainApiBG.Models
{
    public partial class Player
    {
        public Player()
        {
            EventPlayers = new HashSet<EventPlayers>();
            Library = new HashSet<Library>();
        }

        public int PlayerId { get; set; }
        public string PlayerName { get; set; }

        public ICollection<EventPlayers> EventPlayers { get; set; }
        public ICollection<Library> Library { get; set; }
    }
}
