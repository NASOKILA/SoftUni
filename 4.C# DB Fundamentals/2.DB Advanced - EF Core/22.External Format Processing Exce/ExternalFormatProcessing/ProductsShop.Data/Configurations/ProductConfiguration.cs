namespace ProductsShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using ProductsShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {

            entity.HasKey(p => p.Id);

            entity.Property(p => p.BuyerId)
                .IsRequired(false);

            entity.HasMany(p => p.CategoriesProducts)
                .WithOne(cp => cp.Product)
                .HasForeignKey(cp => cp.ProductId)
                .HasConstraintName("FK_Product_CategoryProduct");
            
        }
    }
}
