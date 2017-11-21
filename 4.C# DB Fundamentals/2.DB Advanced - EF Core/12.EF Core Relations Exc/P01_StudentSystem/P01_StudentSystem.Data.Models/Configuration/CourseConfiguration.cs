namespace P01_StudentSystem.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> entity)
        {

            //vruzki i kluchove
            entity.HasKey(c => c.CourseId);



            entity.HasMany(c => c.HomeworkSubmissions)
                        .WithOne(hs => hs.Course)
                        .HasForeignKey(hs => hs.CourseId);

            entity.HasMany(c => c.Resources)
                        .WithOne(r => r.Course)
                        .HasForeignKey(r => r.CourseId);

            //Propertita
            entity.Property(c => c.Name)
                        .HasMaxLength(80)
                        .IsUnicode(true)
                        .IsRequired(true);

            entity.Property(c => c.Description)
                        .IsUnicode(true)
                        .IsRequired(false);

            entity.Property(c => c.StartDate)
                        .IsRequired(true);

            entity.Property(c => c.EndDate)
                        .IsRequired(true);

            entity.Property(c => c.Price)
                        .IsRequired(true);
             
        }
    }
}
