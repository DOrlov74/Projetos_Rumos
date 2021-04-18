namespace StorePOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tblStock
    {
        [Key]
        public int fldStockID { get; set; }

        [ForeignKey("tblProduct")]
        public int fldProductID { get; set; }

        [StringLength(5)]
        [ForeignKey("tblStore")]
        public string fldStoreID { get; set; }

        public int fldQuantity { get; set; }

        public int fldQuantityBase { get; set; }

        [StringLength(20)]
        public string fldSaleUnit { get; set; }

        public int? fldQtySaleUnit { get; set; }

        public DateTime? fldModifiedDate { get; set; }

        public DateTime? fldCreatedDate { get; set; }

        public virtual tblProduct tblProduct { get; set; }

        public virtual tblStore tblStore { get; set; }
    }
}
