using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloPOS
{
    public class Product:Auditable
    {
        public Guid ProductId { get; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public Store Store { get; set; }
        public int Stock { get; set; }
        public decimal? Price { get; set; }
        public string ImageURL { get; set; }
        public Product(Store store, 
            string name = "N/A",
            string brand = "N/A",
            string category = "N/A",
            string description = "N/A",
            int stock = 0, 
            decimal? price = null, 
            string imageUrl = null,
            string EmployeeName = "N/A")
        {
            Name = name;
            Brand = brand;
            Category = category;
            Description = description;
            Store = store;
            Stock = stock;
            Price = price;
            ImageURL = imageUrl;
            CreatedBy = EmployeeName;
            CreatedAt = DateTime.Now;
        }
    }
}
