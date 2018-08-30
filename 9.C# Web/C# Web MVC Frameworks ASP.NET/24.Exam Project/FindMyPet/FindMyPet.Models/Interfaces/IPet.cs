using FindMyPet.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FindMyPet.Models.Interfaces
{
    public interface IPet
    {
        int Id { get; set; }

        [Required]
        string Type { get; set; }

        [Required]
        string Status { get; set; }

        [Required]
        string Name { get; set; }

        [Required]
        string ImageUrl { get; set; }

        ICollection<Comment> Comments { get; set; }

        string OwnerId { get; set; }

        User Owner { get; set; }

        string FounderId { get; set; }

        User Founder { get; set; }

        int? Age { get; set; }
        
        string Gender { get; set; }
        
        string Breed { get; set; }
        
        string Color { get; set; }
        
        string LocationLost { get; set; }
        
        DateTime TimeLost { get; set; }

        DateTime? TimeFound { get; set; }
    }
}
