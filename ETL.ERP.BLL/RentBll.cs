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

        //小区显示
        public List<Community> Communitydisplay(int Sheng,int Shi,int Qu)
        {
            string sql = $"SELECT a.*,b.District,c.District,d.District FROM Community a JOIN Area b ON a.Sheng=b.Id JOIN Area c ON a.Shi=c.Id JOIN Area d ON a.Qu=d.Id where 1=1";
            
            if (Sheng > 0) 
            {
                sql += $" and a.Sheng={Sheng}";
            }
            if (Shi > 0)
            {
                sql += $" and a.Shi={Shi}";
            }
            if (Qu > 0)
            {
                sql += $" and a.Qu={Qu}";
            }


            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Community>(set.Tables[0]);
        }

        //房源信息显示
        public List<House> Housedisplay(int Hid,int Sheng, int Shi, int Qu) 
        {
            string sql = $"SELECT e.*,b.District,c.District,d.District FROM Community a JOIN Area b ON a.Sheng=b.Id JOIN Area c ON a.Shi=c.Id JOIN Area d ON a.Qu=d.Id JOIN House e ON a.Cid = e.Cid WHERE 1 = 1";
            if (Hid>0)
            {
                sql += $" and Hid={Hid}";
            }
            if (Sheng > 0)
            {
                sql += $" and a.Sheng={Sheng}";
            }
            if (Shi > 0)
            {
                sql += $" and a.Shi={Shi}";
            }
            if (Qu > 0)
            {
                sql += $" and a.Qu={Qu}";
            }
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<House>(set.Tables[0]);
        }

        //用户资讯信息显示
        public List<Informationsheet> Informationsheetdisplay() 
        {
            string sql = $"SELECT * FROM Informationsheet WHERE State='启用'";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Informationsheet>(set.Tables[0]);
        }

        //后台资讯信息显示
        public List<Informationsheet> Infordisplay() 
        {
            string sql = $"SELECT * FROM Informationsheet";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Informationsheet>(set.Tables[0]);
        }

        //后台资讯信息审核
        public int UpdInforZt(int Id) 
        {
            string sql = $"UPDATE Informationsheet SET State='已审核' WHERE Id={Id}";
            return DB.ExceuteNonQuery(sql);
        }

        //后台资讯信息添加
        public int InsertInformationsheet(Informationsheet i)
        {
            string sql = $"INSERT INTO Informationsheet VALUES(NULL, '{i.Image}', '{i.Title}', '{i.Contont}', {i.Views}, NOW(), {i.Nid}, '未审核')";
            return DB.ExceuteNonQuery(sql);
        }

        //后台资讯信息修改
        public int UpdInformationsheet(Informationsheet i) 
        {
            string sql = $"UPDATE Informationsheet SET Image='{i.Image}',Title='{i.Title}',Contont='{i.Contont}',Releasetime=NOW(),State='禁用' WHERE Id={i.Id}";
            return DB.ExceuteNonQuery(sql);
        }

        //后台资讯信息删除
        public int DeleteInfor(string ids) 
        {
            string sql = $"DELETE FROM Informationsheet WHERE Id in({ids})";
            return DB.ExceuteNonQuery(sql);
        }

        //用户预约
        public int InsertAppointment(Appointment a) 
        {
            string sql = $"INSERT INTO Appointment VALUES(Null, {a.Uid}, {a.Nid}, '{a.CreateTime}', '预约中')";
            return DB.ExceuteNonQuery(sql);
        }

        //后台显示用户预约
        public List<Appointment> Appointmentdisplay() 
        {
            string sql = $"SELECT * FROM Appointment";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Appointment>(set.Tables[0]);
        }

        //后台用户预约审核
        public int UpdAppointment(int Id) 
        {
            string sql = $"UPDATE Appointment SET Zt='预约成功' WHERE Id={Id}";
            return DB.ExceuteNonQuery(sql);
        }

        //用户预约显示
        public List<Appointmentdisplay> display(int Uid) 
        {
            string sql = $"SELECT * FROM Appointment a JOIN House b ON a.Nid=b.Nid WHERE a.Nid IN(SELECT Nid FROM Appointment WHERE Uid={Uid})";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Appointmentdisplay>(set.Tables[0]);
        }

        //用户预约修改
        public int UpdateAppointment(Appointment a) 
        {
            string sql = $"UPDATE Appointment SET Nid={a.Nid},CreateTime='{a.CreateTime}','预约中',WHERE Id={a.Id}";
            return DB.ExceuteNonQuery(sql);
        }

        //用户取消预约
        public int CancelAppointment(int Id) 
        {
            string sql =$"UPDATE Appointment SET Zt='取消预约' WHERE Id={Id}";
            return DB.ExceuteNonQuery(sql);
        }

        //用户收藏
        public int AddCollection(Collection c) 
        {
            string sql = $"INSERT INTO Collection VALUES(NULL, {c.Uid}, {c.Nid}, NOW())";
            return DB.ExceuteNonQuery(sql);
        }

        //用户删除收藏
        public int DelCollection(string ids) 
        {
            string sql = $"DELETE FROM Collection WHERE Id IN({ids})";
            return DB.ExceuteNonQuery(sql);
        }

        //用户收藏显示
        public List<Collectiondisplay> Collectdisplay(int Uid) 
        {
            string sql = $"SELECT * FROM Collection a JOIN House b ON a.Nid=b.Nid WHERE a.Nid IN(SELECT Nid FROM Collection WHERE Uid={Uid}) ";
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Collectiondisplay>(set.Tables[0]);
        }

        //后台收藏显示
        public List<Collection> Colldisplay(int Uid) 
        {
            
            string sql = $"SELECT * FROM Collection Where 1=1";
            if (Uid!=0)
            {
                sql += $" and Uid={Uid}";
            }
            var set = DB.GetDataSet(sql);
            return DB.DatatableTolist<Collection>(set.Tables[0]);
        } 
    }
}
