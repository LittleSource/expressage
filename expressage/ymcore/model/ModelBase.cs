using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ymcore.lib;
namespace ymcore.model
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