using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface ITS_AITipoCambio
    {
        TS_BECambio OBTENER_TIPOCAMBIO();
        List<TS_BECambio> LISTARTIPOCAMBIO(TS_BECambio input);
    }
}
