using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC_POS_project.Models
{
    public class Customer:IdentityUser
    {
        public string Address { get; set; }
        public string NIF { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
