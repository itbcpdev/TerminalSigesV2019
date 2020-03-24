using System.Collections.Generic;
using System.ServiceModel;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Facturacion.Electronica;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using ITBCP.ServiceSIGES.Domain.Entities.Users;

namespace ITBCP.ServiceSIGES.Services.Interfaces
{
    [ServiceContract]
    public interface ITS_SIImpresion
    {

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEReimpresionLOutput OBTENER_DOCUMENTO_IMPRESO_VENTAG(TS_BEVentagInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje OBTENER_DOCUMENTO_IMPRESO(TS_BEDocumentoInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje OBTENER_ULTIMO_DOCUMENTO_IMPRESO(TS_BEUltimoDocumentoInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BERespuesta OBTENER_CIERRE_X(TS_BEXCierreInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BERespuesta OBTENER_CIERRE_Z(TS_BEZCierreInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje OBTENER_CAMBIO_TURNO(bool Enviar,bool OmitirBloqueoPlaya);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEInicioDiaOutput OBTENER_INICIO_DIA(string seriehd,string cdusuario);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje REGISTRAR_DEPOSITO(TS_BEDepositoInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEDepositos CONSULTAR_DEPOSITOS(string nropos, string cdvendedor);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje AUTENTICAR_DEPOSITO_GRIFERO(TS_BELoginVendedor input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje REGISTRAR_GRIFERO_LADOS(TS_BELado input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BELados OBTENER_GRIFERO_LADOS(string nropos);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje ELIMINAR_GRIFERO_LADOS(TS_BELadoEInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje ELIMINAR_DEPOSITO(TS_BEDepositoEInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEVendedores OBTENER_VENDEDORES(string cdempresa);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje AUTENTICAR_GRIFERO_LADOS(TS_BELoginVendedor input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEMensaje AUTENTICAR_CONFIGURACION_LADOS(TS_BELoginVendedor input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        TS_BEReimpresionLOutput LISTAR_DOCUMENTOS_REIMPRESION(TS_BEReimpresionLInput input);

        [OperationContract]
        [FaultContract(typeof(Excepcion))]
        bool OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC(string nropos);

    }
}
