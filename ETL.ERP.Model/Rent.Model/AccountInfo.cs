using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.ERP.Model.Rent.Model
{
   public class AccountInfo
    {
        public int Id { get; set; }
        public string? Admin { get; set; }
        public string? Phone { get; set; }
        public string? Name { get; set; }
        public int Aid { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
