namespace StorePOS
{
    using Modelo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tblUser:Person
    {
        public tblUser()
        {
            tblSales = new HashSet<tblSale>();
        }

        [Key]
        [DisplayName("POS User ID")]
        public override int Id { get => base.Id; set => base.Id = value; }

        [Required(ErrorMessage = "The Name is required")]
        [MaxLength(60)]
        [DisplayName("POS User Name")]
        public override string Name { get => base.Name; set => base.Name = value; }
        [MaxLength(120)]
        public override string Address { get => base.Address; set => base.Address = value; }
        [MaxLength(60)]
        public override string City { get => base.City; set => base.City = value; }
        [MaxLength(50)]
        public override string Email { get => base.Email; set => base.Email = value; }

        [Required]
        [StringLength(9)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        [StringLength(25)]
        public string Password { get; set; }

        public virtual ICollection<tblSale> tblSales { get; set; }
    }
}
