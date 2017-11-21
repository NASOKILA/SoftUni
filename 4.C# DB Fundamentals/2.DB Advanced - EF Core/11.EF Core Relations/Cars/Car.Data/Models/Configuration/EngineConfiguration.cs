namespace Car.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EngineConfiguration : IEntityTypeConfiguration<Engine>
    {
        public void Configure(EntityTypeBuilder<Engine> builder)
        {
            builder
            .HasMany(e => e.Cars)
            .WithOne(c => c.Engine)
            .HasForeignKey(c => c.EngineId);
        }
    }
}
