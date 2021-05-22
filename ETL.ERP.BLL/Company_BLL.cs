using System;
using System.Collections.Generic;
using System.Text;
using ETL.ERP.DAL;

namespace ETL.ERP.BLL
{
    public class Company_BLL:BaseBLL
    {

        SqlServerHelper Helper;

        //构造
        public Company_BLL(SqlServerHelper helper) : base(helper)
        {
            Helper = helper;
        }

        /// <summary>
        /// 小修改审核状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int GetStateUpdCompany(int id,int state)
        {
            string sql = $"call ProcCompany_state({id},{state})";

            return Helper.ExceuteNonQuery(sql);
        }




    }
}
