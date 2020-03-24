using System;
using System.Collections.Generic;
using System.ServiceModel;
using ITBCP.ServiceSIGES.Aplication;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Facturacion.Electronica;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using ITBCP.ServiceSIGES.Infraestructure.IoC;
using ITBCP.ServiceSIGES.Services.Interfaces;

namespace ITBCP.ServiceSIGES.Services.Services
{

    public class TS_SEImpresion : ITS_SIImpresion
    {
        public TS_BEInicioDiaOutput OBTENER_INICIO_DIA(string seriehd, string cdusuario)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_INICIO_DIA(seriehd,cdusuario);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("INICIO DE DIA"));

            }
        }
        public TS_BEMensaje OBTENER_CAMBIO_TURNO(bool Enviar, bool OmitirBloqueoPlaya)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_CAMBIO_TURNO(Enviar, OmitirBloqueoPlaya);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("CAMBIAR TURNO"));

            }
        }
        public TS_BEMensaje OBTENER_DOCUMENTO_IMPRESO(TS_BEDocumentoInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_DOCUMENTO_IMPRESO(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REIMPRIMIR DOCUMENTO"));

            }
        }
        public TS_BEMensaje OBTENER_ULTIMO_DOCUMENTO_IMPRESO(TS_BEUltimoDocumentoInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_ULTIMO_DOCUMENTO_IMPRESO(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER DOCUMENTO"));
            }
        }
        public TS_BEReimpresionLOutput OBTENER_DOCUMENTO_IMPRESO_VENTAG(TS_BEVentagInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_DOCUMENTO_IMPRESO_VENTAG(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER VENTA GENERAL"));
            }
        }
        public TS_BERespuesta OBTENER_CIERRE_X(TS_BEXCierreInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_CIERRE_X(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER CIERRE X"));
            }
        }
        public TS_BERespuesta OBTENER_CIERRE_Z(TS_BEZCierreInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_CIERRE_Z(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER CIERRE Z"));
            }
        }
        public TS_BEMensaje REGISTRAR_DEPOSITO(TS_BEDepositoInput input)
        {

            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.REGISTRAR_DEPOSITO(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REGISTRAR DEPOSITOS DE GRIFERO"));
            }

        }
        public TS_BEDepositos CONSULTAR_DEPOSITOS(string nropos, string cdvendedor)
        {

            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.CONSULTAR_DEPOSITOS( nropos,  cdvendedor);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("CONSULTAR DEPOSITOS DE GRIFERO"));
            }

        }
        public TS_BEMensaje AUTENTICAR_DEPOSITO_GRIFERO(TS_BELoginVendedor input)
        {

            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.AUTENTICAR_DEPOSITO_GRIFERO(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("AUTENTICACION DE DEPOSITOS DE GRIFERO"));
            }

        }
        public TS_BEMensaje REGISTRAR_GRIFERO_LADOS(TS_BELado input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.REGISTRAR_GRIFERO_LADOS(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REGISTRAR GRIFERO POR LADOS"));
            }
        }
        public TS_BELados OBTENER_GRIFERO_LADOS(string nropos)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_GRIFERO_LADOS(nropos);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER GRIFEROS POR LADO"));
            }
        }
        public TS_BEMensaje ELIMINAR_GRIFERO_LADOS(TS_BELadoEInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.ELIMINAR_GRIFERO_LADOS(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ELIMINAR GRIFERO POR LADO"));
            }
        }
        public TS_BEMensaje ELIMINAR_DEPOSITO(TS_BEDepositoEInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.ELIMINAR_DEPOSITOS(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ELIMINAR DEPOSITO"));
            }
        }
        public TS_BEVendedores OBTENER_VENDEDORES(string cdempresa)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_VENDEDORES(cdempresa);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("LISTAR DEPOSITOS"));
            }
        }
        public TS_BEMensaje AUTENTICAR_GRIFERO_LADOS(TS_BELoginVendedor input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.AUTENTICAR_GRIFERO_LADOS(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("AUTENTICAR GRIFERO POR LADOS"));
            }
        }

        public TS_BEReimpresionLOutput LISTAR_DOCUMENTOS_REIMPRESION(TS_BEReimpresionLInput input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.LISTAR_DOCUMENTOS_REIMPRESION(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("LISTAR DOCUMENTOS REIMPRESION"));
            }
        }

        public TS_BEMensaje AUTENTICAR_CONFIGURACION_LADOS(TS_BELoginVendedor input)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.AUTENTICAR_CONFIGURACION_LADOS(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("AUTENTICAR GRIFERO POR LADOS"));
            }
        }

        public bool OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC(string nropos)
        {
            try
            {
                ITS_AIImpresion ITS_AIImpresion = FabricaIoC.Contenedor.Resolver<ITS_AIImpresion>();
                return ITS_AIImpresion.OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC(nropos);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC"));
            }
        }
    }

}
