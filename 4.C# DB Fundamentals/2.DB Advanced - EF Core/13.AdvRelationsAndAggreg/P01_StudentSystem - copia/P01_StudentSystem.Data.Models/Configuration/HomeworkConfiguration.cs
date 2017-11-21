namespace P01_StudentSystem.Data.Models.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> entity)
        {
            //kluchove i vruzki
            entity.HasKey(h => h.HomeworkId);

            entity.HasOne(h => h.Course)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.CourseId);

            entity.HasOne(h => h.Student)
                .WithMany(c => c.HomeworkSubmissions)
                .HasForeignKey(h => h.StudentId);

            //propertita
            entity.Property(h => h.Content)
                .IsUnicode(false)
                .IsRequired();
            //Ne znam kak da go naprava da e linkable kum fail

            entity.Property(h => h.ContentType)
                .IsRequired();

            entity.Property(h => h.SubmissionTime)
                .IsRequired();
        }
    }
}
