using System;
using System.ComponentModel.DataAnnotations;

namespace SoftUniClone.Common.Admin.BindingModels
{
    public class InstanceCreationBindingModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Lecturer")]
        public string LecturerId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}
