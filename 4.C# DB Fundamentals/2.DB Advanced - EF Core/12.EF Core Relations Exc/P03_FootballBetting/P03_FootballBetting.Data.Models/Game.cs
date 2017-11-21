namespace P03_FootballBetting.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Game
    {
        public Game()
        {

        }

        public int GameId { get; set; }

        public DateTime DateTime { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public byte HomeTeamGoals { get; set; }
        public float HomeTeamBetRate { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public byte AwayTeamGoals { get; set; }
        public float AwayTeamBetRate { get; set; }

        public float DrawTeamBetRate { get; set; }

        public GameResult Result { get; set; }

        public ICollection<Bet> Bets { get; set; }
            = new List<Bet>();

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; }
            = new List<PlayerStatistic>();

    }
}
