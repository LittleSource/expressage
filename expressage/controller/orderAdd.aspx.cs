using expressage.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace expressage.controller
{
    public partial class orderAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Order order = new Order();
            if (Session["name"] != null)
            {
                string name = Request.Params["name"];
                string code = Request.Params["code"];
                string price = Request.Params["price"];
                string school = Request.Params["school"];
                order = new Order(name, code, price, school);
                if (order.save())
                {
                    Response.Write(order.returnJson(200, "添加成功！", ""));
                }
                else
                {
                    Response.Write(order.returnJson(201, "添加失败！", ""));
                }
            }
            else
            {
                this.Response.Write(order.returnJson(400, "你还没有登录,请重新登录", ""));
            }
        }
    }
}