using APIModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Interfaces
{
    public interface IProjectInterface
    {
        /// <summary>
        /// Returns all projects
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task<List<Project>> GetProjects(string token);

        /// <summary>
        /// Returns Single selected Project
        /// </summary>
        /// <returns></returns>
        Task<Project> GetProject(int id);
        
        /// <summary>
        /// Adds new project to the project list
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        Task<Project> AddProject(Project1 project);

        /// <summary>
        /// Updated the selected project details
        /// </summary>
        /// <param name="project1"></param>
        /// <returns></returns>
        Task<Project> UpdateProject(Project1 project1);

        /// <summary>
        /// Delete Selected project
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> DeleteProject(int id);
    }
}
