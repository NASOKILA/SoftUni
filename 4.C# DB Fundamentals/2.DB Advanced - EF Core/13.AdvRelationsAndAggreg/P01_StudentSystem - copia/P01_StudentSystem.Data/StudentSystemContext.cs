namespace P01_StudentSystem.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    using P01_StudentSystem.Data.Models.Configuration;

    public class StudentSystemContext : DbContext
    {

        //Konstruktori
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            :base(options)
        {

        }


        //DbSetove
        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homework { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentsCourses { get; set; }


        //Configure ConnectionString   OnConfiguring()
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Configuration.conectionString);
            }
        }


        //override OnModelCreating()      Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Student
            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            //Course
            modelBuilder.ApplyConfiguration(new CourseConfiguration());

            //StudentCourse Mapping Table
            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());

            //Homework
            modelBuilder.ApplyConfiguration(new HomeworkConfiguration());

            //Resourses
            modelBuilder.ApplyConfiguration(new ResourseConfiguration());


            //SEGA PROGRAMATA SHTE VURVI PO LEKO ZASHTOTO NQMAME POLKOVA MNOGO KOD !

        }


    }
}
