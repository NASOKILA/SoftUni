namespace SoftUniClone.Models
{
    public class Resourse
    {
        public int Id { get; set; }

        public int LectureId { get; set; }

        public int Order { get; set; }

        public Lecture Lecture { get; set; }

        public ResourseType Type { get; set; }

        public string ResourseUrl { get; set; }
    }
}
