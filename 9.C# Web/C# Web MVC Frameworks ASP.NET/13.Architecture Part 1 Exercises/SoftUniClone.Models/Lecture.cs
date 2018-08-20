using System;
using System.Collections.Generic;

namespace SoftUniClone.Models
{
    public class Lecture
    {
        public Lecture()
        {
            this.Resources = new List<Resource>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int Order { get; set; }

        public string LectureHall { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CourseId { get; set; }

        public CourseInstance Course { get; set; }

        public ICollection<Resource> Resources { get; set; }

        // TODO: Homework descriptor
    }
}