namespace TeamBuilder.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using TeamBuilder.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            //To Do
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired();

            builder.HasIndex(t => t.Name)
                .IsUnique();

            builder.Property(t => t.Acronym)
                .IsRequired();

            //Relations

            builder.HasOne(t => t.Creator)
                .WithMany(t => t.CreatedTeams)
                .HasForeignKey(t => t.CreatorId);


        }
    }
}
