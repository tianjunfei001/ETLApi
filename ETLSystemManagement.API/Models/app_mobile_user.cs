using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSystemManagement.API.Models
{
    public class app_mobile_user
    {

        public long id { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string phone { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string password { get; set; }


    }
}
