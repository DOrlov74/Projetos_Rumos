namespace StorePOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblFamily
    {
         public tblFamily()
        {
            tblProducts = new HashSet<tblProduct>();
        }

        [Key]
        [StringLength(5)]
        public string fldFamilyID { get; set; }

        [StringLength(50)]
        public string fldFamily { get; set; }

         public virtual ICollection<tblProduct> tblProducts { get; set; }
    }
}
