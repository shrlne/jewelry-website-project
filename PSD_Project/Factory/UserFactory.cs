using PSD_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSD_Project.Factory
{
    public class UserFactory
    {
        public static MsUser CreateNewUser(String email, String username, String password,
                                            String gender, DateTime dob, String role)
        {
            MsUser newUser = new MsUser();
            newUser.UserEmail = email;
            newUser.UserName = username;
            newUser.UserPassword = password;
            newUser.UserGender = gender;
            newUser.UserDOB = dob;
            newUser.UserRole = role;
            return newUser;
        }
    }
}