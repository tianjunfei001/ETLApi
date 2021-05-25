using AutoMapper;
using ETL.ERP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETLSystemManagement.API.Models
{
    public class AutoMapperConfigs:Profile
    {
        /// <summary>
        /// 配置可以互转的类
        /// </summary>
        public AutoMapperConfigs()
        {
            CreateMap<Company, ToCompany>();
        }

    }
}
