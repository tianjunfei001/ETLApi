using System;
using System.Collections.Generic;
using System.Text;
using ETL.ERP.DAL;
using ETL.ERP.Model;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace ETL.ERP.BLL
{
    public class Ceshi
    {

        SqlServerHelper helper;
        public Ceshi(SqlServerHelper _helper)
        {
            helper = _helper;
        }



        public List<User> GetShow()
        {
            string sql = "SELECT * FROM `users`;";
            DataSet dataSet = helper.GetDataSet(sql);

            List<User> su = helper.DatatableTolist<User>(dataSet.Tables[0]);
            return su;

        }


    }
}
