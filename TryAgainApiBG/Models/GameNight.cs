using System;
using System.Collections.Generic;

namespace TryAgainApiBG.Models
{
    public partial class GameNight
    {
        public GameNight()
        {
            EventGames = new HashSet<EventGames>();
            EventPlayers = new HashSet<EventPlayers>();
        }

        public int GameNightId { get; set; }
        public string EventTitle { get; set; }
        public DateTime EventDate { get; set; }
        public string Notes { get; set; }

        public ICollection<EventGames> EventGames { get; set; }
        public ICollection<EventPlayers> EventPlayers { get; set; }
    }
}
