namespace P01_StudentSystem.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> entity)
        {
            entity.HasKey(sc => new {
                sc.StudentId,
                sc.CourseId
            });

            entity.HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);

            entity.HasOne(sc => sc.Student)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);

        }
    }
}
