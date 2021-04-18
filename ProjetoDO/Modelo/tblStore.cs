namespace StorePOS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("tblStore")]
    public partial class tblStore
    {
         public tblStore()
        {
            tblPos = new HashSet<tblPos>();
            tblStocks = new HashSet<tblStock>();
        }

        [Key]
        [StringLength(5)]
        public string fldStoreID { get; set; }

        [Required]
        [StringLength(50)]
        public string fldStore { get; set; }    

        [Required]
        [StringLength(50)]
        public string fldStoreAddress { get; set; }

        public bool? fldActive { get; set; }

        public DateTime? fldModifiedDate { get; set; }

        public DateTime? fldCreatedDate { get; set; }

         public virtual ICollection<tblPos> tblPos { get; set; }

         public virtual ICollection<tblStock> tblStocks { get; set; }
    }
}
