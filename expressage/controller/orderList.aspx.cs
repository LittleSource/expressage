using expressage.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace expressage.controller
{
    public partial class orderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Order order = new Order();
            if (Session["name"] != null)
            {
                List<Order> list = order.getsAll();
                string html = "";
                foreach (Order _order in list)
                {
                    html += "<tr><td>" + _order.Id + "</td><td>" + _order.Name + "</td><td>" + _order.Code + "</td><td>" + _order.Price + "</td><td>" + _order.School + "</td><td>" + _order.Time + "</td><td><div class='layui-inline'><button class='layui-btn layui-btn-small layui-btn-normal go-btn' data-id='" + _order.Id + "' data-url='article-edit.html'><i class='layui-icon'>&#xe642;</i></button><button class='layui-btn layui-btn-small layui-btn-danger del-btn' data-id='" + _order.Id+"'><i class='layui-icon'>&#xe640;</i></button></div></td></tr>";
                }
                Response.Write(order.returnJson(200, "成功", html));
            }
            else
            {
                this.Response.Write(order.returnJson(400, "你还没有登录,请重新登录", ""));
            }
        }
    }
}