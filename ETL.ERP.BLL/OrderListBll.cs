using ETL.ERP.DAL;
using ETL.ERP.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ETL.ERP.BLL
{
    public class OrderListBll
    {
        SqlServerHelper helper;
        public OrderListBll(SqlServerHelper _helper)
        {
            helper = _helper;
        }
        /// <summary>
        /// 显示订单列表
        /// </summary>
        /// <returns></returns>
        public List<Orderlist> GetOrderlists() 
        {
            string sql = $"select * from orderlist;";
            DataTable dt = helper.GetDataSet(sql).Tables[0];
            List<Orderlist> list = helper.DatatableTolist<Orderlist>(dt);
            return list;
        }

        //审核订单
        public int UpdOrderlistState(int id, int State)
        {
            string sql = $"update orderlist set state = {State} where id={id};";
            int result = helper.ExceuteNonQuery(sql);
            return result;
        }
    }
}
