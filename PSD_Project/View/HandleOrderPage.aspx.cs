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
    public partial class HandleOrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                LoadUnfinishedOrders();
            }
        }

        private void LoadUnfinishedOrders()
        {
            var orders = TransactionRepository.GetUnfinishedTransactions();
            GV_HandleOrder.DataSource = orders;
            GV_HandleOrder.DataBind();
        }

        protected void GV_HandleOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();

                Button btnConfirm = (Button)e.Row.FindControl("Btn_ConfirmPayment");
                Button btnShip = (Button)e.Row.FindControl("Btn_Ship");
                Label lblWait = (Label)e.Row.FindControl("Lbl_WaitUserConfirmation");

                if (status == "Payment Pending")
                {
                    btnConfirm.Visible = true;
                    btnShip.Visible = false;
                    lblWait.Visible = false;
                }
                else if (status == "Shipment Pending")
                {
                    btnShip.Visible = true;
                    lblWait.Visible = false;
                    btnConfirm.Visible= false;
                }
                else if (status == "Arrived")
                {
                    lblWait.Visible = true;
                    btnConfirm.Visible = false;
                    btnShip.Visible= false;
                }
            }
        }

        protected void GV_HandleOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GV_HandleOrder.Rows[index];
            int transactionId = Convert.ToInt32(GV_HandleOrder.DataKeys[index].Value);

            if (e.CommandName == "ConfirmPayment")
            {
                TransactionController.UpdateTransactionStatus(transactionId, "Shipment Pending");
            }
            else if (e.CommandName == "ShipPackage")
            {
                TransactionController.UpdateTransactionStatus(transactionId, "Arrived");
            }


            LoadUnfinishedOrders();

        }
    }
}