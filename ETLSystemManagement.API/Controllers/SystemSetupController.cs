using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETL.ERP.BLL;
using ETL.ERP.Model;
using log4net;
using Microsoft.AspNetCore.Mvc;

namespace ETLSystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemSetupController : Controller
    {
        UserGroupBll userGroupBll;
        LoginLogBll loginLogBll;
        OperationBll operationBll;
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(SystemSetupController));
        public SystemSetupController(UserGroupBll _userGroupBll, LoginLogBll _loginLogBll, OperationBll _operationBll) 
        {
            userGroupBll = _userGroupBll;
            loginLogBll = _loginLogBll;
            operationBll = _operationBll;
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
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
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { code=0,data=list,msg=""});
        }

        List<PermissionTree> treeModels = new List<PermissionTree>();
        /// <summary>
        /// 待测试
        /// </summary>
        /// <param name="fid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ParseTree")]
        public IActionResult ParseTree(int? fid)
        {
            //找当前层级下级(如果parentId==null那就是第一级)
            
            List<Permission> permissions = userGroupBll.GetPermissionList();
            List<Permission> list = permissions.Where(a => a.Fid == fid).ToList();
            foreach (var item in list)
            {
                PermissionTree treeModel = new PermissionTree();
                treeModel.Id = item.Pid;
                treeModel.text = item.Title;
                //递归
                ParseTree(treeModel.Id);
                treeModels.Add(treeModel);
            }
            return Ok(new { data= treeModels });
        }

        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="time"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetLoginLogList")]
        public IActionResult GetLoginLogList(DateTime? time,int page,int limit) 
        {
            List<LogLog> list;
            List<LogLog> _list;
            try
            {
                list = loginLogBll.GetLoginLogLists();
                if (Convert.ToString(time) != "")
                {
                    list = list.Where(l => l.Create_Time == time).ToList();
                }
                _list = list.Skip((page - 1) * limit).Take(limit).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { code = 0, data = _list, count = list.Count });
        }
        /// <summary>
        /// 操作日志显示
        /// </summary>
        /// <param name="time"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetOperationLogList")]
        public IActionResult GetOperationLogList(DateTime? time, int page, int limit)
        {
            List<OperationLog> list ;
            List<OperationLog> _list ;
            try
            {
                list = operationBll.GetLoginLogLists();
                if (Convert.ToString(time) != "")
                {
                    list = list.Where(l => l.Create_Time == time).ToList();
                }
                _list = list.Skip((page - 1) * limit).Take(limit).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { code = 0, data = _list, count = list.Count });
        }


    }
}
