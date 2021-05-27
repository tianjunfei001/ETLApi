using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class LogLog
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public DateTime? Create_Time { get; set; }
        public int? Log_Seate { get; set; }
        public string Log_LP { get; set; }
        public string Log_City { get; set; }


        //user
        public string user_name { get; set; }
        public string Uphone { get; set; }
    }
}
