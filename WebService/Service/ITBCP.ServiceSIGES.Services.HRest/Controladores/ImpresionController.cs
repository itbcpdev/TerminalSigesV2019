using System;
using System.ServiceModel;
using System.Web.Http;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using ITBCP.ServiceSIGES.Infraestructure.IoC;
using ITBCP.ServiceSIGES.Services.Interfaces;

namespace ITBCP.ServiceSIGES.HostRest.Controladores
{

    public class ImpresionController : ApiController, ITS_SIImpresion
    {
        [HttpPost]
        public TS_BEInicioDiaOutput OBTENER_INICIO_DIA([FromUri]string seriehd, [FromUri]string cdusuario)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_INICIO_DIA(seriehd,cdusuario);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("INICIO DE DIA"));

            }
        }
        
        [HttpPost]
        public TS_BEMensaje OBTENER_CAMBIO_TURNO([FromUri]bool Enviar, [FromUri]bool OmitirBloqueoPlaya)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_CAMBIO_TURNO(Enviar, OmitirBloqueoPlaya);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("CAMBIAR TURNO"));

            }
        }

        [HttpPost]
        public TS_BEMensaje OBTENER_DOCUMENTO_IMPRESO([FromUri]TS_BEDocumentoInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_DOCUMENTO_IMPRESO(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REIMPRIMIR DOCUMENTO"));

            }
        }

        [HttpPost]
        public TS_BEMensaje OBTENER_ULTIMO_DOCUMENTO_IMPRESO([FromUri]TS_BEUltimoDocumentoInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_ULTIMO_DOCUMENTO_IMPRESO(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER DOCUMENTO"));
            }
        }

        [HttpPost]
        public TS_BEReimpresionLOutput OBTENER_DOCUMENTO_IMPRESO_VENTAG([FromUri]TS_BEVentagInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_DOCUMENTO_IMPRESO_VENTAG(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER VENTA GENERAL"));
            }
        }

        [HttpPost]
        public TS_BERespuesta OBTENER_CIERRE_X([FromUri]TS_BEXCierreInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_CIERRE_X(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER CIERRE X"));
            }
        }

        [HttpPost]
        public TS_BERespuesta OBTENER_CIERRE_Z([FromUri]TS_BEZCierreInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_CIERRE_Z(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER CIERRE Z"));
            }
        }

        [HttpPost]
        public TS_BEMensaje REGISTRAR_DEPOSITO([FromUri]TS_BEDepositoInput input)
        {

            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.REGISTRAR_DEPOSITO(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REGISTRAR DEPOSITOS DE GRIFERO"));
            }

        }

        [HttpPost]
        public TS_BEDepositos CONSULTAR_DEPOSITOS([FromUri]string nropos, [FromUri]string cdvendedor)
        {

            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.CONSULTAR_DEPOSITOS( nropos,  cdvendedor);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("CONSULTAR DEPOSITOS DE GRIFERO"));
            }

        }

        [HttpPost]
        public TS_BEMensaje AUTENTICAR_DEPOSITO_GRIFERO([FromUri]TS_BELoginVendedor input)
        {

            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.AUTENTICAR_DEPOSITO_GRIFERO(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("AUTENTICACION DE DEPOSITOS DE GRIFERO"));
            }

        }

        [HttpPost]
        public TS_BEMensaje REGISTRAR_GRIFERO_LADOS([FromUri]TS_BELado input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.REGISTRAR_GRIFERO_LADOS(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REGISTRAR GRIFERO POR LADOS"));
            }
        }

        [HttpPost]
        public TS_BELados OBTENER_GRIFERO_LADOS([FromUri]string nropos)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_GRIFERO_LADOS(nropos);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER GRIFEROS POR LADO"));
            }
        }

        [HttpPost]
        public TS_BEMensaje ELIMINAR_GRIFERO_LADOS([FromUri]TS_BELadoEInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.ELIMINAR_GRIFERO_LADOS(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ELIMINAR GRIFERO POR LADO"));
            }
        }

        [HttpPost]
        public TS_BEMensaje ELIMINAR_DEPOSITO([FromUri]TS_BEDepositoEInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.ELIMINAR_DEPOSITOS(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ELIMINAR DEPOSITO"));
            }
        }

        [HttpPost]
        public TS_BEVendedores OBTENER_VENDEDORES([FromUri]string cdempresa)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_VENDEDORES(cdempresa);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("LISTAR DEPOSITOS"));
            }
        }

        [HttpPost]
        public TS_BEMensaje AUTENTICAR_GRIFERO_LADOS([FromUri]TS_BELoginVendedor input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.AUTENTICAR_GRIFERO_LADOS(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("AUTENTICAR GRIFERO POR LADOS"));
            }
        }

        [HttpPost]
        public TS_BEReimpresionLOutput LISTAR_DOCUMENTOS_REIMPRESION([FromUri]TS_BEReimpresionLInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.LISTAR_DOCUMENTOS_REIMPRESION(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("LISTAR DOCUMENTOS REIMPRESION"));
            }
        }
       
        [HttpPost]
        public TS_BEMensaje AUTENTICAR_CONFIGURACION_LADOS([FromUri]TS_BELoginVendedor input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.AUTENTICAR_CONFIGURACION_LADOS(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("AUTENTICAR GRIFERO POR LADOS"));
            }
        }

        [HttpPost]
        public bool OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC([FromUri]string nropos)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC(nropos);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC"));
            }
        }
    }

}
