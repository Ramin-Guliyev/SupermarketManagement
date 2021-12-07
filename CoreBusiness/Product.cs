﻿using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public double? Price { get; set; }

        public Category Category { get; set; }
    }
}
