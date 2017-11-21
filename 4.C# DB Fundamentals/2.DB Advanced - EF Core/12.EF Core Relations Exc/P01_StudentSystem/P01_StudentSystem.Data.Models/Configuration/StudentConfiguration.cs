namespace P01_StudentSystem.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> entity)
        {

            //vruzki i kluchove
            entity.HasKey(s => s.StudentId);

            /*
                            entity.HasMany(s => s.StudentCourses)
                                .WithOne(sc => sc.Student)
                                .HasForeignKey(sc => sc.StudentId);
            */
            entity.HasMany(s => s.HomeworkSubmissions)
                .WithOne(hs => hs.Student)
                .HasForeignKey(hs => hs.StudentId);

            //Propertita
            entity.Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode(true)
                .IsRequired(true);

            entity.Property(s => s.PhoneNumber)
                .IsUnicode(false)
                .IsRequired(false);

            entity.Property(s => s.RegisteredOn)
                .IsRequired(true);

            entity.Property(s => s.BirthDay)
                .IsRequired(false);
        }
    }
}
