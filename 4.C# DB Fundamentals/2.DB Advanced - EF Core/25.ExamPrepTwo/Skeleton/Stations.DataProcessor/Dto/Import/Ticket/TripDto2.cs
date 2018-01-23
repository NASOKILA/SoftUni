namespace Stations.DataProcessor.Dto.Import.Ticket
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Trip")]
    public class TripDto2
    {
        [Required]
        public string OriginStation { get; set; }

        [Required]
        public string DestinationStation { get; set; }

        [Required]
        public string DepartureTime { get; set; }
    }
}
