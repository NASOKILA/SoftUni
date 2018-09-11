using System.ComponentModel.DataAnnotations;

namespace SoftUniClone.Common.Admin.ViewModels
{
    public class CourseInstanceViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }
    }
}
