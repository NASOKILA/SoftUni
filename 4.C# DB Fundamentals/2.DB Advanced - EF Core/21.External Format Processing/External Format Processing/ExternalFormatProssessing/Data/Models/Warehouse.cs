namespace ExternalFormatProssessing.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class Warehouse
    {
        [Key]
        public int Id { get; set; }

        public string Location { get; set; }

        public ICollection<ProductWarehouse> ProductWarehouses { get; set; }
           
    }
}
