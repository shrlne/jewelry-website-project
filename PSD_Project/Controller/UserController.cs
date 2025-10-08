using PSD_Project.Model;
using PSD_Project.Repository;
using System;
using System.Text.RegularExpressions;
using System.Web;

namespace PSD_Project.Controller
{
    public class UserController
    {
        public static string Login(string email, string password, bool isRemember)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return "Please fill all the fields";

            MsUser loginUser = UserRepository.LoginUser(email, password);
            if (loginUser == null)
                return "Incorrect account";

            if (loginUser.UserRole == "Admin")
                HttpContext.Current.Session["admin"] = loginUser;
            else
                HttpContext.Current.Session["customer"] = loginUser;

            HttpCookie cookie = new HttpCookie("userCookie")
            {
                Value = loginUser.UserID.ToString(),
                Expires = DateTime.Now.AddDays(1)
            };

            if (isRemember)
                HttpContext.Current.Response.Cookies.Add(cookie);
            else
                HttpContext.Current.Response.Cookies.Remove("userCookie");

            return "Login successful";
        }

        public static string Register(string email, string username, string password, string confirmPassword, string gender, string dobText)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) ||
                string.IsNullOrWhiteSpace(gender))
                return "Please fill all the fields";

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return "Email must be a valid email format and must be unique";

            if (username.Length < 3 || username.Length > 25)
                return "Username must be between 3 and 25 characters";

            if (!Regex.IsMatch(password, @"^[a-zA-Z0-9]{8,20}$"))
                return "Password must be between 8 and 20 characters and can only contain letters and numbers";

            if (confirmPassword != password)
                return "Password and Confirm Password must match";

            if (!DateTime.TryParse(dobText, out DateTime dob))
                return "Invalid date format. Please enter a valid date.";

            if (dob >= new DateTime(2010, 1, 1))
                return "Date of birth must be earlier than 01/01/2010";

            if (UserRepository.CheckExist(email, username))
                return "Email or Username already exists";

            string role = email.Contains("Admin") ? "Admin" : "Customer";

            string result = UserRepository.CreateNewUser(email, username, password, gender, dob, role);
            if (result != "Success")
                return "Failed to register";

            MsUser user = UserRepository.GetUserByEmail(email);
            if (role == "Admin")
                HttpContext.Current.Session["admin"] = user;
            else
                HttpContext.Current.Session["customer"] = user;

            return "Register successful";
        }

        public static bool ValidateOldPassword(MsUser user, string oldPassword)
        {
            return user.UserPassword == oldPassword;
        }

        public static bool ValidateNewPassword(string newPassword)
        {
            return Regex.IsMatch(newPassword, @"^[a-zA-Z0-9]{8,25}$");
        }

        public static string ChangePassword(MsUser user, string newPassword)
        {
            return UserRepository.UpdatePassword(user.UserID, newPassword);
        }
    }
}
