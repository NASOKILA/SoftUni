namespace ExternalFormatProssessing.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ProductWarehouse
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Warehouse Warehouse { get; set; }
        public int WarehouseId { get; set; }
    }
}
