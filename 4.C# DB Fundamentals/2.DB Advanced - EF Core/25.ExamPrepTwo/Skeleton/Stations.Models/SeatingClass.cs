namespace Stations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    
    public class SeatingClass
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [StringLength(2, MinimumLength  = 2)] // exactly 2 simbols
        [Required]
        public string Abbreviation { get; set; }

    }
}
