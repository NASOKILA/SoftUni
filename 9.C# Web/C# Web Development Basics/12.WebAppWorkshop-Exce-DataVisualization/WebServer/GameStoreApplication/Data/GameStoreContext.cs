namespace HTTPServer.GameStoreApplication.Data
{
    using Models;
    using Microsoft.EntityFrameworkCore;


    public class GameStoreContext : DbContext
    {

        public GameStoreContext()
        {}


        //DBSETS
        public DbSet<User> Users { get; set; }

        public DbSet<Game> Games { get; set; }
        


        //Connect to Db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string connectionString = Connection.ConnectionString;
            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }


        //TABLE CONNECTIONS FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Polzvame FLuen API za da setnem emaila da e Unique zshtoto EF CORE nqma takava anotaciq
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique(true);
            
            //games and user connection
            modelBuilder.Entity<User>()
                .HasMany(u => u.Games)
                .WithOne(g => g.Creator)
                .HasForeignKey(g => g.CreatorId);
            



            
            //Orders


            //Cart


            base.OnModelCreating(modelBuilder);
        }

    }
}
