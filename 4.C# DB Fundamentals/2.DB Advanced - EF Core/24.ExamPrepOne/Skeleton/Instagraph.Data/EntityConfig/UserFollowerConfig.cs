namespace Instagraph.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Instagraph.Models;

    public class UserFollowerConfig : IEntityTypeConfiguration<UserFollower>
    {
        
        public void Configure(EntityTypeBuilder<UserFollower> builder)
        {
            builder.HasKey(uf => new {
                uf.FollowerId,
                uf.UserId
            });

            //Relations

            builder.HasOne(uf => uf.User)
                .WithMany(u => u.UsersFollowing)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(uf => uf.Follower)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
