using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Infraestructure.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ITBCP.ServiceVisaNet.Host.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class DinamicAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly ITS_AIUtilities ITS_AIUtilities;
        private readonly ITS_AIAutentication ITS_AIAutentication;

        public DinamicAuthorizeAttribute()
        { 
            this.ITS_AIUtilities = FabricaIoC.Contenedor.Resolver<ITS_AIUtilities>(); ;
            this.ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>(); ;
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (ITS_AIUtilities.VerifyToken(actionContext.Request, out string name,out string token))
            {
                return ITS_AIAutentication.IsValidToken(name,token);
            }
            else
            {
                return false;
            }
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
           
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }
            if (SkipAuthorization(actionContext))
            {
                return;
            }

            bool Autorized = IsAuthorized(actionContext);

            if (Autorized)
            {
                return;
            }
            else if(!Autorized)
            {
                HandleUnauthorizedRequest(actionContext);
                return;
            }
        }
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            HttpResponseMessage result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                RequestMessage = actionContext.Request
            };

            actionContext.Response = result;
        }

        protected void HandleForbiddenRequest(HttpActionContext actionContext)
        {
            if (actionContext == null)
            {
                throw new ArgumentNullException("actionContext");
            }

            HttpResponseMessage result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Forbidden,
                RequestMessage = actionContext.Request
            };

            actionContext.Response = result;
        }
        protected bool SkipAuthorization(HttpActionContext actionContext)
        {
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                   || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}
