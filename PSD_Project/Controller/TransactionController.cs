using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Controller
{
    public class TransactionController
    {
        public static string UpdateTransactionStatus(int transactionId, string newStatus)
        {
            var validStatuses = new List<string> { "Payment Pending", "Shipment Pending", "Arrived" };
            if (!validStatuses.Contains(newStatus))
            {
                return "Invalid transaction status.";
            }

            return TransactionRepository.UpdateTransactionStatus(transactionId, newStatus);
        }
    }
}