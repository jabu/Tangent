using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using APIModels;
using APIServices.Implementation;
using System.IO;
using System.Web.Script.Serialization;
using System.Net.Http.Headers;
using System.Text;
using System.Collections.Specialized;
using System.Web;
using APIServices.Interfaces;
using Microsoft.Practices.Unity;
using Projects.API.Jabu.IoC;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.SessionState;

namespace Projects.API.Jabu.Controllers
{
    public class UserController : ApiController, IRequiresSessionState
    {       
        IUserService _userService { get; set; }
        
        public UserController() : this(DependencyFactory.Resolve<IUserService>())
        {

        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> GetToken()
        {
            string u = await _userService.GetUserToken("jacob.zuma", "tangent");
            return u;
        }
        
        // GET: api/User
        [HttpGet]
        [Route("api/User")]
        public async Task<List<Project>> Get()
        {
            try
            {
                List<Project> projects = new List<Project>();
                var u = await _userService.GetUserToken("jacob.zuma", "tangent");
                if (u != string.Empty || u != null)
                {
                    var session = HttpContext.Current.Session;
                    if(session != null)
                    {
                        session["token"] = u.ToString();
                    }
                    
                    ProjectsController projectsFetcher = new ProjectsController();
                    projects = await projectsFetcher.Get(u);
                    
                }
                return projects;
            }
            catch (Exception ex)
            {
                throw new HttpException(404, "User not found");
            }
        }

        [HttpPost]
        // POST: api/User
        [Route("api/User")]
        public HttpResponseMessage Post([FromUri]string value)
        {
            User user = new APIModels.User();
            HttpResponseMessage response = null;

           
            return response;
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
