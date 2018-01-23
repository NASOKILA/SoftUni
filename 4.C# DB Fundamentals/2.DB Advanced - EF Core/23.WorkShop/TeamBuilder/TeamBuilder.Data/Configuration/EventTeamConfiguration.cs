namespace TeamBuilder.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using TeamBuilder.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EventTeamConfiguration : IEntityTypeConfiguration<EventTeam>
    {
        public void Configure(EntityTypeBuilder<EventTeam> builder)
        {

            builder.ToTable("EventTeams");

            builder.HasKey(et => new { et.EventId, et.TeamId });

            builder.HasOne(et => et.Event)
                .WithMany(e => e.ParticipatingEventTeams)
                .HasForeignKey(et => et.EventId);

            builder.HasOne(et => et.Team)
                .WithMany(e => e.EventTeams)
                .HasForeignKey(et => et.EventId);
        }
    }
}
