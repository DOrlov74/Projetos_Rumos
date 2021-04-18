using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_POS_project.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        [Required]
        public string DocNumber { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal TotalPrice { get; set; }
        public bool Paid { get; set; }
        public DateTime CteatedAt { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<SaleLine> SaleLines { get; set; }
    }
}
