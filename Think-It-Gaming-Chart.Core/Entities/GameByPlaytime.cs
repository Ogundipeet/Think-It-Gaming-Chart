using System;
using System.Collections.Generic;

namespace Think_It_Gaming_Chart.Core.Entities
{
    public class GameByPlaytime : IComparable<GameByPlaytime>
    {
        public int UserId { get; set; }
        public string Game { get; set; }
        public int PlayTime { get; set; }
        public string Genre { get; set; }
        public List<string> Platforms { get; set; }

        int IComparable<GameByPlaytime>.CompareTo(GameByPlaytime other)
        {
            return this.PlayTime.CompareTo(other.PlayTime);
        }

    }
}
