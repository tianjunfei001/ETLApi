using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Role
    {
        public int Rid { get; set; }
        public string Rname { get; set; }
        public int? Fid { get; set; }
        public int? Rstatus { get; set; }
        public DateTime? UpdTime { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
