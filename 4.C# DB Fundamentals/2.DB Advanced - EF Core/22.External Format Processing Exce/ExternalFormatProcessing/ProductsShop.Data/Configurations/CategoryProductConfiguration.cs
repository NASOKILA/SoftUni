namespace ProductsShop.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using ProductsShop.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryProductConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> entity)
        {

            entity.HasKey(cp => new {
                cp.CategoryId,
                cp.ProductId
            });

            
        }
    }
}
