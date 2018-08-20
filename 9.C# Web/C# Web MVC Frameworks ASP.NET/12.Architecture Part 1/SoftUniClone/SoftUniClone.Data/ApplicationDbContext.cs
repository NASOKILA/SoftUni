using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoftUniClone.Models;

namespace SoftUniClone.Data
{
    //we set the context to work with a User
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseInstance> CoursesInstances { get; set; }

        public DbSet<Lecture> Lectures { get; set; }
        
        public DbSet<StudentsInCourses> StudentsInCourses { get; set; }

        public DbSet<Resourse> Resourses { get; set; }

        public DbSet<ResourseType> ResourseTypes { get; set; }

        //we already have it by default
        //new public DbSet<User> Users { get; set; }

            

        protected override void OnModelCreating(ModelBuilder builder)
        {

            

            builder
                .Entity<CourseInstance>()
                .HasMany(ci => ci.Students)
                .WithOne(s => s.Course)
                .HasForeignKey(ci => ci.CourseId);
            

            builder
                .Entity<StudentsInCourses>()
                .HasKey(sc => new { sc.CourseId, sc.StudentId });
            



            base.OnModelCreating(builder);
        }

    }
}
