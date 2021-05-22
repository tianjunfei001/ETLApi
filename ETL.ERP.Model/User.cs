using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class User
    {
        public int Uid { get; set; }
        public string User_Name { get; set; }
        public string Uphone { get; set; }
        public string Upwd { get; set; }
        public int? Ustatus { get; set; }
        public DateTime? Upd_Time { get; set; }
        public DateTime? CreateTime { get; set; }

        //角色编号
        public int RId { get; set; }
        //部门
        public string Fname { get; set; }
        //职位
        public string Rname { get; set; }
    }
}
