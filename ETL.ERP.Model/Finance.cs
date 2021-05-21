using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Finance
    {
        public int Id { get; set; }
        public int? Type { get; set; }
        public double? Money { get; set; }
        public string CompanyName { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
