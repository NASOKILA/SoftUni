namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Item
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; } //Has to be unique

        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")] // TAKA STAVA NON NEGATIVE
        public decimal Price { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
            = new HashSet<OrderItem>();
    }
}
