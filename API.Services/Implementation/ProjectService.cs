﻿using APIServices.Helpers;
using APIServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APIModels;
using Newtonsoft.Json;
using System.Web;
using System.Net.Http;

namespace API.Services.Implementation
{
    public class ProjectService : HttpService, IProjectInterface, IDisposable
    {
        public ProjectService()
        {
            this.BaseUrl = "http://projectservice.staging.tangentmicroservices.com:80/";
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Project>> GetProjects(string token)
        {
            TokenObject tokenValue = new TokenObject();          
            JsonConvert.PopulateObject(token , tokenValue);
            this.AuthToken = tokenValue.token;
            var result = await this.Get("api/v1/projects/");

             if (!string.IsNullOrEmpty(result))
            {
                List<Project> projects = new List<Project>();
                
                JsonConvert.PopulateObject(result, projects);
                return projects;
            }
            else
            {
                throw new HttpException(404, "Projects not found");
            }
        }

        public async Task<Project> GetProject(int id)
        {
            string token = HttpContext.Current.Session["token"].ToString();
            HttpResponseMessage m = new HttpResponseMessage();
            Project project = new Project();

            TokenObject tokenValue = new TokenObject();
            JsonConvert.PopulateObject(token, tokenValue);
            this.AuthToken = tokenValue.token;

            var result = await this.Get("api/v1/projects/195/");

            if (!string.IsNullOrEmpty(result))
            {
                JsonConvert.PopulateObject(result, project);
                return project;
            }
            else
            {
                throw new HttpException(404, "Projects not found");
            }
        }

        public async Task<Project> AddProject(Project1 project1)
        {
            string token = HttpContext.Current.Session["token"].ToString();
            HttpResponseMessage m = new HttpResponseMessage();
            Project p = new Project();

            TokenObject tokenValue = new TokenObject();
            JsonConvert.PopulateObject(token, tokenValue);
            this.AuthToken = tokenValue.token;

            var postContent = JsonConvert.SerializeObject(new { title = "Testing Last", description = "Testing Last", start_date = "2020-05-05", end_date = "2022-06-05", is_billable=true, is_active=true });

            var result = await this.Post(postContent, "api/v1/projects/");

            if (!string.IsNullOrEmpty(result))
            {
                object Rproject = JsonConvert.DeserializeObject(result);

                JsonConvert.PopulateObject(result, p);

                return p;
            }
            else
            {
                throw new Exception("Error Occured");
            }
        }

        public async Task<Project> UpdateProject(Project1 project1)
        {
            string token = HttpContext.Current.Session["token"].ToString();
            HttpResponseMessage m = new HttpResponseMessage();
            Project p = new Project();

            TokenObject tokenValue = new TokenObject();
            JsonConvert.PopulateObject(token, tokenValue);
            this.AuthToken = tokenValue.token;

            var postContent = JsonConvert.SerializeObject(new { pk = 196, title = "Updated", description = "Updated", start_date = "2005-05-05", end_date = "2008-06-05", is_billable = false, is_active = false });

            var result = await this.Put(postContent, "api/v1/projects/196/");

            if (!string.IsNullOrEmpty(result))
            {
                object Rproject = JsonConvert.DeserializeObject(result);

                JsonConvert.PopulateObject(result, p);

                return p;
            }
            else
            {
                throw new Exception("Error Occured");
            }
        }

        public async Task<string> DeleteProject(int id)
        {
            string token = HttpContext.Current.Session["token"].ToString();
            HttpResponseMessage m = new HttpResponseMessage();

            TokenObject tokenValue = new TokenObject();
            JsonConvert.PopulateObject(token, tokenValue);
            this.AuthToken = tokenValue.token;            

            var result = await this.Delete("api/v1/projects/192/");

            if (!string.IsNullOrEmpty(result))
            {
                return result.ToString();
            }
            else
            {
                throw new Exception("Error Occured");
            }
        }
    }


    public class TokenObject
    {
        public string token { get; set; }
    }
}
