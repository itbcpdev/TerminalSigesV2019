using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    public class TS_BEMascara
    {
        protected TS_BEParametro parametro;

        public TS_BEMascara(TS_BEParametro input)
        {
            parametro = input;
        }

        public int cantidad { 
            get
            {
                var mascara = (parametro.masccantidad ?? "").Trim().Split('.');

                if (mascara.Length > 1)
                {
                    return mascara[1].Length;
                }

                return 7;
            }
        }

        public int precio
        {
            get
            {
                var mascara = (parametro.mascprecio ?? "").Trim().Split('.');

                if (mascara.Length > 1)
                {
                    return mascara[1].Length;
                }

                return 7;
            }
        }
    }
}
