using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Company
    {
        public int Id { get; set; }
        public string RepresentName { get; set; }
        public string Phone { get; set; }
        public string CorporateName { get; set; }
        public DateTime? CreateTime { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string CreditCode { get; set; }
        public string Img { get; set; }
        public int? State { get; set; }
    }
}
