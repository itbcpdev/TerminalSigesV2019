using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalSiges.Lib.Include
{
    public class Config
    {
        public static class Services
        {
            public const string SerieHdKey = "serie_hd";
            public const string ServiceUrlKey = "url_service";
            public const string PrintKey = "print_key";

            public static bool PrintAvaliable = false;

            public static string AutenticateName = "/Autentication.svc";
            public static string SalesName = "/Sales.svc";
            public static string ImpresionName = "/Impresion.svc";

            public static string Autenticate = "/Autentication.svc";
            public static string Sales = "/Sales.svc";
            public static string Impresion = "/Impresion.svc";
        }
    }
}
