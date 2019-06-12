using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ymlib;
namespace ymlib
{
    public class ModelBase
    {
        private Db db = new Db();
        SqlDataReader read = null;
        private string tableName = "";
        private string filed = "";
        private string value = "";

        internal Db Db { get => db; set => db = value; }
        public string TableName { get => tableName; set => tableName = value; }

        public ModelBase()
        {
        }

        public ModelBase(string tableName)
        {
            this.TableName = tableName;
        }

        public ModelBase(string filed, string value)
        {
            this.filed = filed;
            this.value = value;
        }

        public ModelBase table(string tableName)
        {
            this.TableName = tableName;
            return this;
        }

        public ModelBase where(string filed,string value)
        {
            this.filed = filed;
            this.value = value;
            return this;
        }

        public string [] find(string [] array)
        {
            this.read = db.getSqlDataReader(this.createSql());
            if (this.read.Read())
            {
                string[] result = new string[array.Length];
                for(int i = 0; i < array.Length; i++)
                {
                    result[i] = (string)read[array[i]];
                }
                return result;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader getAll()
        {
            return db.getSqlDataReader("SELECT * FROM["+this.TableName+"]");
        }

        public SqlDataReader get()
        {
            return db.getSqlDataReader(this.createSql());
        }
        
        public bool isHas()
        {
            this.read = db.getSqlDataReader(this.createSql());
            bool res = false;
            if (read.Read())
            {
                res = true;
            }
            this.read.Close();
            return res;
        }

        public bool delete(int id)
        {
            string sql = "DELETE FROM [" + this.TableName + "] WHERE id =" + id;
            SqlCommand cmd = db.getSqlCommand(sql);
            try
            {
                cmd.ExecuteNonQuery();
                db.close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private string createSql()
        {
            return "SELECT * FROM ["+this.TableName+"] where "+this.filed+" = '"+this.value+"'";
        }

        public DataSet GetDateSet()//查询数据库，得到数据集
        {
            SqlDataAdapter dataAdapter = db.getSqlDataAdapter(this.createSql());
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);//填充数据集
            if (dataSet.Tables[0].Rows.Count != 0)
            {
                return dataSet;//若找到相应数据，则返回数据集
            }
            else
            {
                return null;//若没有找到相应数据集，返回空值
            }
        }

        public string returnJson(int code,string msg,object data)
        {
            Hashtable hash = new Hashtable();
            hash.Add("code", code);
            hash.Add("msg", msg);
            hash.Add("data", data);
            return JsonConvert.SerializeObject(hash);
        }
    }
}