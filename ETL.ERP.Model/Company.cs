using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ETL.ERP.Model
{
    [Table("company")]
    public partial class Company
    {
        public int id { get; set; }
        public string Represent_Name { get; set; }
        public string Phone { get; set; }
        public string Corporate_Name { get; set; }
        public DateTime? Create_Time { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Credit_Code { get; set; }
        public string Img { get; set; }
        public int? State { get; set; }
    }
}
