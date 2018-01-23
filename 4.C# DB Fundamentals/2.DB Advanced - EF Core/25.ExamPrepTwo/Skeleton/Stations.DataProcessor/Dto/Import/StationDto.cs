﻿namespace Stations.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class StationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [MaxLength(50)]
        public string Town { get; set; }
    }
}
