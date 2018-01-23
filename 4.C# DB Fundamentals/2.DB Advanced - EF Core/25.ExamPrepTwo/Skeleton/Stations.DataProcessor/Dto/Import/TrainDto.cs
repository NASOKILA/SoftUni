namespace Stations.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class TrainDto
    {

        [MaxLength(10)]
        [Required]
        public string TrainNumber { get; set; }

        public string Type { get; set; } = "HighSpeed"; //Ako e null ipo default mu slagame stoinost

        public SeatDto[] Seats { get; set; } 
            = new SeatDto[0];

        
    }
    

}
