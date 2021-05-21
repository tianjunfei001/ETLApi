using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class InterfaceRule
    {
        public int Id { get; set; }
        public int? InterfaceDetailsId { get; set; }
        public string RuleName { get; set; }
        public string RuleCode { get; set; }
        public string RuleDescribe { get; set; }
        public string Founder { get; set; }
        public int? State { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
