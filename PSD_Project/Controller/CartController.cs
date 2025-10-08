using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Controller
{
    public class CartController
    {
        public static List<dynamic> GetCart(int userId)
        {
            return CartRepository.GetCartByUser(userId);
        }

        public static string UpdateCart(int userId, int jewelId, int quantity)
        {
            if (quantity <= 0)
            {
                return "Quantity must be greater than 0";
            }

            return CartRepository.UpdateCart(userId, jewelId, quantity);
        }

        public static void RemoveItem(int jewelId)
        {
            CartRepository.RemoveItemFromCart(jewelId);
        }

        public static void ClearCart(int userId)
        {
            CartRepository.ClearCart(userId);
        }

        public static string Checkout(int userId, string paymentMethod)
        {
            if (string.IsNullOrEmpty(paymentMethod) || paymentMethod == "-- Select Payment Method --")
            {
                return "Please select a valid payment method";
            }

            string result = TransactionRepository.CreateNewTransaction(userId, paymentMethod);
            CartRepository.ClearCart(userId);
            return result;
        }

        public static decimal CalculateTotal(List<dynamic> cartData)
        {
            return cartData.Sum(x => x.SubTotal);
        }
    }
}