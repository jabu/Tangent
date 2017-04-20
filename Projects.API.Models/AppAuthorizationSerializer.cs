using System;
using System.Collections.Generic;
using System.Text;

namespace Projects.API.Models
{
    public class AppAuthorizationSerializer
    {
        public int ID { get; set; }

        public string Service_Name { get; set; }

        public string Key { get; set; }

        public string Token { get; set; }
    }
}
