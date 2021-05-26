using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.ERP.Model.Rent.Model
{
   public class Appointmentdisplay
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public int Nid { get; set; }
        public DateTime CreateTime { get; set; }
        public string Zt { get; set; }

        public int Nid1 { get; set; }
        public int Cid { get; set; }
        public int Hid { get; set; }
        public string? Name { get; set; }
        public string? Housetype { get; set; }
        public string? Developers { get; set; }
        public string? Propertyfirm { get; set; }
        public int? Propertyyear { get; set; }
        public string? Region { get; set; }
        public int? Floorage { get; set; }
        public int? Price { get; set; }
        public string? Discounts { get; set; }
        public string? States { get; set; }
        public string? Decoration { get; set; }
        public DateTime? Updatetime { get; set; }
        public int? FMonthlyRent { get; set; }
    }
}
