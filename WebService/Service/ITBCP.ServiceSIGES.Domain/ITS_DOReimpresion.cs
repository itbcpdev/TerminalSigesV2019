using System.Collections.Generic;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOReimpresion
    {

        TS_BEReimpresionLOutput OBTENER_VENTAG(TS_BEVentagInput input);
        TS_BECabecera OBTENER_VENTA_CABECERA(TS_BEDocumentoInput input);
        List<TS_BEArticulo> OBTENER_VENTA_DETALLE(TS_BEDocumentoInput input);
        List<TS_BEPago> OBTENER_VENTA_PAGO(TS_BEDocumentoInput input);

        TS_BEUltimoDocumentoInput OBTENER_DATOS_ULTIMO_DOCUMENTO(TS_BEUltimoDocumentoInput input);
        TS_BECabecera OBTENER_VENTA_ULTIMO_DOCUMENTO(TS_BEUltimoDocumentoInput input);
        List<TS_BEArticulo> OBTENER_VENTAD_ULTIMO_DOCUMENTO(TS_BEUltimoDocumentoInput input);
        List<TS_BEPago> OBTENER_VENTAP_ULTIMO_DOCUMENTO(TS_BEUltimoDocumentoInput input);
        TS_BEEmisor OBTENER_EMISOR();
        TS_BEClienteInput OBTENER_CLIENTE(TS_BEDocumento Documento, TS_BEClienteOutput cCliente);
        TS_BEDAnulaInput OBTENER_VENTAG_ESPECIFICO(TS_BEDAnulaInput input);
        TS_BEReimpresionLOutput LISTAR_DOCUMENTOS_REIMPRESION(TS_BEReimpresionLInput input);
    }
}
