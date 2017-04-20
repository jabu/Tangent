using System;

namespace APIModels
{
    /// <summary>
    /// Projects API Microservices User Model
    /// </summary>
    public class User : APIModel
    {
        
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string username { get; set; }       

        public string Email { get; set; }

        public bool Is_Statff { get; set; }

        public bool Is_Supervisor { get; set; }

        public ProfileSerializer profileSerializer { get; set; }

        public AppAuthorizationSerializer appAuthorizationSerializer { get; set; }

    }
}
