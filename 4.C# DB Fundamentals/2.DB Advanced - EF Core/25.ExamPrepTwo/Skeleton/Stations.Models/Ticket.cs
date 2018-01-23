namespace Stations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        [Range(typeof(decimal),"0", "79228162514264337593543950335")] // TAKA STAVA NON NEGATIVE
        public decimal Price { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{1,6}$")]     //MOJEM DA PISHEM REGULQRNI IZRAZI CHREZ ANOTACII
        public string SeatingPlace { get; set; }

        
        public int TripId { get; set; }

        [Required]
        public Trip Trip { get; set; }

        public int? CustomerCardId { get; set; } // Kato e optional mu slagame '?'
        
        public CustomerCard CustomerCard { get; set; }
        

    }
}
