using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APAutentication : ITS_AIAutentication
    {
        readonly bool IsToken = (ConfigurationManager.AppSettings["JWT_VALIDATE_TOKEN"].ToString() ?? "0").Equals("1");

        private readonly ITS_DOAutentication _ITS_DOAutentication;
        private readonly ITS_DOTerminal _ITS_DOTerminal;
        private readonly ITS_AIUtilities _ITS_AIUtilities;
        private readonly ITS_DOServer _ITS_DOServer;
        public TS_APAutentication(ITS_DOAutentication ITS_DOAutentication, ITS_DOTerminal ITS_DOTerminal, ITS_AIUtilities ITS_AIUtilities,ITS_DOServer ITS_DOServer)
        {
            _ITS_DOAutentication = ITS_DOAutentication;
            _ITS_DOTerminal = ITS_DOTerminal;
            _ITS_AIUtilities = ITS_AIUtilities;
            _ITS_DOServer = ITS_DOServer;
        }

        public  TS_BETerminal AuthorizeTerminal(TS_BELogin input)
        {
            TS_BETerminal output = new TS_BETerminal();
            if (string.IsNullOrEmpty(input.Serie))
            {
                output.Ok = false;
                output.Mensaje = Helpers.MessageUtils.Terminal.SerieEmpty;
                return output;
            }
            try
            {
                output = _ITS_DOTerminal.OBTENER_TERMINAL_POR_SERIEHD(new TS_BETerminal() { seriehd = input.Serie });
            }
            catch (Exception e)
            {
                throw new Exception(Helpers.RaiseError(e));

            }
            return output;
        }

        public List<TS_BEAccesos> GetAccesos(TS_BEAccesos input)
        {
            List<TS_BEAccesos> output = new List<TS_BEAccesos>();
            try
            {
                output = _ITS_DOAutentication.GetAccesos(input);
            }
            catch (Exception e)
            {
                throw new Exception(Helpers.RaiseError(e));

            }
            return output;
        }

        public List<TS_BEEmpresaUser> GetEmpresaUser(TS_BELogin input)
        {
            List<TS_BEEmpresaUser> output = new List<TS_BEEmpresaUser>();
            try
            {
                output = _ITS_DOAutentication.GetEmpresaUser(input);
            }
            catch (Exception e)
            {
                throw new Exception(Helpers.RaiseError(e));

            }
            return output;
        }

        public List<TS_BEModulo> GetModulos()
        {
            List<TS_BEModulo> output = new List<TS_BEModulo>();
            try
            {
                output = _ITS_DOAutentication.GetModulos();
            }
            catch (Exception e)
            {
                throw new Exception(Helpers.RaiseError(e));

            }
            return output;
        }

        public List<TS_BENivel> GetNivel(TS_BENivel input)
        {
            List<TS_BENivel> output = new List<TS_BENivel>();
            try
            {
                output = _ITS_DOAutentication.GetNivel(input);
            }
            catch (Exception e)
            {
                throw new Exception(Helpers.RaiseError(e));

            }
            return output;
        }

        public TS_BELoginOutPut Login(TS_BELogin input)
        {
            TS_BELoginOutPut entRetorno = new TS_BELoginOutPut();

            if (string.IsNullOrEmpty(input.cdusuario))
            {
                entRetorno.Ok = false;
                entRetorno.Mensaje = Helpers.MessageUtils.Login.UsuarioEmpty;
                return entRetorno;
            }

            if (string.IsNullOrEmpty(input.password))
            {
                entRetorno.Ok = false;
                entRetorno.Mensaje = Helpers.MessageUtils.Login.PasswordEmpty;
                return entRetorno;
            }

            try
            {
                List<TS_BEUsers> output = new List<TS_BEUsers>();
                input.password = _ITS_AIUtilities.CheckPassword(input.password);
                output = _ITS_DOAutentication.Login(input);
                if (output.Count > 0)
                {
                    entRetorno.Ok = true;
                    entRetorno.RetVal = 0;
                    entRetorno.Empresas = GetEmpresaUser(input);
                    entRetorno.Mensaje = Helpers.MessageUtils.Login.Autorizado;
                    entRetorno.Codigo = output[0].dsusuario;
                    entRetorno.Usuario = _ITS_DOServer.OBTENER_USUARIO(input.cdusuario ?? "");

                    if (IsToken)
                    {
                        entRetorno.JSONToken = _ITS_AIUtilities.GenerateTokenJwt(entRetorno.Codigo, input.password);

                        if (_ITS_DOAutentication.RegistraToken(entRetorno.Codigo, entRetorno.JSONToken))
                        {
                            return entRetorno;
                        }
                        else
                        {
                            entRetorno.Empresas = null;
                            entRetorno.Codigo = "";
                            entRetorno.JSONToken = "";
                            entRetorno.Ok = false;
                            entRetorno.RetVal = -1;
                            entRetorno.Mensaje = Helpers.MessageUtils.Login.NoAutorizado;
                            return entRetorno;
                        }
                    }
                    else if(IsToken == false)
                    {
                        return entRetorno;
                    } 
                }
                else
                {
                    entRetorno.Ok = false;
                    entRetorno.RetVal = -1;
                    entRetorno.Mensaje = Helpers.MessageUtils.Login.NoAutorizado;
                }
            }
            catch (Exception e)
            {
                throw new Exception(Helpers.RaiseError(e));

            }
            return entRetorno;
        }

        public bool IsValidToken(string usuario,string token)
        {
            if (String.IsNullOrEmpty(usuario))
            {
                return false;
            }
            if (String.IsNullOrEmpty(token))
            {
                return false;
            }
            return _ITS_DOAutentication.IsValidToken(usuario, token);
        }

        public TS_BELoginTurnoOutPut LoginTurno(TS_BELoginTurno input)
        {
            if (String.IsNullOrEmpty(input.cdusuario))
            {
                return new TS_BELoginTurnoOutPut() { Mensaje = "El codigo de usuario no puede estar en blanco" ,Ok = false};
            }
            if (String.IsNullOrEmpty(input.password))
            {
                return new TS_BELoginTurnoOutPut() { Mensaje = "La clave no puede estar en blanco", Ok = false };
            }
            if (String.IsNullOrEmpty(input.cdempresa))
            {
                return new TS_BELoginTurnoOutPut() { Mensaje = "No se específico la empresa, a la cual realizara el proceso", Ok = false };
            }

            input.password = _ITS_AIUtilities.CheckPassword(input.password);

            return _ITS_DOAutentication.LoginTurno(input);
        }
    }
}
