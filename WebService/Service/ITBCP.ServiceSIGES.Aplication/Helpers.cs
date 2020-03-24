using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class Helpers
    {
        public static string RaiseError(Exception e)
        {
            StackTrace trace = new StackTrace(e, true);
            string errDataAccess = "DA." + trace.GetFrame(0).GetMethod().ReflectedType.Name + "." + trace.GetFrame(0).GetMethod().Name + ", ";
            string errBusinessLogic = "BL." + trace.GetFrame(1).GetMethod().ReflectedType.Name + "." + trace.GetFrame(1).GetMethod().Name +
                " Number line: " + trace.GetFrame(1).GetFileLineNumber() +
                " Description: " + e.Message;
            return "Source: " + errDataAccess + errBusinessLogic;
        }
        public static BasicHttpBinding ServicioSoapBinding()
        {
            var binding = new BasicHttpBinding()
            {
                Name = "basicHttpBinding",
                MaxReceivedMessageSize = 67108864,

            };

            binding.ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas()
            {
                MaxArrayLength = 2147483646,
                MaxStringContentLength = 5242880,
            };

            var timeout = new TimeSpan(0, 1, 0);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            return binding;
        }
        public static class MessageUtils
        {   public static class Terminal
            {
                public static string SerieEmpty = "Nro Serie no puede estar vacio, configure por favor.";
           }
            public static class Login
            {
                public static string Autorizado = "Ingreso autorizado...!!!";
                public static string NoAutorizado = "Usuario o Contraseña incorrecto, intenta nuevamente por favor.";
                public static string NoAutorizadoTurno = "Usuario no autorizado, comuníquese con su supervisor.";
                public static string UsuarioEmpty = "Usuario no puede estar vacio, ingrese por favor.";
                public static string PasswordEmpty = "Contraseña no puede estar vacio, ingrese por favor.";
            }
            public static class Sunat
            {
                public static class Errors
                {
                    public static string ErrorNull => "Ingrese los datos correctos. Por favor, intente nuevamente.";
                    public static string Vacio => "&nbsp;\r\n                    \r\n                ";
                    public static string Conectividad => "Existen problemas de conectividad con la SUNAT.";
                    public static string Lentitud => "El servicio de la SUNAT está demorando en responder.";
                    public static string UsuarioVacio => "Debe ingresar un Usuario.";

                    public static string UsuarioInvalido =>
                        "Usuario no cumple con las especificaciones, por favor ingrese correctamente.";
                    public static string ClaveVacio => "Debe ingresar una Clave.";

                    public static string ClaveInvalida =>
                        "Contraseña no cumple con las especificaciones, por favor ingrese correctamente.";
                    public static string RucInvalido => "Ingrese un Nro. de RUC válido, posiblemente el campo está vacío o el RUC no es válido.";
                    public static string RucUsuarioInvalido => "El Usuario ingresado no existe.";
                    public static string RucPersonaJuridica => "RUC ingresado no pertenece a una persona jurídica, por favor ingrese número RUC válido";
                    public static string RucPersonaNatural => "RUC ingresado no pertenece a una persona natural, por favor ingrese número RUC válido";

                    public static string SunatError =>
                        "Ha ocurrido un error en la validación con SUNAT, por favor intente mas tarde.";
                }
            }
        }
    }
}
