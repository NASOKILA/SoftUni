using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Import
{
    [XmlType("Item")]
    public class ItemDtoToUse
    {
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }


        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}