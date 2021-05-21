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
    public class HomeController : ControllerBase
    {
        Ceshi ceshi;
        public HomeController(Ceshi _ceshi)
        {
            ceshi = _ceshi;
        }       
        /// <summary>
        /// 测试
        /// </summary>
        /// <returns></returns>
        [HttpGet,Route("GetShow")]
        public IActionResult GetShow()
        {
            List<User> use = ceshi.GetShow();

            return Ok(new { data = use});
        }



    }
}
