using System;
using System.Collections.Generic;

namespace TryAgainApiBG.Models
{
    public partial class Library
    {
        public int LibraryId { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }

        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}
