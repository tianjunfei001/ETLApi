using ETL.ERP.DAL;
using ETL.ERP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ETL.ERP.BLL
{
    public class LoginLogBll
    {
        SqlServerHelper helper;
        public LoginLogBll(SqlServerHelper _helper)
        {
            helper = _helper;
        }


        public List<LogLog> GetLoginLogLists() 
        {
            string sql = $"select * from log_log;";
            DataTable dt =  helper.GetDataSet(sql).Tables[0];
            List<LogLog> list = helper.DatatableTolist<LogLog>(dt);
            return list;
        }
    }
}
