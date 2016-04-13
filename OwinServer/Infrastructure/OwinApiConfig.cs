using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using Owin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace OwinServer.Infrastructure
{
    public class OwinApiConfig
    {


        public void Configuration(IAppBuilder app)
        {
            // ************************
            // Configure the static files. Middleware
            // ************************

            const string rootFolder = "./wwwroot";
            var fileSystem = new PhysicalFileSystem(rootFolder);
            var options = new FileServerOptions
            {
                EnableDefaultFiles = true,
                FileSystem = fileSystem
            };
            app.UseFileServer(options);


            // ************************
            // Web.API Middleware
            // ************************

            //Configure Web API. 
            //var config = new HttpConfiguration();
            //config.Routes.MapHttpRoute(
            //    "DefaultApi", 
            //    "api/{controller}/{id}", 
            //    new { id = RouteParameter.Optional }
            //);
            //app.UseWebApi(config);

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            app.UseWebApi(config);

        }

    }
}
