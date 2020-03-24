using Topshelf;
using System;
using Microsoft.Owin.Hosting;
using System.Web.Http;
using Owin;
using System.Configuration;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Infraestructure.IoC;
using ITBCP.ServiceVisaNet.Host.Attributes;

namespace ITBCP.ServiceSIGES.HostRest
{

    public class Service
    {
       
        public static void Main(string[] args)
        {
            HostFactory.Run(runnable =>
            {
                runnable.Service<WebServer>(service =>
                {
                    service.ConstructUsing(name => new WebServer());
                    service.WhenStarted(tc => tc.Start());
                    service.WhenStopped(tc => tc.Stop());
                });
                runnable.RunAsLocalSystem();
                runnable.SetServiceName("TERMINAL SIGES");
            }
            );
         
        }
    }

    internal class WebServer
    {

        private IDisposable _webapp;

        public void Start()
        {
            _webapp = WebApp.Start<Startup>(ConfigurationManager.AppSettings["ServiceRoute"].ToString());
        }

        public void Stop()
        {
            _webapp?.Dispose();
        }
    }

    internal class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
       
            config.MapHttpAttributeRoutes();
     
            config.Routes.MapHttpRoute(
                name: ConfigurationManager.AppSettings["name"].ToString(),
                routeTemplate: ConfigurationManager.AppSettings["routeTemplate"].ToString(),
                defaults: new { id = RouteParameter.Optional }
            );
            config.Filters.Add(new DinamicAuthorizeAttribute());
            app.UseWebApi(config);
        }

    }


}
