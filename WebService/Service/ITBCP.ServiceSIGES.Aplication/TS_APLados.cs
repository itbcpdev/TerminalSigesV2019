using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APLados : ITS_AILados
    {
        private readonly ITS_DOLados ITS_DOLados;
        private readonly ITS_DOTerminal ITS_DOTerminal;

        public TS_APLados(ITS_DOLados ITS_DOLados, ITS_DOTerminal ITS_DOTerminal)
        {
            this.ITS_DOLados = ITS_DOLados;
            this.ITS_DOTerminal = ITS_DOTerminal;
        }

        public TS_BEMensaje ELIMINAR_LADO(string lado)
        {
            if (String.IsNullOrEmpty(lado))
            {
                return new TS_BEMensaje("El lado no puede ser nulo o vacío", false);
            }
            else
            {
               return ITS_DOLados.ELIMINAR_LADO(lado);
            }
        }

        public TS_BELados OBTENER_LADOS()
        {
            return ITS_DOLados.OBTENER_LADOS();
        }

        public TS_BEMensaje REGISTRAR_LADO(string nropos, string lado)
        {
            if (String.IsNullOrEmpty(nropos))
            {
                return new TS_BEMensaje("El Punto de venta no puede ser nulo o vacío", false);
            }
            if (String.IsNullOrEmpty(lado))
            {
                return new TS_BEMensaje("El lado no puede ser nulo o vacío", false);
            }

            TS_BETerminal terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = (nropos ?? "").Trim() });

            if (String.IsNullOrEmpty(terminal.nropos))
            {
                return new TS_BEMensaje("El punto de venta especificado no existe", false);
            }

            return ITS_DOLados.REGISTRAR_LADO(nropos, lado);


        }
    }
}
