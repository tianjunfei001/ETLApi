using ETL.ERP.DAL;
using ETL.ERP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ETL.ERP.BLL
{
    public class InvoiceBll
    {


        SqlServerHelper helper;
        public InvoiceBll(SqlServerHelper _helper)
        {
            helper = _helper;
        }
        //发票列表
        public List<Invoice> GetInvoicesList() 
        {
            string sql = $"select i.id,i.order_id,c.corporate_name,c.position,o.order_name,o.order_money,o.create_time,i.state from  invoice  as i  left join  orderlist as o on o.order_code=i.order_id left join company c on o.company_id=c.id;";
            DataTable dt =  helper.GetDataSet(sql).Tables[0];
            List<Invoice> list = helper.DatatableTolist<Invoice>(dt);
            return list;
        }
        //修改发票表状态
        public int UpdInvoiceState(int id,int State) 
        {
            string sql = $"update invoice set state = {State} where id={id};";
            int result= helper.ExceuteNonQuery(sql);
            return result;
        }

        
    }
}
