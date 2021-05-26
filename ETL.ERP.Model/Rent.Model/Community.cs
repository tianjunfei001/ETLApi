using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.ERP.Model.Rent.Model
{
   public class Community
    {
        public int Cid { get; set; }
        public string Cimage { get; set; }
        public DateTime Ctimes { get; set; }
        public string Cname { get; set; }
        public int Sheng { get; set; }
        public int Shi { get; set; }
        public int Qu { get; set; }
        public int? Salesum { get; set; }
        public int? Rsum { get; set; }
        public int Aveprice { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string District1 { get; set; }
        public string District2 { get; set; }

    }
}
