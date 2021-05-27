using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class OperationLog
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public DateTime? Create_Time { get; set; }
        public string Ipadds { get; set; }
        public string Content { get; set; }

        //user
        public string user_name { get; set; }
        public string Uphone { get; set; }
    }
}
