using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSD_Project.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null)
            {
                Response.Redirect("~/View/HomePage.aspx");
            }

            if (!IsPostBack)
            {
                int transactionId;
                if (Request.QueryString["TransactionID"] != null && int.TryParse(Request.QueryString["TransactionID"], out transactionId))
                {
                    LoadTransactionDetails(transactionId);
                }
                else
                {
                    Response.Redirect("~/View.MyOrderPage.aspx");
                }
            }
        }

        private void LoadTransactionDetails (int transactionId)
        {
            var details = TransactionDetailRepository.GetTransactionDetails(transactionId);
            GV_TransactionDetail.DataSource = details;
            GV_TransactionDetail.DataBind();
        }
    }
}