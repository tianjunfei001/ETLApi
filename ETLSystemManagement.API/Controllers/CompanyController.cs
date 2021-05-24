using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETL.ERP.BLL;
using ETL.ERP.Model;
using ETLSystemManagement.API.Models;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;

namespace ETLSystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        //获取JwtSettings对象信息
        private JwtSettings _jwtSettings;

        //注入
        Company_BLL company_BLL;// = new Company_BLL();

        public CompanyController(Company_BLL _company_BLL, IOptions<JwtSettings> _jwtSettingsAccesser)
        {
            company_BLL = _company_BLL;
            _jwtSettings = _jwtSettingsAccesser.Value;
        }


        /// <summary>
        /// 获取token
        /// </summary>
        private object Token(app_mobile_user model)
        {
            //测试自己创建的对象
            var user = new app_mobile_user
            {
                id = 1,
                phone = "138000000",
                password = "e10adc3949ba59abbe56e057f20f883e"
            };
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            var authTime = DateTime.Now;//授权时间
            var expiresAt = authTime.AddDays(30);//过期时间
            var tokenDescripor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] {
                    new Claim(JwtClaimTypes.Audience,_jwtSettings.Audience),
                    new Claim(JwtClaimTypes.Issuer,_jwtSettings.Issuer),
                    new Claim(JwtClaimTypes.Name, user.phone.ToString()),
                    new Claim(JwtClaimTypes.Id, user.id.ToString()),
                    new Claim(JwtClaimTypes.PhoneNumber, user.phone.ToString())
                }),
                Expires = expiresAt,
                //对称秘钥SymmetricSecurityKey
                //签名证书(秘钥，加密算法)SecurityAlgorithms
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescripor);
            var tokenString = tokenHandler.WriteToken(token);
            var result = new
            {
                access_token = tokenString,
                token_type = "Bearer",
                profile = new
                {
                    id = user.id,
                    name = user.phone,
                    phone = user.phone,
                    auth_time = authTime,
                    expires_at = expiresAt
                }
            };
            return result;
        }

        [Route("get_token")]
        [HttpPost]
        public IActionResult GetToken()
        {
            return Ok(Token(null));
        }

        [Authorize]
        [Route("get_user_info")]
        [HttpPost]
        public IActionResult GetUserInfo()
        {
            //获取当前请求用户的信息，包含token信息
            var user = HttpContext.User;
            return Ok("15563");
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
