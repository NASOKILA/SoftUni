namespace FastFood.DataProcessor.Dto.Import
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;

    [XmlType("Order")]
    public class OrderDto
    {
        
        [Required]
        public string Customer { get; set; }

        [MaxLength(30)]
        [MinLength(3)]
        [Required]
        public string Employee { get; set; }

        [Required]
        public string DateTime { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public List<ItemDtoToUse> Items{ get; set; }

    }

    
}
