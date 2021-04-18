namespace StorePOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tblProduct
    {
         public tblProduct()
        {
            tblStocks = new HashSet<tblStock>();
        }

        [Key]
        public int fldProductID { get; set; }

        [StringLength(12)]
        public string fldBarcode { get; set; }

        [Required]
        [StringLength(50)]
        public string fldProductName { get; set; }

        [Required]
        [StringLength(5)]
        [ForeignKey("tblFamily")]
        public string fldFamily { get; set; }

        [StringLength(50)]
        public string fldUnitMeasure { get; set; }

        public decimal fldQtyPerUnit { get; set; }

        public decimal fldUnitPrice { get; set; }

        public bool? fldDiscontinued { get; set; }

        public DateTime? fldDateCreated { get; set; }

        public DateTime? fldDateModified { get; set; }

        public virtual tblFamily tblFamily { get; set; }

         public virtual ICollection<tblStock> tblStocks { get; set; }
    }
}
