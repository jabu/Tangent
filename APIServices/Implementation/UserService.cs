using System;
using System.Collections.Generic;
using System.Text;
using APIServices.Interfaces;
using APIModels;

namespace APIServices.Implementation              
{
    public class UserService : IUserService
    {
        string username = "";
        string password = "";
        ProfileSerializer p = new ProfileSerializer();

        public string Username { get => username; set => username = value; }
        public string Password { get => Password; set => Password = value; }

        public User GetUser()
        {
            p.Bio = "test";
            p.Contact_Number = "test";
            p.Status_Message = "test";

            return new User() { FirstName = "JB", Email = "test", Id = "1", ID = 1, Is_Statff = true, Is_Supervisor = false, LastName = "test", profileSerializer = p };
        }
    }
}
