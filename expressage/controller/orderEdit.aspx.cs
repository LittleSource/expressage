using expressage.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace expressage.controller
{
    public partial class orderEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Order order = new Order();
            if (Session["name"] != null)
            {
                order.Id = Int32.Parse(Request.Params["id"]);
                order.Name = Request.Params["name"];
                order.Code = Request.Params["code"];
                order.School = Request.Params["school"];
                order.Price = Request.Params["price"];
                if (order.update())
                {
                    Response.Write(order.returnJson(200, "修改成功！", ""));
                }
                else
                {
                    Response.Write(order.returnJson(201, "修改失败！", ""));
                }
            }
            else
            {
                this.Response.Write(order.returnJson(400, "你还没有登录,请重新登录", ""));
            }
        }
    }
}