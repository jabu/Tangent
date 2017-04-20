using APIModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.Interfaces
{
    public interface IProjectInterface
    {
        Task<List<Project>> GetProjects(string token);

        Task<Project1> Post(Project1 project);
        Task<Project1> GetUserToken(Project1 project);
    }
}
