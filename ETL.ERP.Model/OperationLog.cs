using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class OperationLog
    {
        public int Id { get; set; }
        public string User_Name { get; set; }
        public string Phone { get; set; }
        public DateTime? Create_Time { get; set; }
        public string Ipadds { get; set; }
        public string Content { get; set; }
    }
}
