using System.Collections.Generic;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface  ITS_AIImpresion
    {

        TS_BEReimpresionLOutput OBTENER_DOCUMENTO_IMPRESO_VENTAG(TS_BEVentagInput input);

        TS_BEMensaje OBTENER_DOCUMENTO_IMPRESO(TS_BEDocumentoInput input);

        TS_BEMensaje OBTENER_ULTIMO_DOCUMENTO_IMPRESO(TS_BEUltimoDocumentoInput input);

        TS_BERespuesta OBTENER_CIERRE_X(TS_BEXCierreInput input);

        TS_BERespuesta OBTENER_CIERRE_Z(TS_BEZCierreInput input);

        TS_BEMensaje OBTENER_CAMBIO_TURNO(bool Enviar, bool OmitirBloqueoPlaya);

        TS_BEInicioDiaOutput OBTENER_INICIO_DIA(string seriehd, string cdusuario);

        TS_BEMensaje NOTIFICAR_IMPRESION(TS_BETerminal Terminal);

        TS_BEMensaje REGISTRAR_DEPOSITO(TS_BEDepositoInput input);

        TS_BEDepositos CONSULTAR_DEPOSITOS(string nropos, string cdvendedor);

        TS_BEMensaje AUTENTICAR_DEPOSITO_GRIFERO(TS_BELoginVendedor input);

        TS_BEMensaje REGISTRAR_GRIFERO_LADOS(TS_BELado input);

        TS_BELados OBTENER_GRIFERO_LADOS(string nropos);

        TS_BEMensaje ELIMINAR_GRIFERO_LADOS(TS_BELadoEInput input);

        TS_BEMensaje ELIMINAR_DEPOSITOS(TS_BEDepositoEInput input);

        TS_BEVendedores OBTENER_VENDEDORES(string cdempresa);

        TS_BEMensaje AUTENTICAR_GRIFERO_LADOS(TS_BELoginVendedor input);

        TS_BEDocumento OBTENER_DOCUMENTO(TS_BEDAnulaInput input);

        TS_BEReimpresionLOutput LISTAR_DOCUMENTOS_REIMPRESION(TS_BEReimpresionLInput input);

        TS_BEMensaje AUTENTICAR_CONFIGURACION_LADOS(TS_BELoginVendedor input);

        bool OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC(string nropos);

    }
}
