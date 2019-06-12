using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ymlib
{
    class Db
    {
        private SqlConnection con = new SqlConnection();
        private SqlCommand com = new SqlCommand();
        private string conString;//数据库连接字符串

        public SqlConnection Con { get => con; set => con = value; }
        public SqlCommand Com { get => com; set => com = value; }
        public string ConString { get => conString; set => conString = value; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// database.getConString();从配置类中取得数据库连接字符串
        /// <param name="ConString">数据库连接字符串</param>
        public Db()
        {
            Con.ConnectionString = database.getConString();
            Con.Open();
            Com.Connection = Con;
        }
        /// <summary>
        /// 获取SqlDataReader对象
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns></returns>
        public SqlDataReader getSqlDataReader(string sqlString)
        {
            SqlCommand com_ = getSqlCommand(sqlString);
            return com_.ExecuteReader();
        }
        /// <summary>
        /// 获取SqlCommand对象
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns></returns>
        public SqlCommand getSqlCommand(string sqlString)
        {
            return new SqlCommand(sqlString, Con);
        }
        /// <summary>
        /// 获取SqlDataAdapter对象
        /// </summary>
        /// <param name="sqlString">sql语句</param>
        /// <returns></returns>
        public SqlDataAdapter getSqlDataAdapter(string sqlString)
        {
            return new SqlDataAdapter(sqlString, this.Con);
        }

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        public void close()
        {
            con.Close();
        }
    }
}