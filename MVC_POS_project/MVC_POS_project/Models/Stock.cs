using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_POS_project.Models
{
    public class Stock
    {
        public Guid Id { get; set; }
        public int QuantityInStock { get; set; }
        public string CteatedBy { get; set; }
        public DateTime CteatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Store")]
        public Guid StoreID { get; set; }
        public Store Store { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
