using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Classification
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescribe { get; set; }
        public string Founder { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? Number { get; set; }
        public int? TotalTimes { get; set; }
    }
}
