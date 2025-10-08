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
    public partial class MyOrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                LoadOrders();
            }
        }

        private void LoadOrders()
        {
            MsUser user = (MsUser)Session["customer"];
            var transactions = TransactionRepository.GetTransactionsByUserId(user.UserID).Select
                                (t => new
                                {
                                    t.TransactionID,
                                    t.TransactionDate,
                                    t.PaymentMethod,
                                    t.TransactionStatus
                                }).ToList();
            GV_MyOrder.DataSource = transactions;
            GV_MyOrder.DataBind();
        }

        protected void GV_MyOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GV_MyOrder.Rows[index];
            int transactionId = Convert.ToInt32(row.Cells[0].Text);

            if (e.CommandName == "ViewDetails")
            {
                Response.Redirect("~/View/TransactionDetailPage.aspx?transactionID=" + transactionId);
            }
            else if (e.CommandName == "ConfirmPackage")
            {
                TransactionRepository.UpdateTransactionStatus(transactionId, "Done");
                LoadOrders();
            }
            else if (e.CommandName == "RejectPackage")
            {
                TransactionRepository.UpdateTransactionStatus(transactionId, "Rejected");
                LoadOrders();
            }
        }

        protected void GV_MyOrder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                String status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();
                Button btnConfirm = (Button)e.Row.FindControl("Btn_Confirm");
                Button btnReject = (Button)e.Row.FindControl("Btn_Reject");

                if (status == "Arrived")
                {
                    btnConfirm.Visible = true;
                    btnReject.Visible = true;
                }
            }
        }
    }
}