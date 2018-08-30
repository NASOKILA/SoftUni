using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FindMyPet.Models.Enums;
using FindMyPet.Models.Interfaces;

namespace FindMyPet.Models
{
    public class Pet : IPet
    {
        public Pet()
        {
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public ICollection<Comment> Comments { get; set; }
        
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public string FounderId { get; set; }

        public User Founder { get; set; }

        public int? Age { get; set; }

        public string Gender { get; set; }

        public string Breed { get; set; }

        public string Color { get; set; }

        [Required]
        public string LocationLost { get; set; }

        [Required]
        public DateTime TimeLost { get; set; }

        public DateTime? TimeFound { get; set; }
    }
}
