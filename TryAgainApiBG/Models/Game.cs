using System;
using System.Collections.Generic;

namespace TryAgainApiBG.Models
{
    public partial class Game
    {
        public Game()
        {
            EventGames = new HashSet<EventGames>();
            Library = new HashSet<Library>();
        }

        public int GameId { get; set; }
        public string Title { get; set; }
        public string GameDescription { get; set; }
        public int MinPlayer { get; set; }
        public int MaxPlayer { get; set; }
        public string ImgPath { get; set; }
        public string ThumbPath { get; set; }

        public ICollection<EventGames> EventGames { get; set; }
        public ICollection<Library> Library { get; set; }
    }
}
