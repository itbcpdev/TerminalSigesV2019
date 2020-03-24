using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain
{

    /*PREFIJO DE TARJETA*/
    public class TS_BEPTarjeta
    {
        public string varid { get; set; }
        public string tipo { get; set; }
        public string prefijo { get; set; }
        public string descripcion { get; set; }
        
    }
}
