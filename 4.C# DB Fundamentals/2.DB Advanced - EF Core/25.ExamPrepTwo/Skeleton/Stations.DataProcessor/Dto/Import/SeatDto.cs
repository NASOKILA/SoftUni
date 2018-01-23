namespace Stations.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class SeatDto
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Abbreviation { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int? Quantity { get; set; }
    }
}
