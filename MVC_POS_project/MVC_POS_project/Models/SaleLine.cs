using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_POS_project.Models
{
    public class SaleLine
    {
        public Guid Id { get; set; }
        [ForeignKey("Order")]
        public Guid OrderId { get; set; }
        public Order Order { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal UnitPrice { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal LinePrice { get; set; }
    }
}
