using System;
using System.Collections.Generic;
using System.Text;
using ETL.ERP.Model.Rent.Model;
using ETL.ERP.DAL;
namespace ETL.ERP.BLL.Rent.BLL
{
   public class RentBll
    {
        SqlServerHelper DB;
        public RentBll(SqlServerHelper _DB) 
        {
            DB = _DB;
        }
        //用户登录
        public int UserLogin(Account a) 
        {
            string sql = $"SELECT * FROM Account WHERE Accoun='{a.Accoun}' and Password='{a.Password}'";
            return Convert.ToInt32(DB.ExecuteScalar(sql));
        }
    }
}
