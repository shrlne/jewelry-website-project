using PSD_Project.Controller;
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
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                LoadCart();
                PaymentMethodList();
            }
        }

        private void PaymentMethodList()
        {
            DDL_Payment.Items.Clear();
            DDL_Payment.Items.Add(new ListItem("-- Select Payment Method --", ""));
            DDL_Payment.Items.Add(new ListItem("Credit Card", "CreditCard"));
            DDL_Payment.Items.Add(new ListItem("Bank Transfer", "BankTransfer"));
            DDL_Payment.Items.Add(new ListItem("E-Wallet", "EWallet"));
            DDL_Payment.Items.Add(new ListItem("COD", "COD"));
        }

        private void LoadCart()
        {
            if (Session["customer"] != null)
            {
                MsUser user = (MsUser)Session["customer"];
                var data = CartController.GetCart(user.UserID);
                GV_JewelList.DataSource = data;
                GV_JewelList.DataBind();

                decimal total = CartController.CalculateTotal(data);
                Lbl_Total.Text = "Total: $" + total.ToString("N0");
            }
        }

        protected void GV_JewelList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int jewelId = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = ((Control)e.CommandSource).NamingContainer as GridViewRow;
            MsUser user = (MsUser)Session["customer"];

            if (e.CommandName == "UpdateItem")
            {
                TextBox qtyBox = (TextBox)row.FindControl("TBox_Quantity");
                int newQty = int.Parse(qtyBox.Text);
                CartController.UpdateCart(user.UserID, jewelId, newQty);
            }
            else if (e.CommandName == "RemoveItem")
            {
                CartController.RemoveItem(jewelId);
            }

            LoadCart();
        }

        protected void Btn_ClearCart_Click(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                MsUser user = (MsUser)Session["customer"];
                CartController.ClearCart(user.UserID);
                LoadCart();
            }
        }

        protected void Btn_Checkout_Click(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                MsUser user = (MsUser)Session["customer"];
                string paymentMethod = DDL_Payment.SelectedItem.Text;

                string result = CartController.Checkout(user.UserID, paymentMethod);

                if (result == "Please select a valid payment method")
                {
                    Lbl_Error.Text = result;
                    return;
                }

                Response.Redirect("~/View/MyOrderPage.aspx");
            }
        }
    }
}