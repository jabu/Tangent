using System;
using System.Collections.Generic;
using System.Text;
using APIModels;
using System.Threading.Tasks;

namespace APIServices.Interfaces
{
    public interface IUserService
    {
        Task<string> GetUserToken(string username, string password);
    }
}
