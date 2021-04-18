using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_POS_project.Models
{
    public class Family
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public IEnumerable<Product> Products { get; set; }  
    }
}
