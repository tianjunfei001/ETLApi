using ETL.ERP.DAL;
using ETL.ERP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ETL.ERP.BLL
{
    public class SystemLogBll
    {
        SqlServerHelper helper;
        public SystemLogBll(SqlServerHelper _helper)
        {
            helper = _helper;
        }
        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<OperationLog> GetOperationLogs(int uid) 
        {
            string sql = $"select * from operation_log o join users u on o.uid = u.uid where o.uid={uid};";
            DataSet ds = helper.GetDataSet(sql);
            List<OperationLog> list = helper.DatatableTolist<OperationLog>(ds.Tables[0]);
            return list;
        }
        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public List<LogLog> GetLogLogs(int uid) 
        {
            string sql = $"select * from log_log l join users u on l.uid = u.uid where l.uid={uid}";
            DataSet ds = helper.GetDataSet(sql);
            List<LogLog> list = helper.DatatableTolist<LogLog>(ds.Tables[0]);
            return list;
        }
    }
}
