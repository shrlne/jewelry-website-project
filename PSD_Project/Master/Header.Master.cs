using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class Header : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null && Session["admin"] == null)
            {
                Btn_ToHome.Visible = true;
                Btn_ToLogin.Visible = true;
                Btn_ToRegister.Visible = true;
                Btn_ToCart.Visible = false;
                Btn_ToMyOrders.Visible = false;
                Btn_ToAddJewel.Visible = false;
                Btn_ToReports.Visible = false;
                Btn_ToHandleOrders.Visible = false;
                Btn_ToProfile.Visible = false;
                Btn_ToLogout.Visible = false;
            }
            else if (Session["customer"] != null)
            {
                Btn_ToHome.Visible = true;
                Btn_ToLogin.Visible = false;
                Btn_ToRegister.Visible = false;
                Btn_ToCart.Visible = true;
                Btn_ToMyOrders.Visible = true;
                Btn_ToAddJewel.Visible = false;
                Btn_ToReports.Visible = false;
                Btn_ToHandleOrders.Visible = false;
                Btn_ToProfile.Visible = true;
                Btn_ToLogout.Visible = true;
            }
            else if (Session["admin"] != null)
            {
                Btn_ToHome.Visible = true;
                Btn_ToLogin.Visible = false;
                Btn_ToRegister.Visible = false;
                Btn_ToCart.Visible = false;
                Btn_ToMyOrders.Visible = false;
                Btn_ToAddJewel.Visible = true;
                Btn_ToReports.Visible = true;
                Btn_ToHandleOrders.Visible = true;
                Btn_ToProfile.Visible = true;
                Btn_ToLogout.Visible = true;
            }
        }

        protected void Btn_ToHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void Btn_ToLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void Btn_ToRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RegisterPage.aspx");
        }

        protected void Btn_ToCart_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CartPage.aspx");
        }

        protected void Btn_ToMyOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MyOrderPage.aspx");
        }

        protected void Btn_ToAddJewel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/AddJewelPage.aspx");
        }

        protected void Btn_ToReports_Click(object sender, EventArgs e)
        {

        }

        protected void Btn_ToHandleOrders_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HandleOrderPage.aspx");
        }

        protected void Btn_ToProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ProfilePage.aspx");
        }

        protected void Btn_ToLogout_Click(object sender, EventArgs e)
        {
            Session.Remove("customer");
            Session.Remove("admin");
            HttpCookie cookie = Request.Cookies["userCookie"];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("~/View/LoginPage.aspx");
        }
    }
}