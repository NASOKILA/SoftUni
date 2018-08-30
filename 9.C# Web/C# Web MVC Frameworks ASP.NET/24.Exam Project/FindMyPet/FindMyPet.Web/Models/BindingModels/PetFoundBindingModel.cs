using System;
using System.ComponentModel.DataAnnotations;

namespace FindMyPet.Web.Models.BindingModels
{
    public class PetFoundBindingModel
    {
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
        public string LocationLost { get; set; }

        [Required]
        public DateTime TimeLost { get; set; }
    }
}
