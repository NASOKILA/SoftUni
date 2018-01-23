using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFood.Models
{
	public class Employee
	{
        public int Id { get; set; }

        [MaxLength(30)]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }

        [Range(15, 80)]
        [Required]
        public int Age { get; set; }
       
        
        public int PositionId { get; set; }

        [Required]
        public Position Position { get; set; }

        public ICollection<Order> Orders { get; set; }
            = new HashSet<Order>();

    }
}