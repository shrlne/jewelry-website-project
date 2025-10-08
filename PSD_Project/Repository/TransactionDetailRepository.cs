using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Repository
{
    public class TransactionDetailRepository
    {
        public static List<dynamic> GetTransactionDetails(int transactionId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            var details = db.TransactionDetails
                .Where(td => td.TransactionID == transactionId)
                .Select(td => new
                {
                    TransactionID = td.JewelID,
                    JewelName = td.MsJewel.JewelName,
                    JewelQuantity = td.Quantity
                })
                .ToList<dynamic>();
            return details;
        }
    }
}