using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ymcore.model;

namespace expressage.model
{
    public class User:ModelBase
    {
        private string username;
        private string password;
        private string[] filds = new string[] { "username", "password" };

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public User() {
            base.table("user");
        }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public bool hasUser(string userName)
        {
            return this.table("user").where("username", userName).isHas();
        }

        public User findByName(string userName)
        {
            string[] result = this.table("user").where("username", userName).find(this.filds);
            return new User(result[0], result[1]);
        }
    }
}