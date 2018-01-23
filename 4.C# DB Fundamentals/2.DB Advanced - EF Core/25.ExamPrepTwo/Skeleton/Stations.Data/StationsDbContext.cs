﻿using Microsoft.EntityFrameworkCore;
using Stations.Models;

namespace Stations.Data
{
	public class StationsDbContext : DbContext
	{
		public StationsDbContext()
		{
		}

		public StationsDbContext(DbContextOptions options)
			: base(options)
		{
		}

        //DbSets

        public DbSet<Station> Stations { get; set; }

        public DbSet<Train> Trains { get; set; }

        public DbSet<SeatingClass> SeatingClasses { get; set; }

        public DbSet<TrainSeat> TrainSeats { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<CustomerCard> Cards { get; set; }


        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

            //Purvo si slagame UNIQUE tam kudeto trqbva kato polzvame HasAlternativeKey():

            modelBuilder.Entity<Station>()
                .HasAlternateKey(s => s.Name);  //Pravim si imeto da e UNIQUE
            
            modelBuilder.Entity<Train>()
                .HasAlternateKey(t => t.TrainNumber);
            
            modelBuilder.Entity<SeatingClass>()
                .HasAlternateKey(sc => new { sc.Name, sc.Abbreviation }); // I dvete sa UNIQUE 

            modelBuilder.Entity<Station>()
                .HasMany(s => s.TripsTo)
                .WithOne(t => t.DestinationStation)
                .HasForeignKey(t => t.DestinationStationId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Station>()
                .HasMany(s => s.TripsFrom)
                .WithOne(t => t.OriginStation)
                .HasForeignKey(t => t.OriginStationId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}