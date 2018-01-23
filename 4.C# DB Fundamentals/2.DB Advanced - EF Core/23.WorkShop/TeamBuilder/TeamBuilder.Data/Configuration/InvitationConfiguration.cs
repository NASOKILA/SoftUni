namespace TeamBuilder.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using TeamBuilder.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            // To Do
            builder.Property(i => i.Id);

            builder.HasOne(i => i.Team)
                .WithMany(t => t.Invitations)
                .HasForeignKey(i => i.TeamId);

            builder.HasOne(i => i.InvitedUser)
                .WithMany(t => t.ReceivedInvitations)
                .HasForeignKey(i => i.InvitedUserId);   
        }
    }
}
