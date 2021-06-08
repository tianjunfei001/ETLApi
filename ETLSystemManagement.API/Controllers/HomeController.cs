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
using System.Net;
using System.IO;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Security.Cryptography;

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
        public IActionResult RepLiteTest(string url)
        {
            //容器接受
            Article article = new Article();

            //指定源
            //var url = "http://www.xinhuanet.com/politics/leaders/2021-05/27/c_1127500668.htm";

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


        //手机号登录
        /// ========================================程序配置参数区开始

        //接口生产地址(应用上线后正式环境必须使用该地址)
        //private  static String url = "http://www.etuocloud.com/gateway.action";

        //接口测试地址（未上线前测试环境使用）
        private static String url = "http://www.etuocloud.com/gatetest.action";

        //应用 app_key
        private static String APP_KEY = "QqDVNr4nLTYHZMW9fp05pHgO8DOsydp2";
        //应用 app_secret
        private static String APP_SECRET = "s3J9XuaHVbJPSLeP4uZaZnyqrJNpWplLN6oUvyOgzj57vvmcK72KMctKqmuPU6lP";

        //接口响应格式 json或xml
        private static String FORMAT = "json";

        /// ========================================程序配置参数区结束

        /// <summary>
        /// 发生短信验证码
        /// </summary>
        [HttpPost]
        [Route("GetYan")]
        public IActionResult GetYan(string tel)
        {
            Random random = new Random();
            var sui = random.Next(1000, 9999).ToString() + "F";

            //发送短信验证码
            string yan = sendSmsCode(tel, 1, sui);

            return Ok(new { msg = yan, yan = sui });
        }

        /// <summary>
        /// 发生短信验证码
        /// </summary>
        /// <param name="to">手机号</param>
        /// <param name="template">短信模板ID</param>
        /// <param name="smscode">验证码</param>
        /// <returns></returns>
        public static string sendSmsCode(string to, int template, string smscode)
        {

            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("app_key", APP_KEY);
            parameters.Add("view", FORMAT);
            parameters.Add("method", "cn.etuo.cloud.api.sms.simple");
            parameters.Add("out_trade_no", "");//商户订单号，可空
            parameters.Add("to", to);
            parameters.Add("template", template.ToString());
            parameters.Add("smscode", smscode);
            parameters.Add("sign", getsign(parameters));
            return HttpClient.HttpPost(url, parameters);

        }

        /// <summary>
        /// 获取param签名
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static string getsign(NameValueCollection parameters)
        {
            SortedDictionary<string, string> sParams = new SortedDictionary<string, string>();
            foreach (string key in parameters.Keys)
            {
                sParams.Add(key, parameters[key]);
            }

            string sign = string.Empty;
            StringBuilder codedString = new StringBuilder();
            foreach (KeyValuePair<string, string> temp in sParams)
            {
                if (temp.Value == "" || temp.Value == null || temp.Key.ToLower() == "sign")
                {
                    continue;
                }

                if (codedString.Length > 0)
                {
                    codedString.Append("&");
                }
                codedString.Append(temp.Key.Trim());
                codedString.Append("=");
                codedString.Append(temp.Value.Trim());
            }

            // 应用key
            codedString.Append(APP_SECRET);
            string signkey = codedString.ToString();
            sign = GetMD5(signkey, "utf-8");

            return sign;
        }

        //md5
        private static string GetMD5(string encypStr, string charset)
        {
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用XXX编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception)
            {
                inputBye = System.Text.Encoding.UTF8.GetBytes(encypStr);
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();

            //  return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(ConvertString, "MD5").ToLower(); ;

            return retStr;
        }



    }

    /// <summary>
    /// 短信帮助类
    /// </summary>
    public class HttpClient
    {
        /// <summary>
        /// POST请求与获取结果  
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string HttpPost(string Url, NameValueCollection parameters)
        {
            return HttpPost(Url, toParaData(parameters));
        }



        //调用http接口,接口编码为utf-8
        private static string toParaData(NameValueCollection parameters)
        {

            //设置参数，并进行URL编码
            StringBuilder codedString = new StringBuilder();
            foreach (string key in parameters.Keys)
            {
                // codedString.Append(HttpUtility.UrlEncode(key));
                codedString.Append(key);
                codedString.Append("=");
                codedString.Append(HttpUtility.UrlEncode(parameters[key], System.Text.Encoding.UTF8));
                codedString.Append("&");
            }
            string paraUrlCoded = codedString.Length == 0 ? string.Empty : codedString.ToString().Substring(0, codedString.Length - 1);


            return paraUrlCoded;
        }


        /// <summary>  
        /// POST请求与获取结果  
        /// </summary>  
        public static string HttpPost(string Url, string postDataStr)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";

            //request.ContentLength = postDataStr.Length;
            //StreamWriter writer = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.UTF8);
            // writer.Write(postDataStr);
            // writer.Flush();


            //将URL编码后的字符串转化为字节
            byte[] payload = System.Text.Encoding.UTF8.GetBytes(postDataStr);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();

            //获得响应流
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //默认编码  
            }
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));

            string retString = reader.ReadToEnd();
            return retString;
        }



    }

}
