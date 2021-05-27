using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using MySql;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace ETL.ERP.DAL
{
    public class DapperHelper
    {
        
        IConfiguration configuration;

        IDbConnection _db = new MySqlConnection();
        //构造函数
        public DapperHelper(IConfiguration _configuration)
        {
            configuration = _configuration;       
            _db.ConnectionString = ConnectionString;

        }
        //字符串
        public string ConnectionString { get { return configuration.GetConnectionString("SqlServerConnection"); } set { } }
        
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandtype"></param>
        /// <returns></returns>
        public IEnumerable<T> Query<T>(string sql,object param=null,IDbTransaction transaction=null,bool buffered=true,int? commandTimeout=null,CommandType? commandtype=null)
        {
            return _db.Query<T>(sql,param,transaction,buffered,commandTimeout, commandtype);
        }
        /// <summary>
        /// 增删改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="param">参数</param>
        /// <param name="transaction">事务</param>
        /// <param name="buffered"></param>
        /// <param name="commandTimeout"></param>
        /// <param name="commandtype"></param>
        /// <returns></returns>
        public int Execute(string sql,object param=null,IDbTransaction transaction=null,int? commandTimeout=null,CommandType? commandtype=null) 
        {
            return _db.Execute(sql,param,transaction,commandTimeout,commandtype);
        }

    }
}
