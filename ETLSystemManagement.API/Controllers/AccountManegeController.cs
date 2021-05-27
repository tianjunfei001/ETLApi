using ETL.ERP.BLL;
using ETL.ERP.DAL;
using ETL.ERP.Model;
using ETL.ERP.ThirdParty;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountManegeController : Controller
    {
        InvoiceInformationBll invoiceInformationBll;
        SystemLogBll systemLogBll;
        SqlServerHelper sqlServerHelper;

        public AccountManegeController(InvoiceInformationBll _invoiceInformationBll, SystemLogBll _systemLogBll, SqlServerHelper _sqlServerHelper) 
        {
            invoiceInformationBll = _invoiceInformationBll;
            systemLogBll = _systemLogBll;
            sqlServerHelper = _sqlServerHelper;
        }
        //报错日志
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(FinanceManageController));
        /// <summary>
        /// 显示发票信息
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInvoiceList")]
        public IActionResult GetInvoiceList(int uid, int page = 1, int limit = 1)
        {
            List<Company> list;
            try
            {
                list = invoiceInformationBll.GetUserlist();
                list = list.Where(l => l.uid == uid).ToList();
                var _list = list.Skip((page - 1) * limit).Take(limit).ToList();
                return Ok(new { code = 0, data = _list, count = list.Count });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 删除发票信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("DelInvoice")]
        public IActionResult DelInvoice(int id)
        {
            try
            {
                int result = invoiceInformationBll.DeInvoice(id);
                return Ok(new { state = result > 0 ? true : false, data = result > 0 ? "删除成功" : "删除失败" });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 操作日志
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetOperationLogs")]
        public IActionResult GetOperationLogs(int uid,DateTime? BeginTime,DateTime? EndTime, int page = 1, int limit = 1) 
        {
            try
            {
                List<OperationLog> list = systemLogBll.GetOperationLogs(uid);
                if (Convert.ToString(BeginTime) !="") 
                {
                    list = list.Where(l => l.Create_Time >= BeginTime).ToList();
                }
                if (Convert.ToString(EndTime) != "")
                {
                    list = list.Where(l => l.Create_Time <= EndTime).ToList();
                }
                var _list = list.Skip((page - 1) * limit).Take(limit).ToList();
                return Ok(new {code=0,data=_list,count=list.Count });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 登录日志
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="BeginTime"></param>
        /// <param name="EndTime"></param>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("GetLogLogs")]
        public IActionResult GetLogLogs(int uid, DateTime? BeginTime,DateTime? EndTime, int page = 1, int limit = 1)
        {
            try
            {
                List<LogLog> list = systemLogBll.GetLogLogs(uid);
                if (Convert.ToString(BeginTime) != "")
                {
                    list = list.Where(l => l.Create_Time >= BeginTime).ToList();
                }
                if (Convert.ToString(EndTime) != "")
                {
                    list = list.Where(l => l.Create_Time <= EndTime).ToList();
                }
                var _list = list.Skip((page - 1) * limit).Take(limit).ToList();
                return Ok(new { code = 0, data = _list, count = list.Count });
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 导出登录日志
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OutLogLogsExcel")]
        public IActionResult OutLogLogsExcel(int uid)
        {
            string sql = $"select l.id,l.uid,l.Create_Time,l.Log_Seate,l.Log_LP,l.Log_City from log_log l join users u on l.uid = u.uid where l.uid={uid};";
            DataSet ds = sqlServerHelper.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            var stream = GetHelper.ExcelOut(dt);
            var type = "application/ectet-stream";
            var filename = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.xls";
            return File(stream.ToArray(), type, filename);
        }
        /// <summary>
        /// 导出操作日志
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OutOperationLogsExcel")]
        public IActionResult OutOperationLogsExcel(int uid)
        {
            string sql = $"select o.id,u.user_name,o.Create_Time,o.Ipadds,o.Content from operation_log o join users u on o.uid = u.uid where o.uid={uid};";
            DataSet ds = sqlServerHelper.GetDataSet(sql);
            DataTable dt = ds.Tables[0];
            var stream = GetHelper.ExcelOut(dt);
            var type = "application/ectet-stream";
            var filename = $"{DateTime.Now.ToString("yyyyMMddhhmmss")}.xls";
            return File(stream.ToArray(), type, filename);
        }
    }
}
