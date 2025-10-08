using PSD_Project.Controller;
using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class AddJewelPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            if (!IsPostBack)
            {
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
            }
        }

        protected void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HomePage.aspx");
        }

        protected void Btn_Add_Click(object sender, EventArgs e)
        {
            String jewelName = TBox_JewelName.Text;
            String categoryIdStr = DDList_Category.SelectedValue;
            String brandIdStr = DDList_Brand.SelectedValue;
            String priceStr = TBox_Price.Text;
            String releaseYearStr = TBox_ReleaseYear.Text;

            string result = JewelController.AddJewel(jewelName, categoryIdStr, brandIdStr, priceStr, releaseYearStr);

            if (result == "Success")
            {
                Lbl_Status.Text = "Jewel successfully added!";
                Lbl_Status.ForeColor = System.Drawing.Color.Green;

                // Clear form
                TBox_JewelName.Text = "";
                TBox_Price.Text = "";
                TBox_ReleaseYear.Text = "";
                DDList_Category.SelectedIndex = 0;
                DDList_Brand.SelectedIndex = 0;
            }
            else
            {
                Lbl_Status.Text = result;
                Lbl_Status.ForeColor = System.Drawing.Color.Red;
            }

        }
    }
}