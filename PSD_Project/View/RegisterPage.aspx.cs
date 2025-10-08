using PSD_Project.Controller;
using PSD_Project.Model;
using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            string email = TBox_Email.Text;
            string username = TBox_Username.Text;
            string password = TBox_Password.Text;
            string confirmPassword = TBox_ConfirmPassword.Text;
            string gender = Male.Checked ? "Male" : (Female.Checked ? "Female" : "");
            string dob = TBox_DOB.Text;

            string result = UserController.Register(email, username, password, confirmPassword, gender, dob);
            if (result == "Register successful")
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
