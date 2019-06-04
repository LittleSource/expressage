using expressage.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace expressage.controller
{
    public partial class orderDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Order order = new Order();
            if (Session["name"] != null)
            {
                int id = Int32.Parse(Request.Params["id"]);
                if (order.delete(id))
                {
                    Response.Write(order.returnJson(200, "删除成功!", ""));
                }
                else
                {
                    Response.Write(order.returnJson(201, "删除失败!", ""));
                }
            }
            else
            {
                this.Response.Write(order.returnJson(400, "你还没有登录,请重新登录", ""));
            }
        }
    }
}