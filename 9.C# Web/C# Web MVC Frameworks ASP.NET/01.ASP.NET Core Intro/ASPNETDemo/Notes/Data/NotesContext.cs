namespace Notes.Data
{
    using Microsoft.EntityFrameworkCore;
    using Notes.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

    public class NotesContext : DbContext 
    {
        public NotesContext()
        {}

        public DbSet<Note> Notes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                    .HasOne(n => n.Author)
                    .WithMany(a => a.Notes);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Notes)
                .WithOne(n => n.Author);

            base.OnModelCreating(modelBuilder);
        }

    }
}
