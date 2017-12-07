namespace ExternalFormatProssessing.Data.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Product
    {

        /*VAJNO !!! 
         * OSHTE PRI SUZDAVANETO NA DTOto ILI TABLICATA KOQTO SHTe POLZVAME ZA SUZDAVANE NA OBEKTI KOITO 
         * POSLE SHTE PARSVAME AKO SLOJIM ANNOTACIQTA [JsonIgnore]
         * POSLE KATo PRINTIRAME NQMA DA SE VIJDA NA KONSOLATA PROPERTITO S TAZI ANOTACIQ !!!!!*/

        //[JsonIgnore]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }

        public ICollection<ProductWarehouse> ProductWarehouses { get; set; }
    }
}
