using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateNewTransaction(int userId, DateTime transactionDate,
                                                                String paymentMethod, String transactionStatus)
        {
            TransactionHeader newTransaction = new TransactionHeader();
            newTransaction.UserID = userId;
            newTransaction.TransactionDate = transactionDate;
            newTransaction.PaymentMethod = paymentMethod;
            newTransaction.TransactionStatus = transactionStatus;
            return newTransaction;
        }

        public static TransactionDetail CreateNewDetail(int transactionId, int jewelId, int quantity)
        {
            TransactionDetail newDetail = new TransactionDetail();
            newDetail.TransactionID = transactionId;
            newDetail.JewelID = jewelId;
            newDetail.Quantity = quantity;
            return newDetail;
        }

        
    }
}