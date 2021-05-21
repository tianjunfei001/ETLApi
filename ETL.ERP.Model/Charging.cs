using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Charging
    {
        public int Id { get; set; }
        public int? InterfaceDetailsId { get; set; }
        public string Type { get; set; }
        public int? Frequency { get; set; }
        public int? Days { get; set; }
        public int? Price { get; set; }
        public string Founder { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
