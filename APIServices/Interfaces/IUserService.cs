using System;
using System.Collections.Generic;
using System.Text;
using APIModels;

namespace APIServices.Interfaces
{
    public interface IUserService
    {
        User GetUser();
    }
}
