namespace FastFood.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class EmployeeDto
    {

        [MaxLength(30)]
        [MinLength(3)]
        [Required]
        public string Name { get; set; }
        
        [Range(15, 80)]
        [Required]
        public int Age { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Position { get; set; }
    }
}
