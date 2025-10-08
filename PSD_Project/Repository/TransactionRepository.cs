using PSD_Project.Factory;
using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Repository
{
    public class TransactionRepository
    {
        public static String CreateNewTransaction(int userId, String paymentMethod)
        {
            using (LocalDatabaseEntities db = new LocalDatabaseEntities())
            {
                var cartItems = db.Carts.Where(x => x.UserID == userId).ToList();

                if (!cartItems.Any())
                {
                    return "Cart is empty";
                }

                TransactionHeader newTransaction = TransactionFactory.CreateNewTransaction(userId, DateTime.Now, paymentMethod, "Payment Pending");
                db.TransactionHeaders.Add(newTransaction);
                db.SaveChanges();

                foreach (var item in cartItems)
                {
                    TransactionDetail detail = TransactionFactory.CreateNewDetail(newTransaction.TransactionID, item.JewelID, item.Quantity);
                    db.TransactionDetails.Add(detail);
                }

                db.SaveChanges();

                return "Checkout Successful";

            }
        }


        public static List<TransactionHeader> GetUnfinishedTransactions()
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.TransactionHeaders.Where(t => t.TransactionStatus != "Done" && t.TransactionStatus != "Rejected").ToList();
        }

        public static String UpdateTransactionStatus(int transactionId, String newStatus)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            TransactionHeader transaction = db.TransactionHeaders.Find(transactionId);
            if (transaction != null)
            {
                transaction.TransactionStatus = newStatus;
                db.SaveChanges();
                return "Transaction status updated successfully";
            }
            return "Transaction not found";
        }

        public static List<TransactionHeader> GetTransactionsByUserId(int userId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.TransactionHeaders.Where(t => t.UserID == userId).ToList();
        }

        public static TransactionHeader GetTransactionById(int transactionId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.TransactionHeaders.FirstOrDefault(t => t.TransactionID == transactionId);
        }

        public static List<TransactionHeader> GetTransactions()
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.TransactionHeaders.ToList();
        }
    }
}