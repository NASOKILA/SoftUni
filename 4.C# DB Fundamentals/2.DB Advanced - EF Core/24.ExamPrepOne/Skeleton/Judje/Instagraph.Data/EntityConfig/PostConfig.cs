namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.Id);

            //Relations
            builder.HasOne(p => p.Picture)
                .WithMany(pi => pi.Posts)
                .HasForeignKey(p => p.PictureId);

            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict); // TOVA E ZA DA NQMA CIKLI
            
        }
    }
}
