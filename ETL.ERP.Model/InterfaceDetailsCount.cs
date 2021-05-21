using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model 
{
    public partial class InterfaceDetailsCount
    {
        public int Id { get; set; }
        public int? InterfaceDetailsId { get; set; }
        public string CompanyName { get; set; }
        public DateTime? UseTime { get; set; }
        public int? ResponseTime { get; set; }
        public int? Seate { get; set; }
        public string Fail { get; set; }
    }
}
