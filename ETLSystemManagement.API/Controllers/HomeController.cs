using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETL.ERP.BLL;
using ETL.ERP.Model;
using AutoMapper;
using ETLSystemManagement.API.Models;

namespace ETLSystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        Ceshi ceshi;
        Company_BLL company_BLL;
        //注册Mapper
        IMapper mapper;
        public HomeController(Ceshi _ceshi,Company_BLL _company_BLL,IMapper _mapper)
        {
            ceshi = _ceshi;
            company_BLL = _company_BLL;
            mapper = _mapper;
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

        /// <summary>
        /// 获取 测试AutoMapper
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("GetCompanyShow")]
        public IActionResult GetCompanyShow()
        {
            List<Company> list = company_BLL.GetShowTable<Company>();

            var _model = mapper.Map<Company,ToCompany>(list[0]);
            var _list = mapper.Map<List<ToCompany>>(list);
            

            return Ok(new
            {
                code = 0,
                msg = "",
                model=_model,
                data = _list
            }); ;
        }



    }
}
