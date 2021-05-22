using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETL.ERP.BLL;
using ETL.ERP.Model;

namespace ETLSystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        //注入
        Company_BLL company_BLL;// = new Company_BLL();

        public CompanyController(Company_BLL _company_BLL)
        {
            company_BLL = _company_BLL;
        }

        /// <summary>
        /// 获取company公司基本信息表
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetCompanyShow")]
        public IActionResult GetCompanyShow()
        {
            List<Company> list = company_BLL.GetShowTable<Company>();
            var _list = list.Where(p => p.State == 2).ToList();

            return Ok(new
            {
                code = 0,
                msg = "",
                data = _list
            }); ;
        }

        /// <summary>
        /// 删除公司基本信息表一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("GetDelCompan")]
        public IActionResult GetDelCompan(string id)
        {
            int h = company_BLL.GetDelTable<Company>(id, "id");

            return Ok(new
            {
                code = 0,
                msg = h>=1?true:false,

            });
        }

        /// <summary>
        /// 反填公司基本信息表一条记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("GetFanCompan")]
        public IActionResult GetFanCompan(int id)
        {
            Company list = company_BLL.GetFanTable<Company>(id,"id");

            return Ok(new
            {
                code = 0,
                msg = "",
                data=list
            });
        }

        /// <summary>
        /// 修改 公司基本信息表一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost,Route("PostUpdCompan")]
        public IActionResult PostUpdCompan(Company model)
        {
            int h = company_BLL.GetUpdateTable<Company>(model, "id");
            return Ok(new
            {
                code = 0,
                msg = h >= 1 ? true : false,

            });

        }


        /// <summary>
        /// 待审核企业信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDaiCompanyList")]
        public IActionResult GetDaiCompanyList()
        {
            List<Company> list = company_BLL.GetShowTable<Company>();

            var _list = list.Where(p => p.State == 3).ToList();
            return Ok(new
            {
                code = 0,
                msg = "",
                data = _list
            }); ;

        }

        /// <summary>
        /// 没通过审核企业信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetWeiCompanyList")]
        public IActionResult GetWeiCompanyList()
        {
            List<Company> list = company_BLL.GetShowTable<Company>();

            var _list = list.Where(p => p.State == 2).ToList();
            return Ok(new
            {
                code = 0,
                msg = "",
                data = _list
            }); ;

        }


        /// <summary>
        /// 小修改审核状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        [HttpGet("GetStateUpdCompany")]
        public IActionResult GetStateUpdCompany(int id, int state)
        {
            int h = company_BLL.GetStateUpdCompany(id, state);

            return Ok(new
            {
                code = 0,
                msg = h >= 1 ? true : false,

            });

        }


    }
}
