using PSD_Project.Factory;
using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Repository
{
    public class JewelRepository
    {
        public static List<MsJewel> GetAllJewels()
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.MsJewels.ToList();
        }
        public static List<MsCategory> GetAllCategories()
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.MsCategorys.ToList();

        }
        public static List<MsBrand> GetAllBrands()
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.MsBrands.ToList();

        }
        public static String CreateNewJewel(String jewelName, int categoryId, int brandId, int price, int releaseYear)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            MsJewel newJewel = JewelFactory.CreateNewJewel(jewelName, categoryId, brandId, price, releaseYear);
            db.MsJewels.Add(newJewel);
            db.SaveChanges();
            return "Jewel added successfully";
        }

        public static MsJewel GetJewelById(int jewelId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.MsJewels.Find(jewelId);
        }

        public static MsBrand GetBrandById(int brandId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.MsBrands.Find(brandId);
        }
        public static MsCategory GetCategoryById(int categoryId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.MsCategorys.Find(categoryId);
        }

        public static void DeleteJewelById(int id)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            MsJewel msJewel = db.MsJewels.Find(id);
            if (msJewel != null)
            {
                db.MsJewels.Remove(msJewel);
                db.SaveChanges() ;
            }
        }

        public static String UpdateJewel(int jewelId, String jewelName, int categoryId, int brandId, int price, int releaseYear)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            var jewel = db.MsJewels.Find(jewelId);
            if (jewel != null)
            {
                jewel.JewelName = jewelName;
                jewel.CategoryID = categoryId;
                jewel.BrandID = brandId;
                jewel.JewelPrice = price;
                jewel.JewelReleaseYear = releaseYear;
                
                db.SaveChanges();
                return "Success";
            }
            else
            {
                return "Failed";
            }
        }

    }
}