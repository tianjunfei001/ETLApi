using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class User
    {
        public int Uid { get; set; }
        public string User_Name { get; set; }
        public string Uphone { get; set; }
        public string Upwd { get; set; }
        public int? Ustatus { get; set; }
        public DateTime? Upd_Time { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
