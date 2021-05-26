using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Invoice
    {
        public int? Id { get; set; }
        public string Order_Id { get; set; }
        public DateTime? Create_Time { get; set; }
        public int? State { get; set; }
        public string StateStr { get { return this.State == 1 ? "已开票" : "未开票"; } set { } }


        public string corporate_name { get; set; }
        public string position { get; set; }
        public string order_name { get; set; }
        public double order_money { get; set; }
    }
}
