using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVC_POS_project.Models;

namespace MVC_POS_project.ViewModels
{
    public class UserOrderViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public IEnumerable<SaleLine> Lines { get; set; }
        public Family Family { get; set; }
        public Product Product { get; set; }
    }
}
