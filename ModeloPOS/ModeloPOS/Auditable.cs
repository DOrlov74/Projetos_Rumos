using System;
using System.Collections.Generic;
using System.Text;

namespace ModeloPOS
{
    public class Auditable
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}
