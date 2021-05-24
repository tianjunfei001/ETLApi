using ETL.ERP.DAL;
using ETL.ERP.Model.Rent.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ETL.ERP.BLL
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

        //用户注册
        public int Userregister(Account a) 
        {
            string sql = $"Call Userregister ('{a.Accoun}','{a.Password}')";
            return DB.ExceuteNonQuery(sql);
        }


        //用户个人信息显示
        public List<AccountInfo> Userdisplay(int Aid) 
        {
            string sql = $"SELECT * FROM AccountInfo WHERE Aid={Aid}";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<AccountInfo>(set.Tables[0]);
        }

        //用户修改密码
        public int UpdUserPassword(Account a) 
        {
            string sql = $"UPDATE Account SET Password='{a.Password}' WHERE Aid={a.Aid}";
            return DB.ExceuteNonQuery(sql);
        }

        //用户修改个人信息
        public int UpdUser(AccountInfo a) 
        {
            string sql = $"UPDATE AccountInfo SET Admin='{a.Admin}',Phone='{a.Phone}',Name='{a.Name}',UpdateTime=NOW() WHERE Aid={a.Aid}";
            return DB.ExceuteNonQuery(sql);
        }

        //商户个人信息显示
        public List<MerchantInfo> Merchantdisplay(int Mid)
        {
            string sql = $"SELECT * FROM MerchantInfo WHERE Mid={Mid}";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<MerchantInfo>(set.Tables[0]);
        }

        //商户登录
        public int MerchatLogin(Merchant m)
        {
            string sql = $"SELECT * FROM Merchant WHERE Accoun='{m.Accoun}' and Password='{m.Password}'";
            return Convert.ToInt32(DB.ExecuteScalar(sql));
        }

        //商户注册
        public int Merchatregister(Merchant m) 
        {
            string sql = $"Call Merchantregister ('{m.Accoun}','{m.Password}')";
            return DB.ExceuteNonQuery(sql);
        }


        //商户修改密码
        public int UpdMerchantPassword(Merchant m)
        {
            string sql = $"UPDATE Merchant SET Password='{m.Password}' WHERE Mid={m.Mid}";
            return DB.ExceuteNonQuery(sql);
        }

        //商户修改个人信息
        public int UpdMerchant(MerchantInfo m)
        {
            string sql = $"UPDATE MerchantInfo SET Admin='{m.Admin}',Phone='{m.Phone}',Name='{m.Name}',UpdateTime=NOW() WHERE Mid={m.Mid}";
            return DB.ExceuteNonQuery(sql);
        }

        //管理员登录
        public int AdministratorsLogin(Administrators a)
        {
            string sql = $"SELECT * FROM Administrators WHERE Accoun='{a.Accoun}' and Password='{a.Password}'";
            return Convert.ToInt32(DB.ExecuteScalar(sql));
        }


        //房源类型显示

        public List<TypesHousing> TypesHousingdisplay() 
        {
            string sql = $"SELECT * FROM TypesHousing Where Zt='启用'";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<TypesHousing>(set.Tables[0]);
        }

        //房源类型状态修改
        public int UpdTypesHousing(int Hid) 
        {
            string sql = $"UPDATE TypesHousing SET Zt='禁用' WHERE Hid={Hid}";
            return DB.ExceuteNonQuery(sql);
        }

        //省显示
        public List<Area> Shengdisplay() 
        {
            string sql = $"SELECT * FROM Area WHERE Level=1";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Area>(set.Tables[0]);
        }

        //市显示
        public List<Area> Shidisplay() 
        {
            string sql = $"SELECT * FROM Area WHERE Level=2";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Area>(set.Tables[0]);
        }

        //区显示
        public List<Area> Qudisplay()
        {
            string sql = $"SELECT * FROM Area WHERE Level=3";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Area>(set.Tables[0]);
        }
    }
}
