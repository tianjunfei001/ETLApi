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


        /// <summary>
        /// 小区显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("Communitydisplay")]
        public IActionResult Communitydisplay(int Pageindex,int Pagesize,int Sheng,int Shi,int Qu) 
        {
            List<Community> list = new List<Community>();
            List<Community> _list = new List<Community>();
            try
            {
                list = bll.Communitydisplay(Sheng,Shi,Qu);
                _list = list.Skip((Pageindex - 1) * Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new {data=_list,count=list.Count });
        }

        /// <summary>
        /// 房源显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
            [HttpGet("Housedisplay")]
            public IActionResult Housedisplay(int Hid,int Pageindex,int Pagesize,int Sheng,int Shi,int Qu) 
            {
            List<House> list = new List<House>();
            List<House> _list = new List<House>();
            try
            {
                list = bll.Housedisplay(Hid,Sheng, Shi, Qu);
                _list = list.Skip((Pageindex - 1) * Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            } 
            return Ok(new { data = _list, count = list.Count });
            }

        /// <summary>
        /// 用户端资讯信息显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("Informationsheetdisplay")]
        public IActionResult Informationsheetdisplay(int Pageindex,int Pagesize) 
        {
            List<Informationsheet> list = new List<Informationsheet>();
            List<Informationsheet> _list = new List<Informationsheet>();
            try
            {
                 list = bll.Informationsheetdisplay();
                _list = list.Skip((Pageindex-1)*Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new {data=_list,count=list.Count });
        }

        /// <summary>
        /// 后台资讯信息显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("Infordisplay")]
        public IActionResult Infordisplay(int Pageindex, int Pagesize)
        {
            List<Informationsheet> list = new List<Informationsheet>();
            List<Informationsheet> _list = new List<Informationsheet>();
            try
            {
                list = bll.Infordisplay();
                _list = list.Skip((Pageindex - 1) * Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { data = _list, count = list.Count });
        }

        /// <summary>
        /// 后台资讯信息添加
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost("InsertInformationsheet")]
        public IActionResult InsertInformationsheet(Informationsheet i)
        {
            int h;
            try
            {
                h = bll.InsertInformationsheet(i);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "添加成功" : "添加失败" });
        }

        /// <summary>
        /// 后台资讯信息修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost("UpdInformationsheet")]
        public IActionResult UpdInformationsheet(Informationsheet i)
        {
            int h;
            try
            {
                 h = bll.UpdInformationsheet(i);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "修改成功" : "修改失败" });
        }



        /// <summary>
        /// 后台资讯信息审核
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("UpdInforZt")]
        public IActionResult UpdInforZt(int Id)
        {
            int h;
            try
            {
                 h = bll.UpdInforZt(Id);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new {state=h>0?true:false,msg=h>0?"审核通过":"审核未通过" });
        }



        /// <summary>
        /// 后台资讯信息删除
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("DeleteInfor")]
        public IActionResult DeleteInfor(string ids)
        {
            ids = ids.TrimEnd(',');
            int h;
            try
            {
                h = bll.DeleteInfor(ids);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }
            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "删除成功" : "删除失败" });
        }


        /// <summary>
        /// 用户预约
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost("InsertAppointment")]
        public IActionResult InsertAppointment(Appointment a)
        {
            int h;
            try
            {
                h = bll.InsertAppointment(a);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "预约已提交,请等待审核" : "预约提交失败" });
        }

        /// <summary>
        /// 后台预约审核
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("UpdAppointment")]
        public IActionResult UpdAppointment(int Id)
        {
            int h;
            try
            {
                h = bll.UpdAppointment(Id);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "预约成功" : "预约失败" });
        }


        /// <summary>
        /// 后台显示用户预约
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("Appointmentdisplay")]
        public IActionResult Appointmentdisplay(int Pageindex,int Pagesize)
        {
            List<Appointment> list = bll.Appointmentdisplay();
            List<Appointment> _list = bll.Appointmentdisplay();
            try
            {
                list = bll.Appointmentdisplay();
                _list = list.Skip((Pageindex-1)*Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new {data=_list,count=list.Count });
        }


        /// <summary>
        /// 用户预约显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("display")]
        public IActionResult display(int Uid,int Pageindex, int Pagesize)
        {
            List<Appointmentdisplay> list = new List<Appointmentdisplay>();
            List<Appointmentdisplay> _list = new List<Appointmentdisplay>();
            try
            {
                list = bll.display(Uid);
                _list = list.Skip((Pageindex - 1) * Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { data = _list, count = list.Count });
        }


        /// <summary>
        /// 用户预约修改
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost("UpdateAppointment")]
        public IActionResult UpdateAppointment(Appointment a)
        {
            int h;

            try
            {
                h = bll.UpdateAppointment(a);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);              
                throw;
            }

            return Ok(new{state=h>0?true:false,msg=h>0?"修改成功":"修改失败" });
        }

        /// <summary>
        /// 用户取消预约
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("CancelAppointment")]
        public IActionResult CancelAppointment(int Id)
        {
            int h;

            try
            {
                h = bll.CancelAppointment(Id);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "取消预约成功" : "取消预约失败" });
        }


        /// <summary>
        /// 用户收藏
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("AddCollection")]
        public IActionResult AddCollection(Collection c)
        {
            int h;

            try
            {
                h = bll.AddCollection(c);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "收藏成功" : "收藏失败" });
        }

        /// <summary>
        /// 用户删除收藏
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("DelCollection")]
        public IActionResult DelCollection(string ids)
        {
            ids = ids.TrimEnd(',');
            int h;

            try
            {
                h = bll.DelCollection(ids);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { state = h > 0 ? true : false, msg = h > 0 ? "删除成功" : "删除失败" });
        }



        /// <summary>
        /// 用户收藏显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("Collectdisplay")]
        public IActionResult Collectdisplay(int Uid, int Pageindex, int Pagesize)
        {
            List<Collectiondisplay> list = new List<Collectiondisplay>();
            List<Collectiondisplay> _list = new List<Collectiondisplay>();
            try
            {
                list = bll.Collectdisplay(Uid);
                _list = list.Skip((Pageindex - 1) * Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { data = _list, count = list.Count });
        }



        /// <summary>
        /// 后台用户收藏显示
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpGet("Colldisplay")]
        public IActionResult Colldisplay(int Uid, int Pageindex, int Pagesize)
        {
            List<Collection> list = new List<Collection>();
            List<Collection> _list = new List<Collection>();
            try
            {
                list = bll.Colldisplay(Uid);
                _list = list.Skip((Pageindex - 1) * Pagesize).Take(Pagesize).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                throw;
            }

            return Ok(new { data = _list, count = list.Count });
        }
    }
}
