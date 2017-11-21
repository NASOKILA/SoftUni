
namespace P03_SalesDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_SalesDatabase.Data.Models;

    public class SalesContext : DbContext
    {
        //Pravim si konstruktorite
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
            :base(options)
        {
        }


        //DbSetovete:
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Sale> Sale { get; set; }

        public DbSet<Stores> Store { get; set; }


        //Opravqme si connection stringa:
        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            if (!optionBuilder.IsConfigured)
            {
                optionBuilder.UseSqlServer(Configuration.connectionString);
            }
        }

        //Opravqme si i vruzkite i tablicite:
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.Name)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasDefaultValue("No description");
            });


            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Name)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(100);


                entity.Property(e => e.Email)
                    .IsUnicode(false)
                    .IsRequired()
                    .HasMaxLength(80);


                //One Customer can have many sales
                entity.HasMany(e => e.Sales)
                    .WithOne(e => e.Customer);

            });


            builder.Entity<Stores>(entity => 
            {
                entity.HasKey(s => s.StoreId);

                entity.Property(s => s.Name)
                    .IsUnicode()
                    .IsRequired()
                    .HasMaxLength(80);

                entity.HasMany(e => e.Sales)
                    .WithOne(e => e.Store);
            });


            builder.Entity<Sale>(entity => {
        
                entity.HasKey(e => e.SaleId);

                //One Sale can have many products
                entity.HasOne(e => e.Product)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(e => e.ProductID)
                    .HasConstraintName("FK_Sales_Product");

                //Many Sales have one customer
                entity.HasOne(e => e.Customer)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(e => e.CustomerID)
                    .HasConstraintName("FK_Sales_Customer");

                //Many Sales have one store
                entity.HasOne(e => e.Store)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(e => e.StoreID)
                    .HasConstraintName("FK_Sales_Store");

                entity.Property(e => e.Date)
                    .HasDefaultValueSql("GETDATE()");
                
            });
                
            
         }

    }
}
