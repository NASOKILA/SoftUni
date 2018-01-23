using FastFood.Models;
using Microsoft.EntityFrameworkCore;

namespace FastFood.Data
{
	public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

        //DbSets
        public DbSet<Category> Categories { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            //Opravqme si Unique purvo
            builder.Entity<Position>()
                .HasAlternateKey(p => p.Name);

            builder.Entity<Item>()
                .HasAlternateKey(i => i.Name);

            builder.Entity<OrderItem>()
                .HasKey(oi => new
                {
                    oi.ItemId,
                    oi.OrderId
                });

          /*  //0.01 decimal.max
            //Item Price,
            builder.Entity<Item>()
                .Property(i => i.Price)
                */


        }
    }
}