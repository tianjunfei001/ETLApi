using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETL.ERP.BLL;
using ETL.ERP.Model.Rent.Model;
using log4net;

namespace ETLSystemManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private ILog log = LogManager.GetLogger(Startup.repository.Name, typeof(RentController));
       RentBll bll;
        public RentController(RentBll _bll) 
        {
            bll = _bll;
        }

        /// <summary>
        /// 省显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        [HttpGet("Shengdisplay")]
        public IActionResult Shengdisplay() 
        {
            List<Area> list = new List<Area>();
            try
            {
                list = bll.Shengdisplay();
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                throw;
            }
            return Ok(new {data=list });
        }

        /// <summary>
        /// 市显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        [HttpGet("Shidisplay")]
        public IActionResult Shidisplay()
        {
            List<Area> list = new List<Area>();
            try
            {
                list = bll.Shidisplay();
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                throw;
            }
            return Ok(new { data = list });
        }


        /// <summary>
        /// 区显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        [HttpGet("Qudisplay")]
        public IActionResult Qudisplay()
        {
            List<Area> list = new List<Area>();
            try
            {
                list = bll.Qudisplay();
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                throw;
            }
            return Ok(new { data = list });
        }


        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        [HttpPost("UserLogin")]
        public IActionResult UserLogin(Account a) 
        {
            int h=0;
            try
            {
                 h = bll.UserLogin(a);
                
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state =h> 0 ? true : false, msg = h > 0 ? "登录成功" : "登录失败" });
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost("Userregister")]
        public IActionResult Userregister(Account a) 
        {
            int h = 0;
            try
            {
                h = bll.Userregister(a);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "注册成功" : "注册失败" });
        }


        /// <summary>
        /// 用户个人信息显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("Userdisplay")]
        public IActionResult Userdisplay(int Aid)
        {
            List<AccountInfo> list = new List<AccountInfo>();
            try
            {
                list = bll.Userdisplay(Aid);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new {data=list});
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        [HttpPost("UpdUserPassword")]
        public IActionResult UpdUserPassword(Account a)
        {
            int h = 0;
            try
            {
                h = bll.UpdUserPassword(a);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "修改成功" : "修改失败" });
        }

        /// <summary>
        /// 修改用户个人信息
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        [HttpPost("UpdUser")]
        public IActionResult UpdUser(AccountInfo a)
        {
            int h = 0;
            try
            {
                h = bll.UpdUser(a);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "修改成功" : "修改失败" });
        }

        /// <summary>
        /// 商户注册
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost("Merchatregister")]
        public IActionResult Merchatregister(Merchant m)
        {
            int h = 0;
            try
            {
                h = bll.Merchatregister(m);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "注册成功" : "注册失败" });
        }

        /// <summary>
        /// 商户登录
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>

        [HttpPost("MerchatLogin")]

        public IActionResult MerchatLogin(Merchant m)
        {
            int h = 0;
            try
            {
                h = bll.MerchatLogin(m);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "登录成功" : "登录失败" });
        }

        /// <summary>
        /// 商户个人信息显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("Merchantdisplay")]
        public IActionResult Merchantdisplay(int Mid)
        {
            List<MerchantInfo> list = new List<MerchantInfo>();
            try
            {
                list = bll.Merchantdisplay(Mid);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { data = list });
        }


        /// <summary>
        /// 修改商户密码
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        [HttpPost("UpdMerchantPassword")]
        public IActionResult UpdMerchantPassword(Merchant m)
        {
            int h = 0;
            try
            {
                h = bll.UpdMerchantPassword(m);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "修改成功" : "修改失败" });
        }

        /// <summary>
        /// 修改商户个人信息
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        [HttpPost("UpdMerchant")]
        public IActionResult UpdMerchant(MerchantInfo m)
        {
            int h = 0;
            try
            {
                h = bll.UpdMerchant(m);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "修改成功" : "修改失败" });
        }

        
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost("AdministratorsLogin")]

        public IActionResult AdministratorsLogin(Administrators a)
        {
            int h = 0;
            try
            {
                h = bll.AdministratorsLogin(a);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "登录成功" : "登录失败" });
        }
        /// <summary>
        /// 房源类型显示
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpGet("TypesHousingdisplay")]

        public IActionResult TypesHousingdisplay()
        {
            List<TypesHousing> list = new List<TypesHousing>();
            try
            {
                list = bll.TypesHousingdisplay();
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new {data=list });
        }

        /// <summary>
        /// 房源类型状态修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>

        [HttpGet("UpdTypesHousing")]
        public IActionResult UpdTypesHousing(int Hid)
        {
            int h = 0;
            try
            {
                h = bll.UpdTypesHousing(Hid);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "修改成功" : "修改失败" });
        }

    }
}
