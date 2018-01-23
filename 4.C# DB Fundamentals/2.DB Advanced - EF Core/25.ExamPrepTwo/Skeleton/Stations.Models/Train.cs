using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Stations.Models
{
    public class Train
    {
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        public string TrainNumber { get; set; }

        public TrainType? Type { get; set; } // Tova e optional

        public ICollection<TrainSeat> TrainSeats { get; set; }
         = new HashSet<TrainSeat>();

        public ICollection<Trip> Trips { get; set; }
         = new HashSet<Trip>();
    }
}
