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

            return Ok(new
            {
                code = 0,
                msg = "",
                data = list
            }); ;
        }


    }
}
