namespace SoftUniClone.Models
{
    using System;
    using System.Collections.Generic;

    public class Lecture
    {
        public Lecture()
        {
            this.Resourses = new List<Resourse>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string LectureHall { get; set; }

        public int Order { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    
        public ICollection<Resourse> Resourses { get; set; }

        public int CourseId { get; set; }

        public CourseInstance Course { get; set; }
    }
}