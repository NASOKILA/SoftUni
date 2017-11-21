namespace Car.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class MakeConfiguration : IEntityTypeConfiguration<Make>
    {
        public void Configure(EntityTypeBuilder<Make> builder)
        {
            //OneToMany Make - Car
            builder
                .HasMany(e => e.Cars)
                .WithOne(c => c.Make)
                .HasForeignKey(c => c.MakeId);
        }
    }
}
