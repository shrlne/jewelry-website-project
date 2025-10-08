using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Factory
{
    public class CartFactory
    {

        public static Cart CreateNewCart (int userId, int jewelId)
        {
            Cart newCart = new Cart ();
            newCart.UserID = userId;
            newCart.JewelID = jewelId;
            newCart.Quantity = 1;
            return newCart;
        }
    }
}