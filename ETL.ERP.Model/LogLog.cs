using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class LogLog
    {
        public int Id { get; set; }
        public string User_Name { get; set; }
        public string Phone { get; set; }
        public DateTime? Create_Time { get; set; }
        public int? Log_Seate { get; set; }
        public string Log_LP { get; set; }
        public string Log_City { get; set; }
    }
}
