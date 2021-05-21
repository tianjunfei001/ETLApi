using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class InterfaceDetail
    {
        public int Id { get; set; }
        public string IntDeName { get; set; }
        public string IntDeDescribe { get; set; }
        public string Img { get; set; }
        public string Source { get; set; }
        public int? Cycle { get; set; }
        public int? Count { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
