using System.ComponentModel.DataAnnotations;

namespace SoftUniClone.Web.Areas.Admin.Models.BindingModels
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
