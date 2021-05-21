using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class LogLog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? LogSeate { get; set; }
        public string LogLP { get; set; }
        public string LogCity { get; set; }
    }
}
