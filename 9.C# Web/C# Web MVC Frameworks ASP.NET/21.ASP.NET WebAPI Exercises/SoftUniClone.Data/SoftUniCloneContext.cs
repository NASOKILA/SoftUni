using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniClone.Models;

namespace SoftUniClone.Data
{
    public class SoftUniCloneContext : IdentityDbContext<User>
    {
        public SoftUniCloneContext(DbContextOptions<SoftUniCloneContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseInstance> CourseInstances { get; set; }

        public DbSet<Lecture> Lectures { get; set; }

        public DbSet<ResourceType> ResourceTypes { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentsInCourses> StudentsInCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasMany(u => u.EnrolledCourses)
                .WithOne(ec => ec.Student)
                .HasForeignKey(ec => ec.StudentId);

            builder
                .Entity<CourseInstance>()
                .HasMany(c => c.Students)
                .WithOne(st => st.Course)
                .HasForeignKey(c => c.CourseId);

            builder
                .Entity<StudentsInCourses>()
                .HasKey(sc => new { sc.CourseId, sc.StudentId });

            base.OnModelCreating(builder);
        }
    }
}
