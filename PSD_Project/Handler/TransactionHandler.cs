using PSD_Project.Model;
using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetTransactions()
        {
            return TransactionRepository.GetTransactions();
        }
    }
}