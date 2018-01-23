namespace Instagraph.Data.EntityConfig
{
    using Instagraph.Models;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PictureConfig : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {

            builder.HasKey(p => p.Id);
            
            //Vruzkite sa napraveni
        }
    }
}
