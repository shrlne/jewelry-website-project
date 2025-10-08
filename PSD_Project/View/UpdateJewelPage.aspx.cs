using PSD_Project.Controller;
using PSD_Project.Model;
using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace PSD_Project.View
{
    public partial class UpdateJewelPage : System.Web.UI.Page
    {
        private int jewelID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }
            if (!IsPostBack)
            {
                String jewelId = Request.QueryString["jewelId"];
                if (!int.TryParse(jewelId, out jewelID))
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }

                var categories = JewelRepository.GetAllCategories();
                DDList_Category.Items.Clear();
                DDList_Category.Items.Add(new ListItem("-- Select Category --", ""));
                foreach (var category in categories)
                {
                    DDList_Category.Items.Add(new ListItem(category.CategoryName, category.CategoryID.ToString()));
                }

                var brands = JewelRepository.GetAllBrands();
                DDList_Brand.Items.Clear();
                DDList_Brand.Items.Add(new ListItem("-- Select Brand --", ""));
                foreach (var brand in brands)
                {
                    DDList_Brand.Items.Add(new ListItem(brand.BrandName, brand.BrandID.ToString()));
                }

                var jewel = JewelRepository.GetJewelById(jewelID);
                if (jewel == null)
                {
                    Response.Redirect("~/View/HomePage.aspx");
                }

                TBox_JewelName.Text = jewel.JewelName;
                DDList_Category.SelectedValue = jewel.CategoryID.ToString();
                DDList_Brand.SelectedValue = jewel.BrandID.ToString();
                TBox_Price.Text = jewel.JewelPrice.ToString();
                TBox_ReleaseYear.Text = jewel.JewelReleaseYear.ToString();

                ViewState["JewelID"] = jewelID;

            }
            else
            {
                jewelID = (int)(ViewState["JewelID"] ?? 0);
            }
        }

        protected void Btn_Update_Click(object sender, EventArgs e)
        {
            String jewelName = TBox_JewelName.Text;
            String categoryIdStr = DDList_Category.SelectedValue;
            String brandIdStr = DDList_Brand.SelectedValue;
            String priceStr = TBox_Price.Text;
            String releaseYearStr = TBox_ReleaseYear.Text;

            string result = JewelController.UpdateJewel(jewelID, name, categoryIdStr, brandIdStr, priceStr, releaseYearStr);

            if (result == "Success")
            {
                Response.Redirect($"~/View/JewelDetails.aspx?jewelId={jewelID}");
            }
            else
            {
                Lbl_Status.Text = result;
            }
        }
    }
}