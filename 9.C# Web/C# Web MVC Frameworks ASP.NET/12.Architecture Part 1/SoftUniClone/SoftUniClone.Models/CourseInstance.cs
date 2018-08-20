namespace SoftUniClone.Models
{
    using System;
    using System.Collections.Generic;

    public class CourseInstance
    {
        public CourseInstance()
        {
            this.Students = new List<StudentsInCourses>();
            this.Lectures = new List<Lecture>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public User Lector { get; set; }

        public int LectorId { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<StudentsInCourses> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
