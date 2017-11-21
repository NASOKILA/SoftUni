namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;

    public class Team
    {
        public Team()
        {

        }

        public int TeamId { get; set; }

        public string Name { get; set; }

        public string LogoUrl { get; set; }

        public string Initials { get; set; }

        public decimal Budget { get; set; }

        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        public int SeondaryKitColorId { get; set; }
        public Color SeondaryKitColor { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        public ICollection<Player> Players { get; set; }
            = new List<Player>();

        public ICollection<Game> HomeGames { get; set; }
            = new List<Game>();

        public ICollection<Game> AwayGames { get; set; }
            = new List<Game>();

    }
}
