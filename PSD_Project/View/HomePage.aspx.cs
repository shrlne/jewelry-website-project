using PSD_Project.Model;
using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GV_JewelList.DataSource = JewelRepository.GetAllJewels();
                GV_JewelList.DataBind();
            }


            if (Session["customer"] == null && Session["admin"] == null && 
                Request.Cookies["userCookie"] == null)
            {
                Lbl_Hello.Text = "Hello, Guest";
            }
            else if (Request.Cookies["userCookie"] != null)
            {
                int id = Convert.ToInt32(Request.Cookies["userCookie"].Value);
                MsUser user = UserRepository.GetUserById(id);
                if (user.UserRole == "Customer")
                {
                    Session["customer"] = user;
                    Lbl_Hello.Text = "Hello, " + user.UserName;
                }
                else if (user.UserRole == "Admin")
                {
                    Session["admin"] = user;
                    Lbl_Hello.Text = "Hello, " + user.UserName;
                }
            }
        }

        protected void GV_JewelList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetail")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = GV_JewelList.Rows[index];
                string jewelID = selectedRow.Cells[0].Text;

                Response.Redirect($"~/View/JewelDetails.aspx?jewelId={jewelID}");
            }
        }
    }
}