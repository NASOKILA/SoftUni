using System.ComponentModel.DataAnnotations;

namespace Stations.Models
{
    public class TrainSeat
    {
        public int Id { get; set; }
        
        public int TrainId { get; set; }

        [Required]
        public Train Train { get; set; }

        public int SeatingClassId { get; set; }

        [Required]
        public SeatingClass SeatingClass { get; set; }

        [Required]
        [Range(0, int.MaxValue)]   // TAKA GO PRAVIM DA E NON NEGATIVE
        public int Quantity { get; set; }

    }
}