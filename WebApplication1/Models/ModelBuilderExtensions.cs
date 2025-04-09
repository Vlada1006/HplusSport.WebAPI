using HplusSportAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HPlusSport.API.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Active Wear - Men" },
                new Category { CategoryId = 2, Name = "Active Wear - Women" },
                new Category { CategoryId = 3, Name = "Mineral Water" },
                new Category { CategoryId = 4, Name = "Publications" },
                new Category { CategoryId = 5, Name = "Supplements" });

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, CategoryId = 1, Name = "Grunge Skater Jeans", Sku = "AWMGSJ", Price = 68, IsAvailable = true },
                new Product { ProductId = 2, CategoryId = 1, Name = "Polo Shirt", Sku = "AWMPS", Price = 35, IsAvailable = true },
                new Product { ProductId = 3, CategoryId = 1, Name = "Skater Graphic T-Shirt", Sku = "AWMSGT", Price = 33, IsAvailable = true },
                new Product { ProductId = 4, CategoryId = 1, Name = "Slicker Jacket", Sku = "AWMSJ", Price = 125, IsAvailable = true },
                new Product { ProductId = 5, CategoryId = 1, Name = "Thermal Fleece Jacket", Sku = "AWMTFJ", Price = 60, IsAvailable = true },
                new Product { ProductId = 6, CategoryId = 1, Name = "Unisex Thermal Vest", Sku = "AWMUTV", Price = 95, IsAvailable = true },
                new Product { ProductId = 7, CategoryId = 1, Name = "V-Neck Pullover", Sku = "AWMVNP", Price = 65, IsAvailable = true },
                new Product { ProductId = 8, CategoryId = 1, Name = "V-Neck Sweater", Sku = "AWMVNS", Price = 65, IsAvailable = true },
                new Product { ProductId = 9, CategoryId = 1, Name = "V-Neck T-Shirt", Sku = "AWMVNT", Price = 17, IsAvailable = true },
                new Product { ProductId = 10, CategoryId = 2, Name = "Bamboo Thermal Ski Coat", Sku = "AWWBTSC", Price = 99, IsAvailable = true },
                new Product { ProductId = 11, CategoryId = 2, Name = "Cross-Back Training Tank", Sku = "AWWCTT", Price = 0, IsAvailable = false },
                new Product { ProductId = 12, CategoryId = 2, Name = "Grunge Skater Jeans", Sku = "AWWGSJ", Price = 68, IsAvailable = true },
                new Product { ProductId = 13, CategoryId = 2, Name = "Slicker Jacket", Sku = "AWWSJ", Price = 125, IsAvailable = true },
                new Product { ProductId = 14, CategoryId = 2, Name = "Stretchy Dance Pants", Sku = "AWWSDP", Price = 55, IsAvailable = true },
                new Product { ProductId = 15, CategoryId = 2, Name = "Ultra-Soft Tank Top", Sku = "AWWUTT", Price = 22, IsAvailable = true },
                new Product { ProductId = 16, CategoryId = 2, Name = "Unisex Thermal Vest", Sku = "AWWUTV", Price = 95, IsAvailable = true },
                new Product { ProductId = 17, CategoryId = 2, Name = "V-Next T-Shirt", Sku = "AWWVNT", Price = 17, IsAvailable = true },
                new Product { ProductId = 18, CategoryId = 3, Name = "Blueberry Mineral Water", Sku = "MWB", Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 19, CategoryId = 3, Name = "Lemon-Lime Mineral Water", Sku = "MWLL", Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 20, CategoryId = 3, Name = "Orange Mineral Water", Sku = "MWO", Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 21, CategoryId = 3, Name = "Peach Mineral Water", Sku = "MWP", Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 22, CategoryId = 3, Name = "Raspberry Mineral Water", Sku = "MWR", Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 23, CategoryId = 3, Name = "Strawberry Mineral Water", Sku = "MWS", Price = 2.8M, IsAvailable = true },
                new Product { ProductId = 24, CategoryId = 4, Name = "In the Kitchen with H+ Sport", Sku = "PITK", Price = 24.99M, IsAvailable = true },
                new Product { ProductId = 25, CategoryId = 5, Name = "Calcium 400 IU (150 tablets)", Sku = "SC400", Price = 9.99M, IsAvailable = true },
                new Product { ProductId = 26, CategoryId = 5, Name = "Flaxseed Oil 100 mg (90 capsules)", Sku = "SFO100", Price = 12.49M, IsAvailable = true },
                new Product { ProductId = 27, CategoryId = 5, Name = "Iron 65 mg (150 caplets)", Sku = "SI65", Price = 13.99M, IsAvailable = true },
                new Product { ProductId = 28, CategoryId = 5, Name = "Magnesium 250 mg (100 tablets)", Sku = "SM250", Price = 12.49M, IsAvailable = true },
                new Product { ProductId = 29, CategoryId = 5, Name = "Multi-Vitamin (90 capsules)", Sku = "SMV", Price = 9.99M, IsAvailable = true },
                new Product { ProductId = 30, CategoryId = 5, Name = "Vitamin A 10,000 IU (125 caplets)", Sku = "SVA", Price = 11.99M, IsAvailable = true },
                new Product { ProductId = 31, CategoryId = 5, Name = "Vitamin B-Complex (100 caplets)", Sku = "SVB", Price = 12.99M, IsAvailable = true },
                new Product { ProductId = 32, CategoryId = 5, Name = "Vitamin C 1000 mg (100 tablets)", Sku = "SVC", Price = 9.99M, IsAvailable = true },
                new Product { ProductId = 33, CategoryId = 5, Name = "Vitamin D3 1000 IU (100 tablets)", Sku = "SVD3", Price = 12.49M, IsAvailable = true });
        }
    }
}
