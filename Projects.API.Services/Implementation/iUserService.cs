using APIServices.Interfaces;

namespace APIServices.Implementation
{
    public class iUserService : IUserService
    {
        string username = "";
        string password = "";
        ProfileSerializer p = new ProfileSerializer();
       


        public User GetUser()
        {
            p.Bio = "test";
            p.Contact_Number = "test";
            p.Status_Message = "test";

            return new User() { FirstName = "JB", Email = "test", Id = "1", ID = 1, Is_Statff = true, Is_Supervisor = false, LastName = "test", profileSerializer = p };
        }
    }
}
