using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using ITBCP.ServiceSIGES.Infraestructure.IoC;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Web.Http;
using ITBCP.ServiceSIGES.Services.Interfaces;
using System.Net;
using Newtonsoft.Json;

namespace ITBCP.ServiceSIGES.HostRest.Controladores
{
    
    public class AutenticationController : ApiController , ITS_SIAutentication
    {
        
        [HttpPost]
        public TS_BETerminal AuthorizeTerminal([FromBody]TS_BELogin input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.AuthorizeTerminal(input);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public List<TS_BEAccesos> GetAccesos([FromBody]TS_BEAccesos input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.GetAccesos(input);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        [HttpPost]
        public List<TS_BEEmpresaUser> GetEmpresaUser([FromBody]TS_BELogin input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.GetEmpresaUser(input);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        [HttpPost]
        public List<TS_BEModulo> GetModulos()
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.GetModulos();
            }
            catch (Exception e)
            {
                throw e; 

            }
        }

        [HttpPost]
        public List<TS_BENivel> GetNivel([FromBody]TS_BENivel input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.GetNivel(input);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        [HttpPost]
        [AllowAnonymous]
        public TS_BELoginOutPut Login([FromBody]TS_BELogin input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.Login(input);
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        [HttpPost]
        public TS_BELoginTurnoOutPut LoginTurno([FromBody]TS_BELoginTurno input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.LoginTurno(input);
            }
            catch (Exception e)
            {
                throw e;

            }
        }
    }
}
