using ETL.ERP.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using ETL.ERP.Model;
using System.Data;

namespace ETL.ERP.BLL
{
    public class OperationLogBll
    {
        SqlServerHelper helper;
        public OperationLogBll(SqlServerHelper _helper)
        {
            helper = _helper;
        }

         public List<OperationLog> GetLoginLogLists()
        {
            string sql = $"select * from operation_log o join users u on o.uid = u.uid;";
            DataTable dt = helper.GetDataSet(sql).Tables[0];
            List<OperationLog> list = helper.DatatableTolist<OperationLog>(dt);
            return list;
        }
    }
}
