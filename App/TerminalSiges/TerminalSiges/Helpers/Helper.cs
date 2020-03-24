using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.Text;

namespace TerminalSiges.Lib.Include
{
   public  class Helper
    {
        public static bool TieneInternet()
        {
            string CheckUrl = "http://google.com";
            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);
                iNetRequest.Timeout = 5000;
                WebResponse iNetResponse = iNetRequest.GetResponse();
                iNetResponse.Close();
                return true;
            }
            catch 
            {
                return true;
                //TODO: Quitar validación de internet
            }
        }
        public static bool VerificaDominio(string dominio)
        {
            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(dominio.Trim());
                iNetRequest.Timeout = 5000;
                WebResponse iNetResponse = iNetRequest.GetResponse();
                iNetResponse.Close();

                return true;
            }
            catch
            {
                return false;
                //TODO: Quitar validación de internet
            }
        }
        public static bool ValidaDominio(string dominio)
        {
            var url = dominio.Split('@');
            try
            {
                if (VerificaDominio("http://" + url[1]) | VerificaDominio("https://" + url[1]))
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
                //TODO: Quitar validación de internet
            }
        }
        public static DateTime? ConvertirAFechaReal(string strfecha)
        {
            try
            {
                var soloFecha = strfecha.Trim().Split(' ')[0];
                var fechaPartes = soloFecha.Split('/');
                return new DateTime(int.Parse(fechaPartes[2]), int.Parse(fechaPartes[1]), int.Parse(fechaPartes[0]));
            }
            catch
            {
                return null;
            }
        }
        public static string ConvertirAFechaStringLocal(string strfecha)
        {
            var fecha = ConvertirAFechaReal(strfecha);
            if (fecha == null)
            {
                return strfecha;
            }
            return fecha.Value.ToString("MM/dd/yyyy");
        }
        public static string ConvertirAFechaString(string strfecha)
        {
            var fecha = ConvertirAFechaReal(strfecha);
            if (fecha == null)
            {
                return strfecha;
            }
            return fecha.Value.ToString("dd/MM/yyyy");
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

            var timeout = new TimeSpan(0, 2, 0);
            binding.SendTimeout = timeout;
            binding.OpenTimeout = timeout;
            binding.ReceiveTimeout = timeout;
            return binding;
        }
        public static bool IsNumero(string dato)
        {
            try
            {
                long result = Convert.ToInt64(dato);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsRucValido(string dato)
        {
            return (!(string.IsNullOrEmpty(dato) || !IsNumero(dato) || dato.Length != 11 || !Valruc(dato)));
        }
        public static bool Valruc(string valor)
        {
            valor = valor.Trim();
            if (IsNumero(valor))
            {
                if (valor.Length == 11)
                {
                    var suma = 0;
                    var x = 6;
                    for (int i = 0; i < valor.Length - 1; i++)
                    {
                        if (i == 4) x = 8;
                        var digito = valor[i] - '0';
                        x--;
                        if (i == 0) suma += (digito * x);
                        else suma += (digito * x);
                    }
                    var resto = suma % 11;
                    resto = 11 - resto;
                    if (resto >= 10) resto = resto - 10;
                    if (resto == valor[(valor.Length - 1)] - '0')
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
