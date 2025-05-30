﻿namespace HplusSportAPI.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;

        public virtual List<Product>? Products { get; set; }
    }
}
