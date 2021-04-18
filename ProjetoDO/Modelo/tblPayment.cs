namespace StorePOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tblPayment
    {
        [Key]
        public int fldPaymentID { get; set; }

        [StringLength(50)]
        //public string fldSalesNumDoc { get; set; }
        [ForeignKey("tblSale")]
        public int fldSalesID { get; set; }

        public decimal fldPaidValue { get; set; }


        [ForeignKey("tblPaymentType")]
        public int fldPaymentTypeID { get; set; }

        public DateTime? fldCreatedDate { get; set; }

        [StringLength(5)]
        public string fldStore { get; set; }

        public virtual tblSale tblSale { get; set; }
        public virtual tblPaymentType tblPaymentType { get; set; }
    }
}
