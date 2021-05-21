using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Orderlist
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int? CompanyId { get; set; }
        public string OrderName { get; set; }
        public string Phone { get; set; }
        public double? OrderMoney { get; set; }
        public int? PrePaid { get; set; }
        public int? PayWay { get; set; }
        public DateTime? CreateTime { get; set; }
        public int? State { get; set; }
    }
}
