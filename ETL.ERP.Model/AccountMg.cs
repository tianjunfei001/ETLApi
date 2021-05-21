using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class AccountMg
    {
        public int Id { get; set; }
        public string MerchantName { get; set; }
        public string Bank { get; set; }
        public string OpenBank { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
