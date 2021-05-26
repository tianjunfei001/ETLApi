using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class Orderlist
    {
        public int Id { get; set; }
        public string Order_Code { get; set; }
        public int? Company_Id { get; set; }
        public string Order_Name { get; set; }
        public string Phone { get; set; }
        public double? Order_Money { get; set; }
        public int? Pre_Paid { get; set; }
        public int? Pay_Way { get; set; }
        public DateTime? Create_Time { get; set; }
        public int? State { get; set; }
    }
}
