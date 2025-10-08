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
    public partial class DetailsPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                String jewelId = Request.QueryString["jewelId"];
                if (string.IsNullOrEmpty(jewelId))
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }

                int id = int.Parse(jewelId);
                var jewel = JewelRepository.GetJewelById(id);
                var category = JewelRepository.GetCategoryById(jewel.CategoryID);
                var brand = JewelRepository.GetBrandById(jewel.BrandID);

                if (jewel == null)
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }

                Lbl_JewelNameValue.Text = jewel.JewelName;
                Lbl_JewelCategoryValue.Text = category.CategoryName;
                Lbl_JewelBrandValue.Text = brand.BrandName;
                Lbl_JewelOriginValue.Text = brand.BrandCountry;
                Lbl_JewelClassValue.Text = brand.BrandClass;
                Lbl_JewelPriceValue.Text = jewel.JewelPrice.ToString();
                Lbl_JewelYearValue.Text = jewel.JewelReleaseYear.ToString();

                if (Session["customer"] != null)
                {
                    Btn_AddToCart.Visible = true;
                }
                else if (Session["admin"] != null)
                {
                    Btn_Edit.Visible = true;
                    Btn_Delete.Visible = true;
                }
            }
        }


        protected void Btn_AddToCart_Click(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                MsUser currentUser = (MsUser)Session["customer"];
                int jewelId = int.Parse(Request.QueryString["jewelId"]);
                CartRepository.AddToCart(currentUser.UserID, jewelId);
                Response.Redirect("~/View/CartPage.aspx");

            }
        }

        protected void Btn_Delete_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                String jewelId = Request.QueryString["jewelId"];
                if (!string.IsNullOrEmpty(jewelId))
                {
                    int id = int.Parse(jewelId);
                    JewelRepository.DeleteJewelById(id);
                    Response.Redirect("~/View/HomePage.aspx");
                }
            }

        }

        protected void Btn_Edit_Click(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                String jewelId = Request.QueryString["jewelId"];
                if (!string.IsNullOrEmpty(jewelId))
                {
                    Response.Redirect($"~/View/UpdateJewelPage.aspx?jewelId={jewelId}");
                }
            }
        }
    }
}