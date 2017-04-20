using APIServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIModels;

namespace API.Services.Implementation
{
    public class BrokenUserService : IUserService
    {
        public Task<string> GetUserToken(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
