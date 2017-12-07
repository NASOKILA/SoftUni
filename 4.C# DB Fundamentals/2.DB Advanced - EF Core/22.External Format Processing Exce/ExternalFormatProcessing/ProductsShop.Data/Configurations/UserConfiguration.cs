namespace ProductsShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using ProductsShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {

            entity.HasKey(u => u.Id);

            entity.Property(u => u.FirstName)
                .IsRequired(false)
                .IsUnicode();

            entity.Property(u => u.LastName)
                .IsUnicode();

            entity.HasMany(u => u.ProductsBought)
                .WithOne(p => p.Buyer)
                .HasForeignKey(p => p.BuyerId)
                .HasConstraintName("FK_Buyer_ProductsBought");

            entity.HasMany(u => u.ProductsSold)
                .WithOne(p => p.Seller)
                .HasForeignKey(p => p.SellerId)
                .HasConstraintName("FK_Seller_ProductsSold");
            
        }
    }
}
