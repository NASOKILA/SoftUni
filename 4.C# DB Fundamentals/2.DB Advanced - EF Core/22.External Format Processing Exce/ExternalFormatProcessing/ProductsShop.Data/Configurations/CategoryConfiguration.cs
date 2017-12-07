namespace ProductsShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using ProductsShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(c => c.Id);

            entity.HasMany(c => c.CaegoryProducts)
                .WithOne(cp => cp.Category)
                .HasForeignKey(cp => cp.CategoryId)
                .HasConstraintName("FK_Category_CategoryProduct");

        }
    }
}
