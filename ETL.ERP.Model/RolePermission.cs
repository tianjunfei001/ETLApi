using System;
using System.Collections.Generic;

#nullable disable

namespace ETL.ERP.Model
{
    public partial class RolePermission
    {
        public int RpId { get; set; }
        public int PermissionId { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
