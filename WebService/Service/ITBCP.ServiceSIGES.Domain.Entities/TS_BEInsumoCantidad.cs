using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    public class TS_BEInsumoCantidad
    {
        public string cdarticulo { get; set; }
        public decimal cantidad { get; set; }
        public decimal ctoreposicion { get; set; }
        public decimal ctopromedio { get; set; }
        public decimal precio { get; set; }
    }
}
