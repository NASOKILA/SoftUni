﻿namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Color
    {
        public Color()
        {

        }

        public int ColorId { get; set; }

        public string Name { get; set; }

        public ICollection<Team> PrimaryKitTeams { get; set; }
            = new List<Team>();

        public ICollection<Team> SecondaryKitTeams { get; set; }
            = new List<Team>();
    }
}
