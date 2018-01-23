namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Position
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; } //has to be set to unique

        public ICollection<Employee> Employees { get; set; }
            = new HashSet<Employee>();

    }
}
