using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIModels;
using APIServices.Interfaces;
using APIServices.Implementation;

namespace ProjectsAPI.Controllers
{
    public class UserController : ApiController
    {        
       private readonly IUserService _userService;

            // GET: api/values
            [HttpGet]
            public User Get()
            {
                User result = null;
                try
                {
                    var service = new UserService();
                    result = service.GetUser();


                }
                catch (Exception
                ex)
                {

                }
                return result;

            }        
    }
}
