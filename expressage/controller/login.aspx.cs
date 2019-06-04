using expressage.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace expressage.controller
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = Request.Params["username"];
            string password = Request.Params["password"];
            User user = new User();
            if (user.hasUser(userName))
            {
                user = user.findByName(userName);
                if (user.Password.Trim() == password)
                {
                    Session.Add("name", user.Username);
                    this.Response.Write(user.returnJson(200, "成功", ""));
                }
                else
                {
                    this.Response.Write(user.returnJson(201, "密码错误！", ""));
                }
            }
            else
            {
                this.Response.Write(user.returnJson(201, "用户不存在", ""));
            }
        }
    }
}