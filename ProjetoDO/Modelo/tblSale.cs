namespace StorePOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tblSale
    {
         public tblSale()
        {
            tblSalesDetails = new HashSet<tblSalesDetail>();
        }

        [Key]
        public int fldSalesID { get; set; }

        [StringLength(20)]
        public string fldSalesDocNum { get; set; }

        [StringLength(5)]
        public string fldStore { get; set; }

        [ForeignKey("tblPOS")]
        public int fldPOSnum { get; set; }

        [ForeignKey("tblUser")]
        public int fldPOSUser { get; set; }

        public DateTime? fldDateCreated { get; set; }

        public DateTime? fldDatemodified { get; set; }

        public bool? fldPaid { get; set; }

        public int fldCUstomer { get; set; }

        public virtual tblPos tblPos { get; set; }

        public virtual ICollection<tblSalesDetail> tblSalesDetails { get; set; }

        public virtual tblUser tblUser { get; set; }

        public virtual ICollection<tblPayment> tblPayments { get; set; }
    }
}
