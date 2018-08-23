using SoftUniClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftUniClone.Web.Areas.Admin.Models.ViewModels
{
    public class CourseInstanceDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string LecturerId { get; set; }

        public User Lecturer { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<StudentsInCourses> Students { get; set; }

        public ICollection<Lecture> Lectures { get; set; }
    }
}
