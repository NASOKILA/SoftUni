using System.ComponentModel.DataAnnotations;

namespace SoftUniClone.Common.Admin.BindingModels
{
    public class CourseCreationBindingModel
    {

        [Required]
        [StringLength(200, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }
    }
}
