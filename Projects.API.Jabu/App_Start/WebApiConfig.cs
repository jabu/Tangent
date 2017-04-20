using APIServices.Implementation;
using APIServices.Interfaces;
using Microsoft.Practices.Unity;
using Projects.API.Jabu.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Projects.API.Jabu
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "PostObject",
                routeTemplate: "api/{controller}",
                defaults: new { controller = "Projects", action = "Post", Project = "" }
            );
        }
    }
}
