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
    public partial class ProfilePage : System.Web.UI.Page
    {
        protected MsUser currentUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                currentUser = (MsUser)Session["customer"];
            }
            else if (Session["admin"] != null)
            {
                currentUser = (MsUser)Session["admin"];
            }
            else
            {
                Response.Redirect("~/Viwe/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                DisplayUserProfile();
            }
        }

        private void DisplayUserProfile()
        {
            Lbl_EmailValue.Text = currentUser.UserEmail;
            Lbl_UsernameValue.Text = currentUser.UserName;
            Lbl_GenderValue.Text = currentUser.UserGender;
            Lbl_DOBValue.Text = currentUser.UserDOB.ToShortDateString();
            Lbl_RoleValue.Text = currentUser.UserRole;
        }

        protected void Btn_ChangePassword_Click(object sender, EventArgs e)
        {
            String oldPassword = TBox_OldPassword.Text;
            String newPassword = TBox_NewPassword.Text;
            String confirmPassowrd = TBox_ConfirmPassword.Text;

            Lbl_Status.Text = "";

            if (oldPassword != currentUser.UserPassword)
            {
                Lbl_Status.Text = "Old Password is incorrect";
                return;
            }
            else if (!Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]{8,25}$"))
            {
                Lbl_Status.Text = "New Password must be 8 to 25 characters and alphanumeric";
                return;
            }
            else if (confirmPassowrd != newPassword)
            {
                Lbl_Status.Text = "Confirm Password must match New Password";
                return;
            }
            else if (newPassword == currentUser.UserPassword)
            {
                Lbl_Status.Text = "New Password is the same as Old Password";
                return;
            }

            String updateResult = UserController.ChangePassword(currentUser, newPassword);

            if (updateResult == "Success")
            {
                currentUser.UserPassword = newPassword;

                if (Session["customer"] != null)
                {
                    Session["customer"] = currentUser;
                }
                else if (Session["admin"] != null)
                {
                    Session["admin"] = currentUser;
                }

                Lbl_Status.Text = "Password changed successfully.";
                TBox_OldPassword.Text = "";
                TBox_NewPassword.Text = "";
                TBox_ConfirmPassword.Text = "";

            }
            else
            {
                Lbl_Status.Text = "Failed to update password. Please try again";
            }
        }
    }
}