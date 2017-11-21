namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;
    using System;

    public class FootballBettingContext : DbContext
    {

        //Constructors
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            :base(options)
        {

        }


        //DbSets
        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }




        //Connection String Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configure.connectionString);
            }
        }


        //OnModelConfig()  Connections And Properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Team>(entity => {

                //Vruzki i kluchove
                //VINAGI PISHI KLUCHOVETE OT TAM OT KUDETO E Ednoto kum Mnogoto

                entity.HasKey(t => t.TeamId);

                entity.HasOne(t => t.Town)
                    .WithMany(t => t.Teams)
                    .HasForeignKey(t => t.TownId)
                    .HasConstraintName("FK_Team_Town");

                entity.HasOne(t => t.PrimaryKitColor)
                    .WithMany(pkc => pkc.PrimaryKitTeams)
                    .HasForeignKey(t => t.PrimaryKitColorId)
                    .HasConstraintName("FK_Team_PrimaryKitColor")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.SeondaryKitColor)
                    .WithMany(pkc => pkc.SecondaryKitTeams)
                    .HasForeignKey(t => t.SeondaryKitColorId)
                    .HasConstraintName("FK_Team_SecondaryKitColor")
                    .OnDelete(DeleteBehavior.Restrict);
                //VAJNOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO!!!!
                //AKO NI POKAZVA CHE MOJE DA SE SUZDAVAT CIKLI V DADENA KOLONA V DADENA TABLICA
                //TRQBVA DA NAPISHEM TOVA: .OnDelete(DeleteBehavior.Restrict);





                //VAJNO !!! NA MNOGO NESHTA TRQBVA DA DAVAME .Required(true) ZASHTOTO NE MOJE 
                //DA SA NULL I SHE SE SCHUPI
                //Propertita
                entity.Property(t => t.Name)
                    .IsRequired();  //Po default e 'true'

                entity.Property(t => t.Initials)
                    .HasColumnType("NCHAR(3)")
                    .IsRequired();

                entity.Property(t => t.LogoUrl)
                    .IsRequired();
                

            });

            modelBuilder.Entity<Color>(entity => {

                entity.HasKey(c => c.ColorId);

                entity.Property(c => c.Name)
                    .IsRequired();

            });

            modelBuilder.Entity<Town>(entity => {

                entity.HasKey(t => t.TownId);

                entity.Property(c => c.Name)
                    .IsRequired();

                entity.HasOne(t => t.Country)
                    .WithMany(c => c.Towns)
                    .HasForeignKey(t => t.CountryId)
                    .HasConstraintName("FK_Town_Country");

            });

            modelBuilder.Entity<Country>(entity => {

                entity.HasKey(c => c.CountryId);

                entity.Property(c => c.Name)
                    .IsRequired();
            });

            modelBuilder.Entity<Player>(entity => {

                entity.HasKey(c => c.PlayerId);

                //Kuchove i vruzki

                //Tova beshe po dobre ot Player da go napravim zashtoto tam e ednoto a tuka sa mnogoto !!!
                entity.HasOne(p => p.Team)
                    .WithMany(t => t.Players)
                    .HasForeignKey(p => p.TeamId)
                    .HasConstraintName("FK_Player_Team");

                entity.HasOne(p => p.Position)
                    .WithMany(po => po.Players)
                    .HasForeignKey(p => p.PositionId)
                    .HasConstraintName("FK_Player_Position");

                //Propertita
                entity.Property(c => c.Name)
                    .IsRequired();

                entity.Property(c => c.IsInjured)
                    .HasDefaultValue(false);

            });

            modelBuilder.Entity<Position>(entity => {

                entity.HasKey(c => c.PositionId);

                entity.Property(c => c.Name)
                    .IsRequired();
            });

            modelBuilder.Entity<PlayerStatistic>(entity => {

                entity.HasKey(ps => new { ps.PlayerId, ps.GameId});

                //Kluchove i vruzki

                entity.HasOne(ps => ps.Player)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.PlayerId)
                    .HasConstraintName("FK_PlayerStatistics_Player");

                entity.HasOne(ps => ps.Game)
                    .WithMany(p => p.PlayerStatistics)
                    .HasForeignKey(ps => ps.GameId)
                    .HasConstraintName("FK_PlayerStatistics_Games");
            

                //Propertita nqma da pishem 
            });

            modelBuilder.Entity<Game>(entity => {

                entity.HasKey(g => g.GameId);

                entity.HasOne(g => g.HomeTeam)
                    .WithMany(ht => ht.HomeGames)
                    .HasForeignKey(g => g.HomeTeamId)
                    .HasConstraintName("FK_HomeGame_HomeTeam")
                    .OnDelete(DeleteBehavior.Restrict);   //I tuk go dabavqme zashtoto ni gurmi

                entity.HasOne(g => g.AwayTeam)
                    .WithMany(ht => ht.AwayGames)
                    .HasForeignKey(g => g.AwayTeamId)
                    .HasConstraintName("FK_AwayGame_AwayTeam")
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Bet>(entity => {

                entity.HasKey(b => b.BetId);

                entity.HasOne(b => b.Game)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.GameId)
                    .HasConstraintName("FK_Bet_Game");

                entity.HasOne(b => b.User)
                    .WithMany(g => g.Bets)
                    .HasForeignKey(b => b.UserId)
                    .HasConstraintName("FK_Bet_User");
                
            });

            modelBuilder.Entity<User>(entity => {

                entity.HasKey(u => u.UserId);

                //Proeptita
                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(u => u.Password)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(u => u.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(u => u.Balance)
                    .HasDefaultValue(0);


            });
        }
    }
}














