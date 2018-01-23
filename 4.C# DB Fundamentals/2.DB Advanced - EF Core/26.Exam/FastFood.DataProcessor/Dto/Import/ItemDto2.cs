namespace FastFood.DataProcessor.Dto.Import
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Items")]
    public class ItemDto2
    {
        public List<ItemDtoToUse> Item { get; set; }
    }
}