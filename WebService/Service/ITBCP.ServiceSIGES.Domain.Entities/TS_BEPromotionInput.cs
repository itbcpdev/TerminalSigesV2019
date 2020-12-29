using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    public class TS_BEPromotionInput
    {
        public string cdcliente { get; set; }
        public string cdarticulo { get; set; }
        public decimal precio { get; set; }
        public decimal precio_orig { get; set; }
        public decimal total { get; set; }
        public decimal cantidad { get; set; }
        public bool isCredito { get; set; }
    }
}
