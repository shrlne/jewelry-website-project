using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Factory
{
    public class JewelFactory
    {
        public static MsJewel CreateNewJewel(String jewelName, int categoryID, int brandID,
                                             int price, int releaseYear)
        {
            MsJewel newJewel = new MsJewel();
            newJewel.JewelName = jewelName;
            newJewel.CategoryID = categoryID;
            newJewel.BrandID = brandID;
            newJewel.JewelPrice = price;
            newJewel.JewelReleaseYear = releaseYear;
            return newJewel;
        }
    }
}