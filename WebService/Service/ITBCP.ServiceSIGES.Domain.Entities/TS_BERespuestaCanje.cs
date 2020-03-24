using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    public class TS_BERespuestaCanje
    {
        public TS_BERespuestaCanje() { }

        public TS_BERespuestaCanje(string Mensaje,bool estado)
        {
            this.Mensaje = new TS_BEMensaje(Mensaje,estado);
        }
        public TS_BEMensaje Mensaje { get; set; }

        public decimal Puntos { get; set; }
        public decimal ValorAcumulado { get; set; }
    }
}
