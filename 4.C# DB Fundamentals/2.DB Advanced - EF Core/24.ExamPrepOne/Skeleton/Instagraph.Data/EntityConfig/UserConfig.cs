namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(u => u.Id);

            //Taka pravim Username da e Unique
            builder.HasAlternateKey(e => e.Username);

            builder.Property(u => u.Username)
                .HasMaxLength(30);

            builder.Property(u => u.Password)
                .HasMaxLength(20);

            //Relations
            builder.HasOne(u => u.ProfilePicture)
                .WithMany(pp => pp.Users)
                .HasForeignKey(u => u.ProfilePictureId);
            
        }
    }
}
