using StorePOS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo { 

	public class Customer:Person
	{
        [Key]
        [DisplayName("Customer ID")]
        public override int Id { get => base.Id; set => base.Id = value; }
        [Required(ErrorMessage = "The Name is required")]
        [MaxLength(60)]
        [DisplayName("Customer Name")]
        public override string Name { get => base.Name; set => base.Name = value; }
        [MaxLength(120)]
        public override string Address { get => base.Address; set => base.Address = value; }
        [MaxLength(50)]
        public override string City { get => base.City; set => base.City = value; }
        [MaxLength(50)]
        public override string Email { get => base.Email; set => base.Email = value; }
        [Required(ErrorMessage = "The NIF is required")]
        [MaxLength(9)]
        public string NIF { get; set; }
        public virtual ICollection<tblSale> tblSales { get; set; }
    }
}
