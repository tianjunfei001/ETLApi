using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ETL.ERP.DAL;
using ETL.ERP.Model;

namespace ETL.ERP.BLL
{
    public class UserGroupBll
    {
        SqlServerHelper helper;
        public UserGroupBll(SqlServerHelper _helper)
        {
            helper = _helper;
        }
        /// <summary>
        /// 显示用户
        /// </summary>
        /// <returns></returns>
        public List<User> GetUsersList() 
        {
            string sql = $"select u.UID,u.user_name,u.Uphone,u.Ustatus,ro.Fname,ro.rname from  users as u left join users_role as ur on u.uid = ur.uid left join (select r.RID,r.rname,r.fid,re.Rname as Fname from role as r join role as re on r.FID = re.RID) as ro on ur.RId = ro.RID;";
            DataTable dt = helper.GetDataSet(sql).Tables[0];
            List<User> list = helper.DatatableTolist<User>(dt);
            return list;
        }
        //添加部门(岗位)(角色表)
        public int AddRole(string departName,int fid) 
        {
            string sql = $"insert into role values(RId,'{departName}',{(fid>0?fid:0)},1,'{DateTime.Now}','{DateTime.Now}');";
             int result = helper.ExceuteNonQuery(sql);
            return result;
        }
        /// <summary>
        ///删除用户及相关用户角色记录
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        public int DelUser(int uid) 
        {
            string sql = $"call ProcDelUser({uid})";
            int result = helper.ExceuteNonQuery(sql);
            return result;
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUser(User user) 
        {
            string sql = $"call Proc_AddUser('{user.User_Name}','{user.Uphone}',{user.Ustatus},{user.RId})";
            int result = helper.ExceuteNonQuery(sql);
            return result;
        }
        /// <summary>
        /// 修改用户信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdUser(User user)
        {
            string sql = $"call Proc_updUser('{user.User_Name}','{user.Uphone}',{user.Ustatus},{user.RId},{user.Uid});";
            int result = helper.ExceuteNonQuery(sql);
            return result;
        }
        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="Ustatus"></param>
        /// <returns></returns>
        public int UpdUserUstatus(int Uid,int Ustatus)
        {
            string sql = $"call Proc_UpdUsersStatus({Uid},{Ustatus});";
            int result = helper.ExceuteNonQuery(sql);
            return result;
        }
        /// <summary>
        /// 部门、角色显示
        /// </summary>
        /// <returns></returns>
        public List<Role> GetRolesList()
        {
            string sql = $"select * from role;";
            DataTable dt = helper.GetDataSet(sql).Tables[0];
            List<Role> list = helper.DatatableTolist<Role>(dt);
            return list;
        }


    }
}
