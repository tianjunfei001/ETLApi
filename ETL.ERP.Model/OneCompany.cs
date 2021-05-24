using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.ERP.Model
{
    public class OneCompany
    {
        public int Id { get; set; }
        public string OneCompanyName { get; set; }
        public string Creator { get; set; }
        public string OneCompanyAddress { get; set; }
        public string BankName { get; set; }
        public string OneCompanyAccount { get; set; }
        public string OneCompanyPhone { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
