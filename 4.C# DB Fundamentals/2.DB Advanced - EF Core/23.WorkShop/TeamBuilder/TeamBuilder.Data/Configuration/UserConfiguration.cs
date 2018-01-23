namespace TeamBuilder.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using TeamBuilder.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username).IsRequired();

            builder.Property(u => u.Password).IsRequired();

            builder
                .HasIndex(u => u.Username)
                .IsUnique();

            builder
                .Property(u => u.FirstName)
                .HasMaxLength(25);

            builder
                .Property(u => u.LastName)
                .HasMaxLength(25);

            builder
                .Property(u => u.Password)
                .HasMaxLength(30);

            //Relations

            builder.HasMany(u => u.CreatedTeams)
                .WithOne(t => t.Creator)
                .HasForeignKey(t => t.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CreatedEvents)
                .WithOne(e => e.Creator)
                .HasForeignKey(e => e.CreatorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(u => u.ReceivedInvitations)
                .WithOne(e => e.InvitedUser)
                .HasForeignKey(e => e.InvitedUserId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
