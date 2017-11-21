namespace P03_FootballBetting
{
    using P03_FootballBetting.Data;
    using P03_FootballBetting.Data.Models;
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            using (var db = new FootballBettingContext())
            {
                ResetDatabase(db);
            }
        }

        private static void ResetDatabase(FootballBettingContext db)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            Seed(db);
        }

        private static void Seed(FootballBettingContext db)
        {
            //Slagame si danni
        }
    }
}
