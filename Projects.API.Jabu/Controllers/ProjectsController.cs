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
        public async Task<Project1> Get([FromBody] Project1 prj)
        {
           
            try
            {
                //TaskProjectSerializer tps = new TaskProjectSerializer() { Title = "Test", Description = "TEst", Start_date = new DateTime(2017, 05, 05), End_date = new DateTime(2017, 07, 05), Is_active = true, Is_Billable = true };
                Project1 p;
                //TaskSerializer[] t = new TaskSerializer[1];
                //TaskSerializer ts = new TaskSerializer() { Id = 1, Due_date = new DateTime(2017, 05, 01), Estimated_Hours = 12, Project_data = tps, Title = "Task Serializer" };
                //t[0] = ts;
                //ResourceSerializer[] r = new ResourceSerializer[1];
                //ResourceSerializer rs = new ResourceSerializer() { id = 1, Start_date = new DateTime(2017, 05, 05), End_date = new DateTime(2017, 06, 05), Agreed_hours_per_month = 240, Created = new DateTime(2017, 05, 05), Rate = 154, Updated = new DateTime(2017, 05, 05), User = "Test" };
                //r[0] = rs;
                //var p = new Project1() {title = "TestingPoject 5", description = "Test Post", start_date = new DateTime(2017, 05, 05), end_date = new DateTime(2018, 05, 05), is_billable = true, is_active = true };
                p = new Project1();
                p = await _projectInterface.GetUserToken(p);

                return p;
            }
            catch (Exception e)
            {
                throw new System.Web.HttpException(404, e.InnerException.ToString());
            }

           
        }

    }
}
