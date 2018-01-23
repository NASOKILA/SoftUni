namespace TeamBuilder.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using TeamBuilder.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(25);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(250);
        }
    }
}
