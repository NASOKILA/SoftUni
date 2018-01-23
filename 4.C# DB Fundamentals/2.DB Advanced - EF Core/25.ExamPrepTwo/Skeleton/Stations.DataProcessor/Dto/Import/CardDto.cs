namespace Stations.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Card")]  // TOVA NI TRQBVA ZA DA GO RAZPOZNAE Pri PARSVANETO, Imenata trqbva da sa ednakvi
    public class CardDto
    {

        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        public string CardType { get; set; } = "Normal"; //setvame go da e normal po default
    }
}
