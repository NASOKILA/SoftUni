using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniClone.Models
{
    public class Course
    {
        public Course()
        {
            this.Instances = new List<CourseInstance>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public ICollection<CourseInstance> Instances { get; set; }
    }
}
