using FindMyPet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FindMyPet.Data
{
    //we put the User class that we created because it has additional things in it
    //we have to add a migration
    public class FindMyPetDbContext : IdentityDbContext<User>  //<User>
    {
        public FindMyPetDbContext(DbContextOptions<FindMyPetDbContext> options)
            : base(options)
        {
        }

        
        public FindMyPetDbContext()
        {}
        
        public DbSet<Pet> Pets { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Like> Likes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<User>()
                .HasMany(u => u.PetsFound)
                .WithOne(pf => pf.Founder);
            
            builder.Entity<User>()
                .HasMany(u => u.PetsLost)
                .WithOne(pl => pl.Owner);

            builder.Entity<User>()
                .HasMany(u => u.MessagesReceived)
                .WithOne(m => m.Recever);

            builder.Entity<User>()
                .HasMany(u => u.MessagesSent)
                .WithOne(m => m.Sender);

            builder.Entity<Pet>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Pet);

            builder.Entity<Comment>()
                .HasMany(c => c.Likes)
                .WithOne(l => l.Comment);


            base.OnModelCreating(builder);
        }
        
    }
}
