using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APBackOffice: ITS_AIBackOffice
    {
        private readonly ITS_DOBackOffice _ITS_DOBackOffice;
        private readonly ITS_DOTerminal _ITS_DOTerminal;

        public TS_APBackOffice(ITS_DOBackOffice ITS_DOBackOffice, ITS_DOTerminal ITS_DOTerminal)
        {
            _ITS_DOBackOffice = ITS_DOBackOffice;
            _ITS_DOTerminal = ITS_DOTerminal;
        }

        public List<TS_BEVenta> SP_ITBCP_VENTA_CABECERA(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_VENTA_CABECERA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVariables> SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO(TS_BEVariables input)
        {
            List<TS_BEVariables> output = new List<TS_BEVariables>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVariables> SP_ITBCP_OBTENER_TOPES_MONTO_VENTA(TS_BEVariables input)
        {
            List<TS_BEVariables> output = new List<TS_BEVariables>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_OBTENER_TOPES_MONTO_VENTA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVariables> SP_ITBCP_OBTENER_TIPO_INGRESO(TS_BEVariables input)
        {
            List<TS_BEVariables> output = new List<TS_BEVariables>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_OBTENER_TIPO_INGRESO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BERuta> SP_ITBCP_OBTENER_RUTA(TS_BERuta input)
        {
            List<TS_BERuta> output = new List<TS_BERuta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_OBTENER_RUTA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEDescuento> SP_ITBCP_OBTENER_PORCENTAJE_DSCTO(TS_BEDescuento input)
        {
            List<TS_BEDescuento> output = new List<TS_BEDescuento>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_OBTENER_PORCENTAJE_DSCTO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BELocal SP_ITBCP_OBTENER_LOCAL(TS_BELocal input)
        {
            TS_BELocal output = new TS_BELocal();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_OBTENER_LOCAL(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

      

       

       

       

        public List<TS_BEZona> SP_ITBCP_LISTAR_ZONAS(TS_BEZona input)
        {
            List<TS_BEZona> output = new List<TS_BEZona>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_ZONAS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVw_Puntos_Por_Tarjeta> SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA(TS_BEVw_Puntos_Por_Tarjeta input)
        {
            List<TS_BEVw_Puntos_Por_Tarjeta> output = new List<TS_BEVw_Puntos_Por_Tarjeta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVentap> SP_ITBCP_LISTAR_VENTAP_2(TS_BEVentap input)
        {
            List<TS_BEVentap> output = new List<TS_BEVentap>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTAP_2(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVentap> SP_ITBCP_LISTAR_VENTAP_1(TS_BEVentap input)
        {
            List<TS_BEVentap> output = new List<TS_BEVentap>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTAP_1(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVentap> SP_ITBCP_LISTAR_VENTAP(TS_BEVentap input)
        {
            List<TS_BEVentap> output = new List<TS_BEVentap>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTAP(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVentad> SP_ITBCP_LISTAR_VENTAD_2(TS_BEVentad input)
        {
            List<TS_BEVentad> output = new List<TS_BEVentad>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTAD_2(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVentad> SP_ITBCP_LISTAR_VENTAD_1(TS_BEVentad input)
        {
            List<TS_BEVentad> output = new List<TS_BEVentad>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTAD_1(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVentad> SP_ITBCP_LISTAR_VENTAD(TS_BEVentad input)
        {
            List<TS_BEVentad> output = new List<TS_BEVentad>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTAD(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_9(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTA_9(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_8(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTA_8(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_7(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTA_7(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_6(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTA_6(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVentad> SP_ITBCP_LISTAR_VENTA_5(TS_BEVentad input)
        {
            List<TS_BEVentad> output = new List<TS_BEVentad>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTA_5(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_4(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTA_4(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_3(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTA_3(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_2(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTA_2(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VENTA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEConceptoVariables> SP_ITBCP_LISTAR_VARIABLES_1(TS_BEConceptoVariables input)
        {
            List<TS_BEConceptoVariables> output = new List<TS_BEConceptoVariables>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VARIABLES_1(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVariables> SP_ITBCP_LISTAR_VARIABLES(TS_BEVariables input)
        {
            List<TS_BEVariables> output = new List<TS_BEVariables>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VARIABLES(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEHvale> SP_ITBCP_LISTAR_VALE(TS_BEHvale input)
        {
            List<TS_BEHvale> output = new List<TS_BEHvale>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_VALE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

      

        public List<TS_BEOp_Tran> SP_ITBCP_LISTAR_TRANSACCION_ARTICULO(TS_BEOp_Tran input)
        {
            List<TS_BEOp_Tran> output = new List<TS_BEOp_Tran>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_TRANSACCION_ARTICULO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

     

       

        public List<TS_BETerminal> SP_ITBCP_LISTAR_TERMINALES(TS_BETerminal input)
        {
            List<TS_BETerminal> output = new List<TS_BETerminal>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_TERMINALES(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETarjeta_Concepto> SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1(TS_BETarjeta_Concepto input)
        {
            List<TS_BETarjeta_Concepto> output = new List<TS_BETarjeta_Concepto>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        //Generar Clase Personalizada
        /*public List<TS_BE(> SP_ITBCP_LISTAR_TARJETA_CONCEPTO(TS_BE( input)
		{
			List<TS_BE(> output = new List<TS_BE(>();
			try
			{
				output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_TARJETA_CONCEPTO(input);
			}
			catch (Exception ex)
			{
				throw new Exception(Helpers.RaiseError(ex));
			}
			return output;
		} */

        public List<TS_BETallad> SP_ITBCP_LISTAR_TALLAS(TS_BETallad input)
        {
            List<TS_BETallad> output = new List<TS_BETallad>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_TALLAS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEStock> SP_ITBCP_LISTAR_STOCK(TS_BEStock input)
        {
            List<TS_BEStock> output = new List<TS_BEStock>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_STOCK(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BESaldoclic> SP_ITBCP_LISTAR_SALDOCLID_1(TS_BESaldoclic input)
        {
            List<TS_BESaldoclic> output = new List<TS_BESaldoclic>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_SALDOCLID_1(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

      
      
        public List<TS_BEAfiliaciontarj> SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION(TS_BEAfiliaciontarj input)
        {
            List<TS_BEAfiliaciontarj> output = new List<TS_BEAfiliaciontarj>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEPrecio_Varios> SP_ITBCP_LISTAR_PRECIOS_VARIOS_1(TS_BEPrecio_Varios input)
        {
            List<TS_BEPrecio_Varios> output = new List<TS_BEPrecio_Varios>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_PRECIOS_VARIOS_1(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEPrecio_Varios> SP_ITBCP_LISTAR_PRECIOS_VARIOS(TS_BEPrecio_Varios input)
        {
            List<TS_BEPrecio_Varios> output = new List<TS_BEPrecio_Varios>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_PRECIOS_VARIOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEListaprecio> SP_ITBCP_LISTAR_PRECIOS(TS_BEListaprecio input)
        {
            List<TS_BEListaprecio> output = new List<TS_BEListaprecio>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_PRECIOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEPrecio> SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO(TS_BEPrecio input)
        {
            List<TS_BEPrecio> output = new List<TS_BEPrecio>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEPreciocliente> SP_ITBCP_LISTAR_PRECIO_CLIENTE(TS_BEPreciocliente input)
        {
            List<TS_BEPreciocliente> output = new List<TS_BEPreciocliente>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_PRECIO_CLIENTE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETmpmovpuntosArticulo> SP_ITBCP_LISTAR_MOVPUNTOS(TS_BETmpmovpuntosArticulo input)
        {
            List<TS_BETmpmovpuntosArticulo> output = new List<TS_BETmpmovpuntosArticulo>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_MOVPUNTOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETmpmovpuntosArticulo> SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE(TS_BETmpmovpuntosArticulo input)
        {
            List<TS_BETmpmovpuntosArticulo> output = new List<TS_BETmpmovpuntosArticulo>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETmpmovpuntos> SP_ITBCP_LISTAR_MOVDET_PUNTOS(TS_BETmpmovpuntos input)
        {
            List<TS_BETmpmovpuntos> output = new List<TS_BETmpmovpuntos>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_MOVDET_PUNTOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETmpmovfactura> SP_ITBCP_LISTAR_MOV_FACTURA(TS_BETmpmovfactura input)
        {
            List<TS_BETmpmovfactura> output = new List<TS_BETmpmovfactura>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_MOV_FACTURA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BELocal> SP_ITBCP_LISTAR_LOCAL_POR_ID(TS_BELocal input)
        {
            List<TS_BELocal> output = new List<TS_BELocal>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_LOCAL_POR_ID(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEGruposconsumo> SP_ITBCP_LISTAR_GRUPOS_CONSUMOS(TS_BEGruposconsumo input)
        {
            List<TS_BEGruposconsumo> output = new List<TS_BEGruposconsumo>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_GRUPOS_CONSUMOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BETicket SP_ITBCP_LISTAR_FORMATO_TICKET()
        {
            TS_BETicket output = new TS_BETicket();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BETicket SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA()
        {
            TS_BETicket output = new TS_BETicket();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA();
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public TS_BETicket SP_ITBCP_LISTAR_FORMATO_SERAFIN( )
        {
            TS_BETicket output = new TS_BETicket();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_SERAFIN();
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BECnfgvalorpuntoVariables> SP_ITBCP_LISTAR_CONF_PUNTO(TS_BECnfgvalorpuntoVariables input)
        {
            List<TS_BECnfgvalorpuntoVariables> output = new List<TS_BECnfgvalorpuntoVariables>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_CONF_PUNTO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        } 
     
      

        public List<TS_BEGrupo02> SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2(TS_BEGrupo02 input)
        {
            List<TS_BEGrupo02> output = new List<TS_BEGrupo02>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BECara> SP_ITBCP_LISTAR_CARA_POR_POSICION(TS_BECara input)
        {
            List<TS_BECara> output = new List<TS_BECara>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_LISTAR_CARA_POR_POSICION(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

     

        public List<TS_BETipopago> SP_ITBCP_IMPRIMIR_IMPRESORA(TS_BETipopago input)
        {
            List<TS_BETipopago> output = new List<TS_BETipopago>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_IMPRIMIR_IMPRESORA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BECliente> SP_ITBCP_IMPRIMIR_CLIENTE(TS_BECliente input)
        {
            List<TS_BECliente> output = new List<TS_BECliente>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_IMPRIMIR_CLIENTE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_IMPRIMIR(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_IMPRIMIR(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETmpmovfactura> SP_ITBCP_ELIMINAR_MOV_FACTURA(TS_BETmpmovfactura input)
        {
            List<TS_BETmpmovfactura> output = new List<TS_BETmpmovfactura>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_ELIMINAR_MOV_FACTURA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETerminal> SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD(TS_BETerminal input)
        {
            List<TS_BETerminal> output = new List<TS_BETerminal>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEParametro> SP_ITBCP_BLOQUEA_VENTANA_PLAYA(TS_BEParametro input)
        {
            List<TS_BEParametro> output = new List<TS_BEParametro>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_BLOQUEA_VENTANA_PLAYA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BELoteriaaviso> SP_ITBCP_AVISO_LOTERIA(TS_BELoteriaaviso input)
        {
            List<TS_BELoteriaaviso> output = new List<TS_BELoteriaaviso>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_AVISO_LOTERIA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEArticulo> SP_ITBCP_ARTICULOS_EN_PLAYA(TS_BEArticulo input)
        {
            List<TS_BEArticulo> output = new List<TS_BEArticulo>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_ARTICULOS_EN_PLAYA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BEVenta> SP_ITBCP_ACTUALIZAR_VENTA(TS_BEVenta input)
        {
            List<TS_BEVenta> output = new List<TS_BEVenta>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_VENTA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETerminal> SP_ITBCP_ACTUALIZAR_TERMINAL_2(TS_BETerminal input)
        {
            List<TS_BETerminal> output = new List<TS_BETerminal>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_TERMINAL_2(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETerminal> SP_ITBCP_ACTUALIZAR_TERMINAL(TS_BETerminal input)
        {
            List<TS_BETerminal> output = new List<TS_BETerminal>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_TERMINAL(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public void SP_ITBCP_CREAR_TABLA_TRANSACCION(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_TRANSACCION(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_INSUMOIS(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_INSUMOIS(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_NOVENTA(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_NOVENTA(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_VENTA(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_VENTA(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_VENTAD(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_VENTAD(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_VENTAP(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_VENTAP(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_INGRESO(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_INGRESO(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_INGRESOD(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_INGRESOD(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_SALIDA(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_SALIDA(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_SALIDAD(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_SALIDAD(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_GUIA(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_GUIA(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_GUIAD(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_GUIAD(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_NCREDITO(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_NCREDITO(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_NCREDITOD(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_NCREDITOD(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_DIASISLAVENDEDOR(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_DIASISLAVENDEDOR(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_DIADEPVENDEDOR(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_DIADEPVENDEDOR(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_FALTSOBR(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_FALTSOBR(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_DIACAJA(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_DIACAJA(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_DIACOBRANZA(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_DIACOBRANZA(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_DIACONTOMETRO(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_DIACONTOMETRO(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_DIACONTOMETROMANUAL(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_DIACONTOMETROMANUAL(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_DIATARJETA(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_DIATARJETA(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_DIAVARILLAJE(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_DIAVARILLAJE(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_DIADEPBANCO(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_DIADEPBANCO(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_NDEBITO(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_NDEBITO(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_NDEBITOD(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_NDEBITOD(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_HTRANSACCION(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_HTRANSACCION(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_OCOMPRA(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_OCOMPRA(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_CREAR_TABLA_OCOMPRAD(string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_CREAR_TABLA_OCOMPRAD(nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public List<TS_BESaldoclid> SP_ITBCP_SELECT_SALDOCLIENTED(TS_BESaldoclid input)
        {
            List<TS_BESaldoclid> output = new List<TS_BESaldoclid>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_SELECT_SALDOCLIENTED(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public void SP_ITBCP_INSERTAR_VENTAG(TS_BEVentag input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_VENTAG(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_VENTAR(TS_BEVentar input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_VENTAR(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_DISMINUIR_CREDITO_ACTUALIZAR(TS_BECliente input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_DISMINUIR_CREDITO_ACTUALIZAR(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_VALES_DE_CREDITO(TS_BEHvale input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_VALES_DE_CREDITO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_CREDITO_CLIENTE(TS_BECredcliente input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_CREDITO_CLIENTE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public bool SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA(string tarjeta,decimal puntos,decimal valoracumulado)
        {
            try
            {
                return _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA(tarjeta, puntos, valoracumulado);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_VALOR_ACUMULADO(TS_BEAfiliaciontarj input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_VALOR_ACUMULADO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_AFILIACION_PUNTOS(TS_BEAfiliacionptos input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_AFILIACION_PUNTOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_PUNTOS_GANADOS(TS_BEAfiliaciontarj input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_PUNTOS_GANADOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public List<TS_BEParametro> SP_ITBCP_SELECT_PARAMETROS(TS_BEParametro input)
        {
            List<TS_BEParametro> output = new List<TS_BEParametro>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_SELECT_PARAMETROS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public void SP_ITBCP_INSERTAR_VENTA(TS_BEVenta input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_VENTA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_VENTAP(TS_BEVentap input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_VENTAP(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

       public decimal SP_ITBCP_CALCULAR_COSTO_PROMEDIO (string cdProducto, DateTime fechaProceso)
		{
			try
			{
				return _ITS_DOBackOffice.SP_ITBCP_CALCULAR_COSTO_PROMEDIO(cdProducto, fechaProceso);
			}
			catch (Exception ex)
			{
				throw new Exception(Helpers.RaiseError(ex));
			}
		} 
    
        public void SP_ITBCP_INSERTAR_VENTAD(TS_BEVentad input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_VENTAD(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_DESPACHO(TS_BEDespachos input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_DESPACHO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_SALDOCLIENTE(TS_BESaldoclid input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_SALDOCLIENTE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public List<TS_BESaldoclid> SP_ITBCP_SELECT_SALDOCLIENTED1(TS_BESaldoclid input)
        {
            List<TS_BESaldoclid> output = new List<TS_BESaldoclid>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_SELECT_SALDOCLIENTED1(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public void SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_1(TS_BESaldoclid input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_1(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_2(TS_BESaldoclid input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_2(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ELIMINAR_TMPMOVPUNTOS(TS_BETmpmovpuntos input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ELIMINAR_TMPMOVPUNTOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_TARJETABONUS(TS_BETarjbonus input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_TARJETABONUS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_STOCK(TS_BEStock input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_STOCK(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_STOCK(TS_BEStock input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_STOCK(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_INSUMOISR(TS_BEInsumoisr input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_INSUMOISR(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_INSUMOIS(TS_BEInsumois input, string nombreTabla)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_INSUMOIS(input, nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_ARTICULO(TS_BEArticulo input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_ARTICULO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_CIERREMOV(TS_BECierremov input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_CIERREMOV(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_CIERREMOV(TS_BECierremov input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_CIERREMOV(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_CLIENTE(TS_BECliente input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_CLIENTE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_CLIENTE(TS_BECliente input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_CLIENTE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_PLACA(TS_BEPlaca input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_PLACA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public List<TS_BESaldoclid> SP_ITBCP_LISTAR_SALDOCLID(TS_BESaldoclid input)
        {
            throw new NotImplementedException();
        }

        public void SP_ITBCP_ELIMINAR_CVENTA(TS_BECventa input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ELIMINAR_CVENTA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ELIMINAR_CVENTAD(TS_BECventad input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ELIMINAR_CVENTAD(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ELIMINAR_VALE(TS_BEVale input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ELIMINAR_VALE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_INSERTAR_HVALE(TS_BEHvale input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_HVALE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_CDHASH_VENTA(TS_BEVenta input, string nombreTabla)

        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_CDHASH_VENTA(input, nombreTabla);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_OPTRAN(TS_BEOp_Tran input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_OPTRAN(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public List<TS_BEInsumo> SP_ITBCP_SELECT_INSUMOS(TS_BEInsumo input)
        {
            List<TS_BEInsumo> output = new List<TS_BEInsumo>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_SELECT_INSUMOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BELoteria> SP_ITBCP_SELECT_LOTERIA(TS_BELoteria input)
        {
            List<TS_BELoteria> output = new List<TS_BELoteria>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_SELECT_LOTERIA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BELoteriahora> SP_ITBCP_SELECT_LOTERIA_HORA(TS_BELoteriahora input)
        {
            List<TS_BELoteriahora> output = new List<TS_BELoteriahora>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_SELECT_LOTERIA_HORA(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BELoteriaart> SP_ITBCP_SELECT_LOTERIART(TS_BELoteriaart input)
        {
            List<TS_BELoteriaart> output = new List<TS_BELoteriaart>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_SELECT_LOTERIART(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BELoteriawin> SP_ITBCP_SELECT_LOTERIAWIN(TS_BELoteriawin input)
        {
            List<TS_BELoteriawin> output = new List<TS_BELoteriawin>();
            try
            {
                output = _ITS_DOBackOffice.SP_ITBCP_SELECT_LOTERIAWIN(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public void SP_ITBCP_INSERTAR_LOTERIAWIN(TS_BELoteriawin input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_INSERTAR_LOTERIAWIN(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public void SP_ITBCP_ACTUALIZAR_LOTERIAWIN(TS_BELoteriawin input)
        {
            try
            {
                _ITS_DOBackOffice.SP_ITBCP_ACTUALIZAR_LOTERIAWIN(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }

        public List<TS_BENropos> SP_ITBCP_LISTAR_NROPOS()
        {
            try
            {
               return _ITS_DOTerminal.SP_ITBCP_LISTAR_NROPOS();
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
        }
    }
}
