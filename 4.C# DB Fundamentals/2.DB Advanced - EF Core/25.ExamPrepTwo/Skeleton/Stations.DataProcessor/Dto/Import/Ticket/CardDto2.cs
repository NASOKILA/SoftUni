    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Stations.DataProcessor.Dto.Import.Ticket
{
    [XmlType("Card")]
    public class CardDto2
    {
        [Required]
        [XmlAttribute("Name")]
        public string Name { get; set; }
    }
}
