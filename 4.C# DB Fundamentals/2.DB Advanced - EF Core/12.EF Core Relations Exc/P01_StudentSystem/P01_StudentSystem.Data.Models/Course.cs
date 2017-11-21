namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        public Course()
        {

        }

        public int CourseId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        //Many To Many with Students
        public ICollection<StudentCourse> StudentCourses { get; set; }
            = new List<StudentCourse>();

        public ICollection<Resource> Resources { get; set; }
             = new List<Resource>();

        public ICollection<Homework> HomeworkSubmissions { get; set; }
           = new List<Homework>();
    }
}
