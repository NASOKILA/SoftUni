namespace SoftUniClone.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ResourseType
    {
        public ResourseType()
        {
            this.Resourses = Resourses;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Resourse> Resourses { get; set; }
    }
}
