using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Facturacion.Electronica;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOAceptaFE
    {
        string OBTENER_CABECERA(TS_BEDocumento Documento);
        string OBTENER_DETALLES(TS_BEDocumento Documento);
        string OBTENER_GLOBAL(TS_BEDocumento Documento);
        string OBTENER_PAGOS(TS_BEDocumento Documento);

    }
}
