using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Invoice
    {
        public int? Id { get; set; }
        public int? OrderId { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? State { get; set; }
    }
}
