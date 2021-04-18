namespace StorePOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

     public partial class tblPaymentType
    {
         public tblPaymentType()
        {
            tblPayments = new HashSet<tblPayment>();
        }

        [Key]
        public int fldPaymentTypeID { get; set; }

        [StringLength(20)]
        public string fldPaymentType { get; set; }

        public virtual ICollection<tblPayment> tblPayments { get; set; }
    }
}
