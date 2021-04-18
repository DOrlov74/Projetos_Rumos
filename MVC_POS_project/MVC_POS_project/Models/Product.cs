using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_POS_project.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey("Family")]
        public Guid FamilyId { get; set; }
        public Family Family { get; set; }
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public string CteatedBy { get; set; } 
        public DateTime CteatedAt { get; set; } = DateTime.UtcNow;
        public IEnumerable<Stock> Stocks { get; set; }
        public IEnumerable<SaleLine> SaleLines { get; set; }
    }
}
