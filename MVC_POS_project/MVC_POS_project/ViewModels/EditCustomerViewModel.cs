using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_POS_project.ViewModels
{
    public class EditCustomerViewModel
    {
        public string Id { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }

        public string Address { get; set; }
        public string NIF { get; set; }
        public string PhoneNumber { get; set; }
    }
}
