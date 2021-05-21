using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Permission
    {
        public int Pid { get; set; }
        public string Title { get; set; }
        public int? Fid { get; set; }
        public string Action { get; set; }
        public DateTime? UpdTime { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
