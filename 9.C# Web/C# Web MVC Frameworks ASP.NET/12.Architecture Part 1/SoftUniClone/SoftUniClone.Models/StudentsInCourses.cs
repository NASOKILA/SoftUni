namespace SoftUniClone.Models
{

    public class StudentsInCourses
    {

        //public int Id { get; set; }

        public int StudentId { get; set; }

        public User Student { get; set; }

        public int CourseId { get; set; }

        public CourseInstance Course { get; set; }
    }
}
