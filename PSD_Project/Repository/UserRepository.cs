using PSD_Project.Factory;
using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Repository
{
    public class UserRepository
    {
        public static String CreateNewUser (String email, String username, String password,
                                            String gender, DateTime dob, String role)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            MsUser newUser = UserFactory.CreateNewUser(email, username, password, gender, dob, role);
            db.MsUsers.Add(newUser);
            db.SaveChanges();
            return "Success";
        }

        public static MsUser LoginUser (String email, String password)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            MsUser loginUser = (from x in db.MsUsers where x.UserEmail == email && x.UserPassword == password 
                                select x).FirstOrDefault();
            return loginUser;
        }

        public static MsUser GetUserById(int userId)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            MsUser user = (from x in db.MsUsers where x.UserID == userId select x).FirstOrDefault();
            return user;
        }

        public static bool CheckExist (String email, String username)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.MsUsers.Any(x => x.UserEmail == email || x.UserName == username);
        }

        public static MsUser GetUserByEmail (String email)
        {
            LocalDatabaseEntities db = new LocalDatabaseEntities();
            return db.MsUsers.FirstOrDefault(x => x.UserEmail == email);
        }

        public static String UpdatePassword (int userId, String newPassword)
        {
            try
            {
                LocalDatabaseEntities db = new LocalDatabaseEntities();
                var user = db.MsUsers.FirstOrDefault(x => x.UserID == userId);
                if (user != null)
                {
                    user.UserPassword = newPassword;
                    db.SaveChanges();
                    return "Success";
                }
                return "User Not Found";
            }
            catch (Exception)
            {
                return "Error";
            }
        }
    }
}