using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ETLSystemManagement.API
{
    public class CustomAutofacModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            //builder.RegisterAssemblyTypes(assembly).Where(type => type.Namespace.Equals("ETLSystemManagement.API.Services"));
            builder.RegisterAssemblyTypes(GetAssemblyByName("ETL.ERP.DAL")).Where(type => type.Namespace.Equals("ETL.ERP.DAL"));
            builder.RegisterAssemblyTypes(GetAssemblyByName("ETL.ERP.BLL")).Where(type => type.Namespace.Equals("ETL.ERP.BLL"));
            //builder.RegisterType<OneService>().As<IService>();
        }
        /// <summary>
        /// 根据程序集名称获取程序集
        /// </summary>
        /// <param name="AssemblyName">程序集名称</param>
        /// <returns></returns>
        public static Assembly GetAssemblyByName(String AssemblyName)
        {
            return Assembly.Load(AssemblyName);
        }

    }
}
