namespace P01_StudentSystem.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ResourseConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> entity )
        {

            //kluchove i vruzki
            entity.HasKey(r => r.ResourseId);

            entity.HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);

            //Propertita
            entity.Property(r => r.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            entity.Property(r => r.Url)
                .IsUnicode(false)
                .IsRequired(true);

            entity.Property(r => r.ResourceType)
                .IsRequired(true);

        }
    }
}
