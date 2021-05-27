using ETL.ERP.DAL;
using ETL.ERP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ETL.ERP.BLL
{
    public class InvoiceInformationBll
    {

        SqlServerHelper helper;
        public InvoiceInformationBll(SqlServerHelper _helper)
        {
            helper = _helper;
        }
        /// <summary>
        /// 显示发票信息列表
        /// </summary>
        /// <returns></returns>
        public List<Company> GetUserlist()
        {
            try
            {
                string sql = $"select * from   invoice i join orderlist o on i.order_id = o.order_code left join company c on o.company_id = c.id;";
                DataSet ds = helper.GetDataSet(sql);
                List<Company> list = helper.DatatableTolist<Company>(ds.Tables[0]);
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// 删除发票信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeInvoice(int id)
        {
            try
            {
                string sql = $"call Proc_DelInvoice({id})";
                return helper.ExceuteNonQuery(sql);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
