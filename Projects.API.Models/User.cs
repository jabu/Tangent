using System;

namespace Projects.API.Models
{
    /// <summary>
    /// Projects API Microservices User Model
    /// </summary>
    public class User : APIModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public bool Is_Statff { get; set; }

        public bool Is_Supervisor { get; set; }

        public ProfileSerializer profileSerializer { get; set; }

    }
}
