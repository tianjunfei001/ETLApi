using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETL.ERP.BLL;
using ETL.ERP.Model;
using Microsoft.AspNetCore.Mvc;

namespace ETLSystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSetupController : Controller
    {
        UserGroupBll userGroupBll;
        public SystemSetupController(UserGroupBll _userGroupBll) 
        {
            userGroupBll = _userGroupBll;
        }
        /// <summary>
        /// 用户组显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetUsersList")]
        public IActionResult GetUsersList()
        {
            List<User> list;
            try
            {
                list = userGroupBll.GetUsersList();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(new { code=0,data=list,count=list.Count});
        }
        /// <summary>
        /// 添加部门/岗位
        /// </summary>
        /// <param name="departName"></param>
        /// <param name="fid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRole")]
        public IActionResult AddRole(string departName, int fid)
        {
            int result;
            try
            {
                result = userGroupBll.AddRole(departName, fid);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(new { msg = result>0?"操作成功":"操作失败",state=result>0?true:false });
        }
        /// <summary>
        /// 删除用户及相关信息
        /// </summary>
        /// <param name="uid"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DelUser")]
        public IActionResult DelUser(int uid)
        {
            int result;
            try
            {
                result = userGroupBll.DelUser(uid);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(new { msg = result > 0 ? "操作成功" : "操作失败", state = result > 0 ? true : false });
        }
        /// <summary>
        /// 添加用户及相关信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            int result;
            try
            {
                result = userGroupBll.AddUser(user);
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(new { msg = result > 0 ? "操作成功" : "操作失败", state = result > 0 ? true : false });
        }
        /// <summary>
        /// 修改用户及相关信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdUser")]
        public IActionResult UpdUser(User user)
        {
            int result;
            try
            {
                result = userGroupBll.UpdUser(user); 
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(new { msg = result > 0 ? "操作成功" : "操作失败", state = result > 0 ? true : false });
        }
        /// <summary>
        /// 修改用户状态
        /// </summary>
        /// <param name="Uid"></param>
        /// <param name="Ustatus"></param>
        /// <returns></returns>
        [HttpPost][Route("UpdUsersUstatus")]
        public IActionResult UpdUsersUstatus(int Uid,int Ustatus) 
        {
            int result;
            try
            {
                result = userGroupBll.UpdUserUstatus(Uid, Ustatus);
            }
            catch (Exception)
            {

                throw;
            }
            return Ok(new {state=result>0?true:false,data=result>0?"操作成功":"操作失败"});
        }

        /// <summary>
        /// 部门、角色显示
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        [HttpGet][Route("SearchRole")]
        public IActionResult SearchRole(int fid) 
        {
            List<Role> list;
            try
            {
                list = userGroupBll.GetRolesList();
                list = list.Where(r => r.Fid == fid).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Ok(new { code=0,data=list,msg=""});
        }

    }
}
