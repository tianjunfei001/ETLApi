using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.ERP.Model
{
    public class PermissionTree
    {
        public int Id { get; set; }
        public string text { get; set; }
        public List<PermissionTree> permissionTrees = new List<PermissionTree>();
    }
}
