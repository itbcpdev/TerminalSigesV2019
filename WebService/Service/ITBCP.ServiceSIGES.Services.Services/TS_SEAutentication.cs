
using ITBCP.ServiceSIGES.Aplication;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using ITBCP.ServiceSIGES.Infraestructure.IoC;
using ITBCP.ServiceSIGES.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel; 

namespace ITBCP.ServiceSIGES.Services.Services
{
    public class TS_SEAutentication : ITS_SIAutentication
    {
        public TS_BETerminal AuthorizeTerminal(TS_BELogin input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.AuthorizeTerminal(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("AuthorizeTerminal"));

            }
        }

        public List<TS_BEAccesos> GetAccesos(TS_BEAccesos input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.GetAccesos(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("GetAccesos"));

            }
        }

        public List<TS_BEEmpresaUser> GetEmpresaUser(TS_BELogin input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.GetEmpresaUser(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("GetEmpresaUser"));

            }
        }

        public List<TS_BEModulo> GetModulos()
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.GetModulos();
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("GetModulos"));

            }
        }

        public List<TS_BENivel> GetNivel(TS_BENivel input)
        {
            try
            {
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                return _ITS_AIAutentication.GetNivel(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("GetNivel"));

            }
        }

        public TS_BELoginOutPut Login(TS_BELogin input)
        {
            TS_BELoginOutPut entRetorno = new TS_BELoginOutPut();
            try
            {
               
                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                entRetorno = _ITS_AIAutentication.Login(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("Login"));

            }
            return entRetorno;
        }

        public TS_BELoginTurnoOutPut LoginTurno(TS_BELoginTurno input)
        {
            TS_BELoginTurnoOutPut entRetorno = new TS_BELoginTurnoOutPut();
            try
            {

                ITS_AIAutentication _ITS_AIAutentication = FabricaIoC.Contenedor.Resolver<ITS_AIAutentication>();
                entRetorno = _ITS_AIAutentication.LoginTurno(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("LoginTurno"));

            }
            return entRetorno;
        }
    }
}
