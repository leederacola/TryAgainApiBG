using System;
using System.Collections.Generic;

namespace TryAgainApiBG.Models
{
    public partial class EventGames
    {
        public int EventGamesId { get; set; }
        public int GameNightId { get; set; }
        public int GameId { get; set; }
        public int? GameVotes { get; set; }

        public Game Game { get; set; }
        public GameNight GameNight { get; set; }
    }
}
