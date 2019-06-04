using expressage.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace expressage.controller
{
    public partial class orderQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Order order = new Order();
            if (Session["name"] != null)
            {
                int id = Int32.Parse(Request.Params["id"]);
                order = new Order(id);
                Response.Write(order.returnJson(200, "成功", order));
            }
            else
            {
                this.Response.Write(order.returnJson(400, "你还没有登录,请重新登录", ""));
            }
        }
    }
}