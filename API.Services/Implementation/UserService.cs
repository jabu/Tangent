using System;
using System.Collections.Generic;
using System.Text;
using APIServices.Interfaces;
using APIModels;
using Microsoft.Practices.Unity;
using APIServices.Helpers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace APIServices.Implementation
{
    public class UserService : HttpService, IUserService, IDisposable
    {
        // API
        public UserService()
        {
            this.BaseUrl = "http://userservice.staging.tangentmicroservices.com:80/";
        }

        public async Task<string> GetUserToken(string username, string password)
        {
            var postContent = JsonConvert.SerializeObject(new { username = username, password = password });
            var result = await this.Post(postContent, "api-token-auth/");

            if (!string.IsNullOrEmpty(result))
            {
                object user = JsonConvert.DeserializeObject(result);

                return user.ToString();
            }
            else
            {
                throw new Exception("Error Occured");
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
