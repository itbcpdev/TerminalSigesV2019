using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ITBCP.ServiceSIGES.Infraestructure.DataAcces
{
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    //Creado por     : Ronald Noé Saavedra Bances (02/02/2019)
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    public static class ReaderExtension
    {
        public static bool HasColumn(this SqlDataReader drd, string nombreColumna)
        {
            for (int i = 0; i < drd.FieldCount; i++)
            {
                if (drd.GetName(i).Equals(nombreColumna, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }
            return false;
        }
        
    }
}
