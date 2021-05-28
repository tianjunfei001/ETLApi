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
using ZendeskApi_v2.Models.Articles;
using HtmlAgilityPack;

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


        //HtmlAgilityPack ---   Nuget包
        /// <summary>
        /// RepLiteTest  爬虫
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("RepLiteTest")]
        public IActionResult RepLiteTest()
        {
            //容器接受
            Article article = new Article();

            //指定源
            var url = "http://www.xinhuanet.com/politics/leaders/2021-05/27/c_1127500668.htm";

            //创建HtmlAgiLityPack 对象
            HtmlWeb web = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = System.Text.Encoding.UTF8//解决中文乱码
            };

            //加载对应路径（源）的html内容
            var html = web.Load(url);

            //获取单个节点SelectSingleNode

            //标题
            var titleNode = html.DocumentNode.SelectSingleNode("//div[@class='h-title']");
            article.Title= titleNode.InnerText;

            //发布时间
            var timeNode = html.DocumentNode.SelectSingleNode("//span[@class='h-time']");
            article.CreatedAt = Convert.ToDateTime(timeNode.InnerText);

            //内容
            var ContextNode = html.DocumentNode.SelectSingleNode("//div[@id='detail']");
            //所有的p  集合
            var Ps = ContextNode.SelectNodes(".//p");
            //空容器
            List<string> vs = new List<string>();
            foreach (var item in Ps)
            {
                vs.Add(item.InnerText);               
            }

            //获取a标签属性  herf   Attributes:属性意思
            var herf = html.DocumentNode.SelectSingleNode("//div[@class='news-position']");
            var a = herf.SelectSingleNode(".//a").Attributes["href"].Value;

            article.Body = ContextNode.InnerHtml;
            return Ok(new { article});
        }


    }
}
