using ETL.ERP.BLL;
using ETL.ERP.Model;
using log4net;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinanceManageController : Controller
    {
        OrderListBll orderListBll;
        InvoiceBll invoiceBll;
        AccountManageBll accountManageBll;

        //报错日志
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(FinanceManageController));
        public FinanceManageController(OrderListBll _orderListBll, InvoiceBll _invoiceBll, AccountManageBll _accountManageBll)
        {
            orderListBll = _orderListBll;
            invoiceBll = _invoiceBll;
            accountManageBll = _accountManageBll;
        }
        /// <summary>
        /// 订单列表
        /// </summary>
        /// <param name="begintime"></param>
        /// <param name="endtime"></param>
        /// <param name="ordercode"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrderLists")]
        public IActionResult GetOrderLists(DateTime? begintime,DateTime? endtime,string ordercode)
        {
            List<Orderlist> list;
            try
            {
                list = orderListBll.GetOrderlists();
                if (Convert.ToString(begintime) != "")
                {
                    list = list.Where(l => l.Create_Time > begintime).ToList();
                }
                if (Convert.ToString(endtime) != "")
                {
                    list = list.Where(l => l.Create_Time < endtime).ToList();
                }
                if (!string.IsNullOrEmpty(ordercode))
                {
                    list = list.Where(l => l.Order_Code.Contains(ordercode)).ToList();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new {code=0, data=list,msg=""});
        }
        /// <summary>
        /// 待审核列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("AuditOrder")]
        public IActionResult AuditOrder(int page,int limit) 
        {
            List<Orderlist> list;
            List<Orderlist> _list;
            try
            {
                list = orderListBll.GetOrderlists();
                list = list.Where(l => l.State == 0).ToList();
                _list = list.Skip((page - 1) * limit).Take(limit).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { code = 0, data = _list, count =list.Count});
        }
        /// <summary>
        /// 显示发票
        /// </summary>
        /// <param name="page"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInvoicesList")]
        public IActionResult GetInvoicesLists(int page,int limit) 
        {
            List<Invoice> list;
            List<Invoice> _list;
            try
            {
                list = invoiceBll.GetInvoicesList();
                _list = list.Skip((page - 1) * limit).Take(limit).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { code=0,data=_list,count=list.Count });
        }
        /// <summary>
        /// 审核订单
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdOrderlistState")]
        public IActionResult UpdOrderlistState(int id, int state)
        {
            int result;
            try
            {
                result = orderListBll.UpdOrderlistState(id, state);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { state = result > 0 ? true : false, data = result > 0 ? "操作成功" : "操作失败" });
        }
        /// <summary>
        /// 发票详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInvoices")]
        public IActionResult GetInvoices(int id)
        {
            List<Invoice> list;
            Invoice invoice;
            try
            {
                list = invoiceBll.GetInvoicesList();
                invoice = list.Where(l => l.Id == id).ToList()[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { code = 0, data = invoice, count = list.Count });
        }
        /// <summary>
        /// 修改发票状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdInvoiceState")]
        public IActionResult UpdInvoiceState(int id,int state) 
        {
            int result;
            try
            {
                result = invoiceBll.UpdInvoiceState(id, state);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
             
            return Ok(new { state=result>0?true:false,data=result>0?"操作成功":"操作失败" });
        }
        /// <summary>
        /// 本公司账户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOneCompany")]
        public IActionResult GetOneCompany() 
        {
            OneCompany oneCompany = new OneCompany();
            try
            {
                oneCompany = accountManageBll.GetOneCompany();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { code=0,data=oneCompany,msg=""});
        }
        /// <summary>
        /// 修改本公司信息
        /// </summary>
        /// <param name="oc"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdOneCompanyInter")]
        public IActionResult UpdOneCompanyInter(OneCompany oc) 
        {
            int result;
            try
            {
                result = accountManageBll.UpdOneCompanyInter(oc);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { state = result > 0 ? true : false, data = result > 0 ? "操作成功" : "操作失败" });
        }
    }
}
