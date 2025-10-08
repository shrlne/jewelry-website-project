using PSD_Project.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Controller
{
    public class JewelController
    {
        public static string AddJewel(string jewelName, string categoryIdStr, string brandIdStr, string priceStr, string releaseYearStr)
        {
            if (String.IsNullOrEmpty(jewelName) || String.IsNullOrEmpty(categoryIdStr) ||
                String.IsNullOrEmpty(brandIdStr) || String.IsNullOrEmpty(priceStr) || String.IsNullOrEmpty(releaseYearStr))
            {
                return "Please fill all the fields";
            }

            if (jewelName.Length < 3 || jewelName.Length > 25)
            {
                return "Jewel name must be between 3 and 25 characters";
            }

            if (!decimal.TryParse(priceStr, out decimal price) || price < 25)
            {
                return "Price must be a number and more than $25";
            }

            if (!int.TryParse(releaseYearStr, out int year) || year > DateTime.Now.Year)
            {
                return "Release Year must be a number and less than or equal to the current year";
            }

            if (!int.TryParse(categoryIdStr, out int categoryId))
            {
                return "Invalid category selected";
            }

            if (!int.TryParse(brandIdStr, out int brandId))
            {
                return "Invalid brand selected";
            }

            return JewelRepository.CreateNewJewel(jewelName, categoryId, brandId, (int)price, year);
        }

        public static string UpdateJewel(int jewelId, string name, string categoryIdStr, string brandIdStr, string priceStr, string releaseYearStr)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(categoryIdStr) || string.IsNullOrEmpty(brandIdStr)
                || string.IsNullOrEmpty(priceStr) || string.IsNullOrEmpty(releaseYearStr))
            {
                return "Please fill all the fields";
            }

            if (name.Length < 3 || name.Length > 25)
            {
                return "Jewel name must be between 3 and 25 characters";
            }

            if (!decimal.TryParse(priceStr, out decimal price) || price < 25)
            {
                return "Price must be a number and more than $25";
            }

            if (!int.TryParse(releaseYearStr, out int year) || year > DateTime.Now.Year)
            {
                return "Release Year must be a number and less than or equal to the current year";
            }

            if (!int.TryParse(categoryIdStr, out int categoryId))
            {
                return "Invalid category selected";
            }

            if (!int.TryParse(brandIdStr, out int brandId))
            {
                return "Invalid brand selected";
            }
            
            var existingJewel = JewelRepository.GetJewelById(jewelId);
            if (existingJewel == null)
            {
                return "Jewel not found";
            }

            return JewelRepository.UpdateJewel(jewelId, name, categoryId, brandId, (int)price, year);
        }
    }
}