using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface ITS_AILados
    {
        TS_BEMensaje REGISTRAR_LADO(string nropos, string lado);
        TS_BEMensaje ELIMINAR_LADO(string lado);
        TS_BELados OBTENER_LADOS();
    }
}
