namespace ExternalFormatProssessing.Data
{
    using ExternalFormatProssessing.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProgramDbContext : DbContext
    {

        public ProgramDbContext()
        {}

        public ProgramDbContext(DbContextOptions options)
            :base(options)
        {}

        //DbSets
        public DbSet<Manufacturer> Manufacturers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductWarehouse> ProductWarehouses { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        //ConnectionString configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.connectionString);
            }
        }

        //FluentAPI connections 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>()
                .HasMany(m => m.Products)
                .WithOne(p => p.Manufacturer)
                .HasForeignKey(p => p.ManufacturerId);


            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductWarehouses)
                .WithOne(pm => pm.Product)
                .HasForeignKey(pm => pm.ProductId);

            modelBuilder.Entity<Warehouse>()
                .HasMany(p => p.ProductWarehouses)
                .WithOne(pm => pm.Warehouse)
                .HasForeignKey(pm => pm.WarehouseId);

            modelBuilder.Entity<ProductWarehouse>()
                .HasKey(pw => new {
                        pw.ProductId,
                        pw.WarehouseId
                });


        }

    }
}
