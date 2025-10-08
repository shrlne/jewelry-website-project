using PSD_Project.Controller;
using System;

namespace PSD_Project.View
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null || Session["admin"] != null ||
                Request.Cookies["userCookie"] != null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            string email = TBox_Email.Text;
            string password = TBox_Password.Text;
            bool isRemember = CBox_RememberMe.Checked;

            string result = UserController.Login(email, password, isRemember);
            if (result == "Login successful")
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            else
            {
                Lbl_Status.Text = result;
            }
        }
    }
}
