namespace StorePOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tblSalesDetail
    {
        [Key]
        public int fldSalesDetailID { get; set; }

        [ForeignKey("tblSale")]
        public int fldSalesID { get; set; }

        public int fldSeq { get; set; }

        public int fldProduct { get; set; }

        public int fldQuantity { get; set; }

        public int fldUnitPrice { get; set; }

        public decimal fldLineTotal { get; set; }

        public DateTime? fldDateCreated { get; set; }

        public virtual tblSale tblSale { get; set; }
    }
}
