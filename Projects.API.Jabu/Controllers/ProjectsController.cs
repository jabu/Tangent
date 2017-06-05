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

        [HttpDelete]
        public async Task<string> DeleteProject(int id)
        {
            try
            {
                string results = "";
                results = await _projectInterface.DeleteProject(id);
                return results;
            }
            catch (Exception e)
            {
                throw new System.Web.HttpException(404, e.InnerException.ToString());
            }
        }

        [HttpGet]
        public async Task<Project> UpdateProject([FromBody]Project1 prj)
        {
            try
            {
                Project project = new Project();
                project = await _projectInterface.UpdateProject(prj);
                return project;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet]
        public async Task<Project> GetProject(int id)
        {
            try
            {
                Project project = new Project();
                project = await _projectInterface.GetProject(196);
                return project;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
