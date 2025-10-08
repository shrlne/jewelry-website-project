using PSD_Project.Factory;
using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Repository
{
    public class CartRepository
    {

        public static void AddToCart (int userId, int jewelId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities ();
            Cart existingCart = (from x in db.Carts where x.UserID == userId && x.JewelID == jewelId
                                 select x).FirstOrDefault ();
            if (existingCart != null)
            {
                existingCart.Quantity += 1;
            }
            else
            {
                Cart newItem = CartFactory.CreateNewCart(userId, jewelId);
                db.Carts.Add(newItem);
            }
            db.SaveChanges();
        }

        public static String CreateNewCart(int userId, int jewelId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities ();
            Cart newCart = CartFactory.CreateNewCart (userId, jewelId);
            db.Carts.Add(newCart);
            db.SaveChanges();
            return "New Cart has been created";
        }

        public static List<dynamic> GetCartByUser(int userId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            var result = from c in db.Carts
                         join j in db.MsJewels on c.JewelID equals j.JewelID
                         join mb in db.MsBrands on j.BrandID equals mb.BrandID
                         where c.UserID == userId
                         select new
                         {
                             c.JewelID, j.JewelName, j.JewelPrice, mb.BrandName, c.Quantity, SubTotal = c.Quantity * j.JewelPrice
                         };
            return result.ToList<dynamic>();
        }

        public static String UpdateCart(int userId, int jewelId, int newQuantity)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities ();
            Cart cart = (from x in db.Carts where x.UserID == userId && x.JewelID == jewelId select x).FirstOrDefault();
            if (cart != null)
            {
                cart.Quantity = newQuantity;
                db.SaveChanges();
                return "Cart updated successfully";
            }
            return "Cart item not found";
        }

        public static void RemoveItemFromCart(int jewelId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            Cart cart = (from x in db.Carts where x.JewelID == jewelId select x).FirstOrDefault();
            if (cart != null)
            {
                db.Carts.Remove(cart);
                db.SaveChanges();
            }
        }

        public static void ClearCart(int userId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            var userCart = db.Carts.Where(c  => c.UserID == userId).ToList();
            foreach (var item in userCart)
            {
                db.Carts.Remove(item);
            }
            db.SaveChanges();
        }

    }
}