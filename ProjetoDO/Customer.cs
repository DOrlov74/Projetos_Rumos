using System;
using System.ComponentModel.DataAnnotations;

namespace Modelo { 

	public class Customer:Person
	{
        public int CustomerID { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(120)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
    }
}
