namespace TeamBuilder.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using TeamBuilder.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserTeamConfiguration : IEntityTypeConfiguration<UserTeam>
    {
        public void Configure(EntityTypeBuilder<UserTeam> builder)
        {

            builder.HasKey(ut => new { ut.UserId, ut.TeamId });

            builder.HasOne(ut => ut.User)
                .WithMany(u => u.UserTeams)
                .HasForeignKey(ut => ut.TeamId);

            builder.HasOne(et => et.Team)
                .WithMany(t => t.UserTeams)
                .HasForeignKey(et => et.TeamId);


        }
    }
}
