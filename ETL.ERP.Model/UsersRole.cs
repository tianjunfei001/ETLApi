using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class UsersRole
    {
        public int UrId { get; set; }
        public int Uid { get; set; }
        public int Rid { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
