﻿namespace FastFood.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class OrderItem
    {
        public int OrderId { get; set; }

        [Required]
        public Order Order { get; set; }

        public int ItemId { get; set; }

        [Required]
        public Item Item { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
