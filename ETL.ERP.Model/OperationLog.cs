using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class OperationLog
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Phone { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Ipadds { get; set; }
        public string Content { get; set; }
    }
}
