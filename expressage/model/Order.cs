using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ymcore.model;

namespace expressage.model
{
    public class Order: ModelBase
    {
        private int id;
        private string name;
        private string code;
        private string price;
        private string school;
        private DateTime time;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Code { get => code; set => code = value; }
        public string Price { get => price; set => price = value; }
        public string School { get => school; set => school = value; }
        public DateTime Time { get => time; set => time = value; }

        public Order()
        {
            base.table("order");
        }

        public Order(string name, string code, string price, string school)
        {
            this.TableName = "order";
            this.name = name;
            this.code = code;
            this.price = price;
            this.school = school;
        }

        public Order(int id)
        {
            SqlDataReader reader = this.table("order").where("id", id.ToString()).get();
            if (reader.Read())
            {
                this.id = id;
                this.Name = (string)reader["name"];
                this.Code = (string)reader["code"];
                this.Price = (string)reader["price"];
                this.School = (string)reader["school"];
                this.Time = (DateTime)reader["time"];
            }
            else
            {
                this.id = 0;
            }
        }

        public List<Order> getsAll()
        {
            List<Order> list = new List<Order>();
            SqlDataReader reader = this.getAll();
            while (reader.Read())
            {
                Order order = new Order();
                order.Id = (int)reader["id"];
                order.Name = (string)reader["name"];
                order.Code = (string)reader["code"];
                order.Price = (string)reader["price"];
                order.School = (string)reader["school"];
                order.Time = (DateTime)reader["time"];
                list.Add(order);
            }
            return list;
        }

        public bool save()
        {
            string sqlString = "insert into [" +this.TableName+ "] ([name],[code],[price],[school],[time])values(@Name,@Code,@Pirce,@School,@Time)";
            SqlCommand com = Db.getSqlCommand(sqlString);
            //--参数绑定
            com.Parameters.Add("Name", SqlDbType.Text);
            com.Parameters["Name"].Value = this.Name;

            com.Parameters.Add("Code", SqlDbType.Text);
            com.Parameters["Code"].Value = this.Code;

            com.Parameters.Add("Pirce", SqlDbType.Text);
            com.Parameters["Pirce"].Value = this.Price;

            com.Parameters.Add("School", SqlDbType.Text);
            com.Parameters["School"].Value = this.School;

            com.Parameters.Add("Time", SqlDbType.DateTime);
            com.Parameters["Time"].Value = DateTime.Now;

            //绑定结束--
            if (com.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool update()
        {
            string sqlString = "UPDATE [" + this.TableName + "] SET [name] = @Name,[code] = @Code,[price] = @Price,[school] = @School WHERE id = @Id";
            SqlCommand com = Db.getSqlCommand(sqlString);
            //--参数绑定
            com.Parameters.Add("Id", SqlDbType.Int);
            com.Parameters["Id"].Value = this.Id;

            com.Parameters.Add("Name", SqlDbType.Text);
            com.Parameters["Name"].Value = this.Name;

            com.Parameters.Add("Code", SqlDbType.Text);
            com.Parameters["Code"].Value = this.Code;

            com.Parameters.Add("Price", SqlDbType.Text);
            com.Parameters["Price"].Value = this.Price;

            com.Parameters.Add("School", SqlDbType.Text);
            com.Parameters["School"].Value = this.School;
            //绑定结束--
            if (com.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}