namespace FastFood.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class ItemDto
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        [MaxLength(30)]
        [MinLength(3)]      
        public string Category { get; set; }  //PRI DECIMAL "0.01" VALIDTORA GURMI
    }
}
