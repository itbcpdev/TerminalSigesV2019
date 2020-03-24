using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Aplication;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using ITBCP.ServiceSIGES.Infraestructure.IoC;
using ITBCP.ServiceSIGES.Services.Interfaces;

namespace ITBCP.ServiceSIGES.Services.Services
{
    public class TS_SESales : ITS_SISales
    {
        public TS_BERetornoTransaccion GrabarTransaccion(List<TS_BEDetalleInput> cDetalle, TS_BECabeceraInput cCabecera, List<TS_BEPagoInput> cPago, TS_BEClienteInput cCliente, TS_BELoadInput cLoading, TS_BEGrabarConfig cConfiguracion)

        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.GrabarTransaccion(cDetalle,cCabecera,cPago,cCliente,cLoading,cConfiguracion);
            }
            catch (Exception e)
            {

                TS_APUtilities.Log_Consumo(e.ToString() + " - GrabarTransaccion");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("GrabarTransaccion"));
            }
        }

        public TS_BEArticuloOutput ListarArticuloPrecios(string glosa)
        {
            try
            {
                ITS_AIArticulo _ITS_AIArticulo = FabricaIoC.Contenedor.Resolver<ITS_AIArticulo>();
                return _ITS_AIArticulo.ListarArticuloPrecios(glosa : glosa);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "ListarArticuloPrecios");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ListarArticuloPrecios"));
            }
        }

        public TS_BESales Loading(TS_BELoadInput input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.Loading(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "Loading");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("Loading"));

            }
        }

        public TS_BEClienteOutput ObtenerClientByRuc(TS_BEClienteSearch input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerClientByRuc(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "ObtenerClientByRuc");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerClientByRuc"));

            }
        }

        public TS_BEArticuloOutput ObtenerListaArticulos(string cdgrupo02)
        {
            try
            {
                ITS_AIArticulo _ITS_AIArticulo = FabricaIoC.Contenedor.Resolver<ITS_AIArticulo>();
                return _ITS_AIArticulo.SP_ITBCP_LISTAR_ARTICULOS(cdgrupo02);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "ObtenerListaArticulos");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerListaArticulos"));

            }

           
        }

        public TS_BECabeceraOutPut ObtenerOpTransaccion(TS_BEOpTransInput input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerOpTransaccion(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "ObtenerOpTransaccion");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerOpTransaccion"));

            }
        }

        public TS_BESaldoclid ObtenerSaldoClientTarjeta(TS_BEClienteSearch input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerSaldoClientTarjeta(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "ObtenerSaldoClientTarjeta");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerSaldoClientTarjeta"));

            }
        }

        public TS_BEClienteOutput ObtenerClienteByTarjeta(TS_BEClienteSearch input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerClienteByTarjeta(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "ObtenerSaldoClientTarjeta");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerSaldoClientTarjeta"));

            }
        }

        public TS_BEClienteOutput ObternerClienteByCodigo(TS_BEClienteSearch input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObternerClienteByCodigo(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "ObternerClienteByCodigo");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObternerClienteByCodigo"));

            }
        }

        public List<TS_BEClienteLista> ListarClientes()
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ListarClientes();
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + " ListarClientes");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ListarClientes"));
            }
        }

        public TS_BECorrelativoOutput ObtenerCorrelativo(TS_BECorrelativoInput input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerCorrelativo(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + " ObtenerCorrelativo");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerCorrelativo"));
            }
        }

        public TS_BESaldos ValidaSaldos(TS_BEClienteSearch cCliente)
        {
            throw new NotImplementedException();
        }

        public TS_BEMensaje ANULAR_DOCUMENTO(TS_BEDAnulaInput input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ANULAR_DOCUMENTO(input);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + " ANULAR_DOCUMENTO");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ANULAR_DOCUMENTO"));
            }
        }

        public List<TS_BENropos> LISTAR_NROPOS()
        {
            try
            {
                ITS_AIBackOffice _ITS_AIBackOffice = FabricaIoC.Contenedor.Resolver<ITS_AIBackOffice>();
                return _ITS_AIBackOffice.SP_ITBCP_LISTAR_NROPOS();
            }
            catch (Exception ex)
            {
                throw new FaultException<Excepcion>(new Excepcion(ex), new FaultReason("SP_ITBCP_LISTAR_NROPOS"));
            }
        }

        public List<TS_BEClienteLista> ListarClientesByName(string rscliente)
        {
            try
            {
                ITS_AICliente ITS_AICliente = FabricaIoC.Contenedor.Resolver<ITS_AICliente>();
                return ITS_AICliente.ListarClientesByName(rscliente);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + " ListarClientesByName");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ListarClientesByName"));
            }
        }

        public List<TS_BEClienteLista> ListarClientesByPlaca(string placa)
        {
            try
            {
                ITS_AICliente ITS_AICliente = FabricaIoC.Contenedor.Resolver<ITS_AICliente>();
                return ITS_AICliente.ListarClientesByPlaca(placa);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + " ListarClientesByPlaca");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ListarClientesByPlaca"));
            }
        }

        public List<TS_BECara> OBTENER_CARAS(string seriehd)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.OBTENER_CARAS(seriehd);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_CARAS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER_CARAS"));

            }
        }

        public TS_BEMensaje REGISTRAR_LADO(string nropos, string lado)
        {
            try
            {
                ITS_AILados ITS_AILados = FabricaIoC.Contenedor.Resolver<ITS_AILados>();
                return ITS_AILados.REGISTRAR_LADO(nropos, lado);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "REGISTRAR_LADO");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REGISTRAR_LADO"));

            }
        }

        public TS_BEMensaje ELIMINAR_LADO(string lado)
        {
            try
            {
                ITS_AILados ITS_AILados = FabricaIoC.Contenedor.Resolver<ITS_AILados>();
                return ITS_AILados.ELIMINAR_LADO(lado);
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "ELIMINAR_LADO");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ELIMINAR_LADO"));

            }
        }

        public TS_BELados OBTENER_LADOS()
        {
            try
            {
                ITS_AILados ITS_AILados = FabricaIoC.Contenedor.Resolver<ITS_AILados>();
                return ITS_AILados.OBTENER_LADOS();
            }
            catch (Exception e)
            {
                TS_APUtilities.Log_Consumo(e.ToString() + "OBTENER_LADOS");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER_LADOS"));

            }
        }

        public TS_BEArticuloOutput OBTENER_ARTICULOS_POR_PREFIJO(string prefijo)
        {
            try
            {
                ITS_AITarjeta ITS_AITarjeta = FabricaIoC.Contenedor.Resolver<ITS_AITarjeta>();
                return ITS_AITarjeta.OBTENER_ARTICULOS_POR_PREFIJO(prefijo: prefijo);
            }
            catch (Exception e)
            {

                TS_APUtilities.Log_Consumo(e.ToString() + " - OBTENER_ARTICULOS_POR_PREFIJO");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER_ARTICULOS_POR_PREFIJO"));
            }
        }

        public List<TS_BEPTarjeta> OBTENER_PREFIJOS_AFILIACION()
        {
            try
            {
                ITS_AICliente ITS_AICliente = FabricaIoC.Contenedor.Resolver<ITS_AICliente>();
                return ITS_AICliente.LISTA_TARJETA_PREFIJOS();
            }
            catch (Exception e)
            {

                TS_APUtilities.Log_Consumo(e.ToString() + " - OBTENER_PREFIJOS_AFILIACION");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER_PREFIJOS_AFILIACION"));
            }
        }

        public TS_BEMensaje REGISTRAR_AFILIACION(TS_BEClienteInput cCliente, List<TS_BEArticulo> Articulos, TS_BETipoTarjetaRegistro Tipo)
        {
            try
            {
                ITS_AISales ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return ITS_AISales.REGISTRAR_AFILIACION(cCliente,Articulos,Tipo);
            }
            catch (Exception e)
            {

                TS_APUtilities.Log_Consumo(e.ToString() + " - REGISTRAR_AFILIACION");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REGISTRAR_AFILIACION"));
            }
        }
    }
}
