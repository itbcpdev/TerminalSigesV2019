using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cliente
{
    public class TS_BEGestionFlotaD
    {
        public string cdcliente { get; set; }
        public bool flgbloquea { get; set; }
        public string nrotarjeta { get; set; }
        public string nrobonus { get; set; }
        public string nroplaca { get; set; }
    }
}
