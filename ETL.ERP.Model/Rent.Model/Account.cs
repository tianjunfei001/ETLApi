using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.ERP.Model.Rent.Model
{
   public class Account
    {
        public int Aid { get; set; }
        public string Accoun { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
