using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Configure
    {
        public int Id { get; set; }
        public int? ClassificationId { get; set; }
        public string ConfigureName { get; set; }
        public string ConfigureDescribe { get; set; }
        public string Plan { get; set; }
        public string MainInterface { get; set; }
        public string SlaveInterface { get; set; }
        public string SecondaryInterface { get; set; }
        public string Founder { get; set; }
        public DateTime? CreateTime { get; set; }
        public string SwitchingRules { get; set; }
        public string Rule { get; set; }
        public string RuleAllocation { get; set; }
    }
}
