using APIServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Projects.API.Jabu.IoC;
using System.Threading.Tasks;
using APIModels;

namespace Projects.API.Jabu.Controllers
{
    public class ProjectsController : ApiController
    {
        IProjectInterface _projectInterface { get; set; }

        public ProjectsController(): this(DependencyFactory.Resolve<IProjectInterface>())
        {

        }

        public ProjectsController(IProjectInterface projectsInterface)
        {
            _projectInterface = projectsInterface;
        }

        // GET: api/Projects
        [HttpGet]
        [Route("api/projects")]
        public async Task<List<Project>> Get(string token)
        {
            List<Project> projects = await _projectInterface.GetProjects(token);
            return projects;
        }

        [Route("api/post")]
        [HttpGet]
        public async Task<Project> Get([FromBody] Project1 prj)
        {
           
            try
            {               
                Project p;
                p = new Project();
                p = await _projectInterface.AddProject(prj);
                return p;
            }
            catch (Exception e)
            {
                throw new System.Web.HttpException(404, e.InnerException.ToString());
            }

           
        }

    }
}
