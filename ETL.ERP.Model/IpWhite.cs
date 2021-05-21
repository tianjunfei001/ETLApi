using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class IpWhite
    {
        public int Id { get; set; }
        public int? CompanyId { get; set; }
        public string Ip { get; set; }
        public string Founder { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? State { get; set; }
    }
}
