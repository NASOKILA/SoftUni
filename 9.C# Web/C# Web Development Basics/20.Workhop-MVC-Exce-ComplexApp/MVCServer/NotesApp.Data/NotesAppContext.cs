namespace NotesApp.Data
{
    using Microsoft.EntityFrameworkCore;
    using NotesApp.Models;
    using System.Reflection;
    using System.Resources;

    public class NotesAppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Note> Notes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var dbManager = new ResourceManager(
                    "NotesApp.Data.DbSettings", 
                    typeof(NotesAppContext).Assembly);
                string connectionString = dbManager.GetString("ConnectionString");

                optionsBuilder
                    .UseSqlServer(connectionString);

            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(user => user.Username)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
