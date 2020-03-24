using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalSiges.Lib.Sales
{
    public static class TSSalesFunctions
    {
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public static string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public static bool IsExistCombustible()
        {
            bool flagCombustible = false;
            foreach (var item in TSSalesApp.Detalles)
            {
                if (item.tipo == "COMBUSTIBLE")
                {
                    flagCombustible = true;
                    break;
                }
            }
            return flagCombustible;
        }
        public static bool IsNoExistVenta()
        {
            bool flagexist = false;
            if (TSSalesApp.Detalles.Count <= 0)
            {
                flagexist = true;
            }            
            return flagexist;
        }

        public static bool IsTransfGratuita(){
            int isTransfGratuita = 0;
            foreach (var item in TSSalesApp.Detalles)
            {
                if (item.trfgratuita)
                {
                    isTransfGratuita++;
                }
            }
            return TSSalesApp.Detalles.Count== isTransfGratuita;
        }
        public static bool IsCombustible()
        {
            int isCombustible = 0;
            foreach (var item in TSSalesApp.Detalles)
            {
                if (item.tipo == "COMBUSTIBLE")
                {
                    isCombustible++;
                }
            }
            return TSSalesApp.Detalles.Count == isCombustible;
        }
        public static void PreCalculaTotales()
        {
            decimal subtotal = 0;
            decimal igv = 0;
            decimal total = 0;
            foreach (var item in TSSalesApp.Detalles)
            {
                subtotal += item.subtotal;
                igv += item.mtoimpuesto;
                total += item.total;
            }
            TSSalesApp.vCabecera.mtototal = total;
            TSSalesApp.vCabecera.mtosubtotal = subtotal;
            TSSalesApp.vCabecera.mtoimpuesto = igv;
            TSSalesApp.vCabecera.mtovueltosol = 0;
        }
    }

   
}
