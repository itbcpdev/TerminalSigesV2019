using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Facturacion.Electronica;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface ITS_AIFacturacionE
    {
        TS_BEMensaje VALIDAR_DATOS(TS_BEDocumento Documento);
        TS_BERespuestaFE OBTENER_RESPUESTA(TS_BEDocumento DocumentoFE);
    }
}
