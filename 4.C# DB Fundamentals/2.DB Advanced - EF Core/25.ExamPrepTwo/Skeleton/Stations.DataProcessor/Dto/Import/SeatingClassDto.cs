namespace Stations.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class SeatingClassDto
    {
        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [StringLength(2, MinimumLength = 2)] // exactly 2 simbols
        [Required]
        public string Abbreviation { get; set; }
    }
}
