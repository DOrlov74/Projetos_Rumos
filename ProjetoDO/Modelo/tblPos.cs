namespace StorePOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tblPos
    {
         public tblPos()
        {
            tblSales = new HashSet<tblSale>();
        }

        [Key]
        public int fldPosID { get; set; }

        [Required]
        [StringLength(5)]
        [ForeignKey("tblStore")]
        public string fldStoreID { get; set; }

        [StringLength(25)]
        public string fldStoreLocation { get; set; }

        public virtual tblStore tblStore { get; set; }

        public virtual ICollection<tblSale> tblSales { get; set; }
    }
}
