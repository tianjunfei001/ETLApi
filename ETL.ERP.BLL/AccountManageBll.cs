using ETL.ERP.DAL;
using ETL.ERP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ETL.ERP.BLL
{
    public class AccountManageBll
    {
        SqlServerHelper helper;
        public AccountManageBll(SqlServerHelper _helper)
        {
            helper = _helper;
        }
        //本公司信息
        public OneCompany GetOneCompany() 
        {
            string sql = $"select * from OneCompany;";
            DataTable dt =  helper.GetDataSet(sql).Tables[0];
            List<OneCompany> list = helper.DatatableTolist<OneCompany>(dt);
            return list[0];
        }
        //修改公司信息
        public int UpdOneCompanyInter(OneCompany oc) 
        {
            string sql = $"update  onecompany set onecompanyname = '{oc.OneCompanyName}',onecompanyaccount='{oc.OneCompanyAccount}',bankname='{oc.BankName}' where id={oc.Id};";
            int result =   helper.ExceuteNonQuery(sql);
            return result;
        }
    }
}
