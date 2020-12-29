using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ITBCP.ServiceSIGES.Aplication;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using ITBCP.ServiceSIGES.Infraestructure.IoC;
using Newtonsoft.Json;
using ITBCP.ServiceSIGES.Services.Interfaces;
using ITBCP.ServiceSIGES.Domain;

namespace ITBCP.ServiceSIGES.Services.Services
{
    public class SalesController : ApiController, ITS_SISales
    {
        [HttpPost]
        public TS_BERetornoTransaccion GrabarTransaccion([FromUri]List<TS_BEDetalleInput> cDetalle,[FromUri]TS_BECabeceraInput cCabecera,[FromUri]List<TS_BEPagoInput> cPago,[FromUri]TS_BEClienteInput cCliente,[FromUri]TS_BELoadInput cLoading, TS_BEGrabarConfig cConfiguracion)
        {

            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.GrabarTransaccion(cDetalle,cCabecera,cPago,cCliente,cLoading, cConfiguracion);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("GrabarTransaccion"));
            }
        }

        [HttpPost]
        public TS_BEArticuloOutput ListarArticuloPrecios([FromUri]string glosa)
        {
            try
            {
                ITS_AIArticulo _ITS_AIArticulo = FabricaIoC.Contenedor.Resolver<ITS_AIArticulo>();
                return _ITS_AIArticulo.ListarArticuloPrecios(glosa: glosa);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ListarArticuloPrecios"));
            }
        }

        [HttpPost]
        public TS_BESales Loading([FromUri]TS_BELoadInput input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.Loading(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("Loading"));

            }
        }

        [HttpPost]
        public TS_BEClienteOutput ObtenerClientByRuc([FromUri]TS_BEClienteSearch input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerClientByRuc(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerClientByRuc"));
            }
        }

        [HttpPost]
        public TS_BEArticuloOutput ObtenerListaArticulos([FromUri]string cdgrupo02)
        {
            try
            {
                ITS_AIArticulo _ITS_AIArticulo = FabricaIoC.Contenedor.Resolver<ITS_AIArticulo>();
                return _ITS_AIArticulo.SP_ITBCP_LISTAR_ARTICULOS(cdgrupo02: cdgrupo02);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerListaArticulos"));
            }

           
        }

        [HttpPost]
        public TS_BECabeceraOutPut ObtenerOpTransaccion([FromUri]TS_BEOpTransInput input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerOpTransaccion(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerOpTransaccion"));
            }
        }

        [HttpPost]
        public TS_BESaldoclid ObtenerSaldoClientTarjeta([FromUri]TS_BEClienteSearch input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerSaldoClientTarjeta(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerSaldoClientTarjeta"));
            }
        }

        [HttpPost]
        public TS_BEClienteOutput ObtenerClienteByTarjeta([FromUri]TS_BEClienteSearch input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerClienteByTarjeta(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerSaldoClientTarjeta"));
            }
        }

        [HttpPost]
        public TS_BEClienteOutput ObternerClienteByCodigo([FromUri]TS_BEClienteSearch input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObternerClienteByCodigo(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObternerClienteByCodigo"));
            }
        }

        [HttpPost]
        public List<TS_BEClienteLista> ListarClientes()
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ListarClientes();
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ListarClientes"));
            }
        }

        [HttpPost]
        public TS_BECorrelativoOutput ObtenerCorrelativo([FromUri]TS_BECorrelativoInput input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ObtenerCorrelativo(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ObtenerCorrelativo"));
            }
        }

        [HttpPost]
        public TS_BESaldos ValidaSaldos([FromUri]TS_BEClienteSearch cCliente)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public TS_BEMensaje ANULAR_DOCUMENTO([FromUri]TS_BEDAnulaInput input)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.ANULAR_DOCUMENTO(input);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ANULAR_DOCUMENTO"));
            }
        }

        [HttpPost]
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

        [HttpPost]
        public List<TS_BEClienteLista> ListarClientesByName([FromUri]string rscliente)
        {
            try
            {
                ITS_AICliente ITS_AICliente = FabricaIoC.Contenedor.Resolver<ITS_AICliente>();
                return ITS_AICliente.ListarClientesByName(rscliente);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ListarClientesByName"));
            }
        }

        [HttpPost]
        public List<TS_BEClienteLista> ListarClientesByPlaca([FromUri]string placa)
        {
            try
            {
                ITS_AICliente ITS_AICliente = FabricaIoC.Contenedor.Resolver<ITS_AICliente>();
                return ITS_AICliente.ListarClientesByPlaca(placa);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ListarClientesByPlaca"));
            }
        }

        [HttpPost]
        public List<TS_BECara> OBTENER_CARAS([FromUri]string seriehd)
        {
            try
            {
                ITS_AISales _ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return _ITS_AISales.OBTENER_CARAS(seriehd);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER_CARAS"));
            }
        }

        [HttpPost]
        public TS_BEMensaje REGISTRAR_LADO([FromUri]string nropos, [FromUri]string lado)
        {
            try
            {
                ITS_AILados ITS_AILados = FabricaIoC.Contenedor.Resolver<ITS_AILados>();
                return ITS_AILados.REGISTRAR_LADO(nropos, lado);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REGISTRAR_LADO"));

            }
        }

        [HttpPost]
        public TS_BEMensaje ELIMINAR_LADO([FromUri]string lado)
        {
            try
            {
                ITS_AILados ITS_AILados = FabricaIoC.Contenedor.Resolver<ITS_AILados>();
                return ITS_AILados.ELIMINAR_LADO(lado);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("ELIMINAR_LADO"));
            }
        }
       
        [HttpPost]
        public TS_BELados OBTENER_LADOS()
        {
            try
            {
                ITS_AILados ITS_AILados = FabricaIoC.Contenedor.Resolver<ITS_AILados>();
                return ITS_AILados.OBTENER_LADOS();
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("OBTENER_LADOS"));

            }
        }
        
        [HttpPost]
        public TS_BERespuestaCanje VALIDAR_CANJE([FromUri]List<TS_BEDetalleInput> cDetalle, [FromUri] TS_BEClienteInput cCliente)
        {
            try
            {
                ITS_AITarjeta ITS_AITarjeta = FabricaIoC.Contenedor.Resolver<ITS_AITarjeta>();
                return ITS_AITarjeta.VALIDAR_CANJE(cDetalle, cCliente);
            }
            catch (Exception e)
            {
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("VALIDAR_CANJE"));
            }
        }
        [HttpPost]
        public TS_BEArticuloOutput OBTENER_ARTICULOS_POR_PREFIJO([FromUri]string prefijo)
        {
            try
            {
                ITS_AITarjeta ITS_AITarjeta = FabricaIoC.Contenedor.Resolver<ITS_AITarjeta>();
                return ITS_AITarjeta.OBTENER_ARTICULOS_POR_PREFIJO(prefijo: prefijo);
            }
            catch (Exception e)
            {

                TS_APUtilities.Log_Consumo(e.ToString() + " - GrabarTransaccion");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("GrabarTransaccion"));
            }
        }
        [HttpPost]
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

        [HttpPost]
        public TS_BEMensaje REGISTRAR_AFILIACION([FromUri]TS_BEClienteInput cCliente, [FromUri]List<TS_BEArticulo> Articulos, [FromUri]TS_BETipoTarjetaRegistro Tipo)
        {
            try
            {
                ITS_AISales ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return ITS_AISales.REGISTRAR_AFILIACION(cCliente, Articulos, Tipo);
            }
            catch (Exception e)
            {

                TS_APUtilities.Log_Consumo(e.ToString() + " - REGISTRAR_AFILIACION");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("REGISTRAR_AFILIACION"));
            }
        }

        [HttpPost]
        public TS_BEArticlePromotion VERIFICAR_PROMOCION([FromBody]TS_BEPromotionInput input)
        {
            try
            {
                ITS_AISales ITS_AISales = FabricaIoC.Contenedor.Resolver<ITS_AISales>();
                return ITS_AISales.VERIFICAR_PROMOCION(input);
            }
            catch (Exception e)
            {

                TS_APUtilities.Log_Consumo(e.ToString() + " - VERIFICAR_PROMOCION");
                throw new FaultException<Excepcion>(new Excepcion(e), new FaultReason("VERIFICAR_PROMOCION"));
            }
        }
    }
}
