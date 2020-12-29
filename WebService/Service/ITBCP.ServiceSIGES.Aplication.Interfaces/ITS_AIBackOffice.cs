using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface ITS_AIBackOffice
    {
        List<TS_BEVenta> SP_ITBCP_VENTA_CABECERA(TS_BEVenta input);
        List<TS_BEVariables> SP_ITBCP_VALIDAR_OPCION_PRINT_PANTALLA_OR_FISICO(TS_BEVariables input);
        List<TS_BEVariables> SP_ITBCP_OBTENER_TOPES_MONTO_VENTA(TS_BEVariables input);
        List<TS_BEVariables> SP_ITBCP_OBTENER_TIPO_INGRESO(TS_BEVariables input);
        List<TS_BERuta> SP_ITBCP_OBTENER_RUTA(TS_BERuta input);
        List<TS_BEDescuento> SP_ITBCP_OBTENER_PORCENTAJE_DSCTO(TS_BEDescuento input);
        TS_BELocal SP_ITBCP_OBTENER_LOCAL(TS_BELocal input); 
         
        List<TS_BEZona> SP_ITBCP_LISTAR_ZONAS(TS_BEZona input);
        List<TS_BEVw_Puntos_Por_Tarjeta> SP_ITBCP_LISTAR_VISTA_PUNTOS_TARJETA(TS_BEVw_Puntos_Por_Tarjeta input);
        List<TS_BEVentap> SP_ITBCP_LISTAR_VENTAP_2(TS_BEVentap input);
        List<TS_BEVentap> SP_ITBCP_LISTAR_VENTAP_1(TS_BEVentap input);
        List<TS_BEVentap> SP_ITBCP_LISTAR_VENTAP(TS_BEVentap input);
        List<TS_BEVentad> SP_ITBCP_LISTAR_VENTAD_2(TS_BEVentad input);
        List<TS_BEVentad> SP_ITBCP_LISTAR_VENTAD_1(TS_BEVentad input);
        List<TS_BEVentad> SP_ITBCP_LISTAR_VENTAD(TS_BEVentad input);
        List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_9(TS_BEVenta input);
        List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_8(TS_BEVenta input);
        List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_7(TS_BEVenta input);
        List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_6(TS_BEVenta input);
        List<TS_BEVentad> SP_ITBCP_LISTAR_VENTA_5(TS_BEVentad input);
        List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_4(TS_BEVenta input);
        List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_3(TS_BEVenta input);
        List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA_2(TS_BEVenta input);
        List<TS_BEVenta> SP_ITBCP_LISTAR_VENTA(TS_BEVenta input);
        List<TS_BEConceptoVariables> SP_ITBCP_LISTAR_VARIABLES_1(TS_BEConceptoVariables input);
        List<TS_BEVariables> SP_ITBCP_LISTAR_VARIABLES(TS_BEVariables input);
        List<TS_BEHvale> SP_ITBCP_LISTAR_VALE(TS_BEHvale input);

        List<TS_BEOp_Tran> SP_ITBCP_LISTAR_TRANSACCION_ARTICULO(TS_BEOp_Tran input);
   
      
        List<TS_BETarjeta_Concepto> SP_ITBCP_LISTAR_TARJETA_CONCEPTO_1(TS_BETarjeta_Concepto input);
        //List<TS_BE(> SP_ITBCP_LISTAR_TARJETA_CONCEPTO(TS_BE( input);
        List<TS_BETallad> SP_ITBCP_LISTAR_TALLAS(TS_BETallad input);
        List<TS_BEStock> SP_ITBCP_LISTAR_STOCK(TS_BEStock input);
        List<TS_BESaldoclid> SP_ITBCP_LISTAR_SALDOCLID(TS_BESaldoclid input);
        List<TS_BESaldoclic> SP_ITBCP_LISTAR_SALDOCLID_1(TS_BESaldoclic input);
    
        List<TS_BEAfiliaciontarj> SP_ITBCP_LISTAR_PTOS_DISPONIBLES_POR_TARJETA_AFILIACION(TS_BEAfiliaciontarj input);
        List<TS_BEPrecio_Varios> SP_ITBCP_LISTAR_PRECIOS_VARIOS_1(TS_BEPrecio_Varios input);
        List<TS_BEPrecio_Varios> SP_ITBCP_LISTAR_PRECIOS_VARIOS(TS_BEPrecio_Varios input);
        List<TS_BEListaprecio> SP_ITBCP_LISTAR_PRECIOS(TS_BEListaprecio input);
        List<TS_BEPrecio> SP_ITBCP_LISTAR_PRECIO_POR_ARTICULO_PRECIO(TS_BEPrecio input);
        List<TS_BEPreciocliente> SP_ITBCP_LISTAR_PRECIO_CLIENTE(TS_BEPreciocliente input);
        List<TS_BETmpmovpuntosArticulo> SP_ITBCP_LISTAR_MOVPUNTOS(TS_BETmpmovpuntosArticulo input);
        List<TS_BETmpmovpuntosArticulo> SP_ITBCP_LISTAR_MOVIMIENTO_PUNTOS_POR_GRUPO_COMBUSTIBLE(TS_BETmpmovpuntosArticulo input);
        List<TS_BETmpmovpuntos> SP_ITBCP_LISTAR_MOVDET_PUNTOS(TS_BETmpmovpuntos input);
        List<TS_BETmpmovfactura> SP_ITBCP_LISTAR_MOV_FACTURA(TS_BETmpmovfactura input);
        List<TS_BELocal> SP_ITBCP_LISTAR_LOCAL_POR_ID(TS_BELocal input);
        List<TS_BEGruposconsumo> SP_ITBCP_LISTAR_GRUPOS_CONSUMOS(TS_BEGruposconsumo input);
        TS_BETicket SP_ITBCP_LISTAR_FORMATO_TICKET();
        TS_BETicket SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA();
        TS_BETicket SP_ITBCP_LISTAR_FORMATO_SERAFIN();
        List<TS_BECnfgvalorpuntoVariables> SP_ITBCP_LISTAR_CONF_PUNTO(TS_BECnfgvalorpuntoVariables input);
       
      
        List<TS_BEGrupo02> SP_ITBCP_LISTAR_CATEGORIAS_GRUPO2(TS_BEGrupo02 input);
        List<TS_BECara> SP_ITBCP_LISTAR_CARA_POR_POSICION(TS_BECara input);
    
        List<TS_BETipopago> SP_ITBCP_IMPRIMIR_IMPRESORA(TS_BETipopago input);
        List<TS_BECliente> SP_ITBCP_IMPRIMIR_CLIENTE(TS_BECliente input);
        List<TS_BEVenta> SP_ITBCP_IMPRIMIR(TS_BEVenta input);
        List<TS_BETmpmovfactura> SP_ITBCP_ELIMINAR_MOV_FACTURA(TS_BETmpmovfactura input);
        List<TS_BETerminal> SP_ITBCP_BUSCAR_TERMINAL_POR_SERIEHD(TS_BETerminal input);
        List<TS_BEParametro> SP_ITBCP_BLOQUEA_VENTANA_PLAYA(TS_BEParametro input);
        List<TS_BELoteriaaviso> SP_ITBCP_AVISO_LOTERIA(TS_BELoteriaaviso input);
        List<TS_BEArticulo> SP_ITBCP_ARTICULOS_EN_PLAYA(TS_BEArticulo input);
        List<TS_BEVenta> SP_ITBCP_ACTUALIZAR_VENTA(TS_BEVenta input);
        List<TS_BETerminal> SP_ITBCP_ACTUALIZAR_TERMINAL_2(TS_BETerminal input);
        List<TS_BETerminal> SP_ITBCP_ACTUALIZAR_TERMINAL(TS_BETerminal input);

        // LINEAS ABAJO CREADAS 23/02/2019
        void SP_ITBCP_CREAR_TABLA_TRANSACCION(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_INSUMOIS(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_NOVENTA(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_VENTA(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_VENTAD(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_VENTAP(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_INGRESO(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_INGRESOD(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_SALIDA(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_SALIDAD(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_GUIA(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_GUIAD(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_NCREDITO(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_NCREDITOD(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_DIASISLAVENDEDOR(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_DIADEPVENDEDOR(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_FALTSOBR(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_DIACAJA(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_DIACOBRANZA(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_DIACONTOMETRO(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_DIACONTOMETROMANUAL(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_DIATARJETA(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_DIAVARILLAJE(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_DIADEPBANCO(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_NDEBITO(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_NDEBITOD(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_HTRANSACCION(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_OCOMPRA(string nombreTabla);
        void SP_ITBCP_CREAR_TABLA_OCOMPRAD(string nombreTabla);

        // agregado 02/03/2019

        List<TS_BESaldoclid> SP_ITBCP_SELECT_SALDOCLIENTED(TS_BESaldoclid input);
        void SP_ITBCP_INSERTAR_VENTAG(TS_BEVentag input);
        void SP_ITBCP_INSERTAR_VENTAR(TS_BEVentar input);
        void SP_ITBCP_DISMINUIR_CREDITO_ACTUALIZAR(TS_BECliente input);
        void SP_ITBCP_ACTUALIZAR_VALES_DE_CREDITO(TS_BEHvale input);
        void SP_ITBCP_INSERTAR_CREDITO_CLIENTE(TS_BECredcliente input);
        bool SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA(string tarjeta, decimal puntos, decimal valoracumulado);
        void SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_VALOR_ACUMULADO(TS_BEAfiliaciontarj input);
        void SP_ITBCP_INSERTAR_AFILIACION_PUNTOS(TS_BEAfiliacionptos input);
        void SP_ITBCP_ACTUALIZAR_AFILIACION_TARJETA_PUNTOS_GANADOS(TS_BEAfiliaciontarj input);
        List<TS_BEParametro> SP_ITBCP_SELECT_PARAMETROS(TS_BEParametro input);
        void SP_ITBCP_INSERTAR_VENTA(TS_BEVenta input);
        void SP_ITBCP_INSERTAR_VENTAP(TS_BEVentap input);
        decimal SP_ITBCP_CALCULAR_COSTO_PROMEDIO(string cdProducto, DateTime fechaProceso);
        void SP_ITBCP_INSERTAR_VENTAD(TS_BEVentad input);
        void SP_ITBCP_INSERTAR_DESPACHO(TS_BEDespachos input);
        void SP_ITBCP_ACTUALIZAR_SALDOCLIENTE(TS_BESaldoclid input);
        List<TS_BESaldoclid> SP_ITBCP_SELECT_SALDOCLIENTED1(TS_BESaldoclid input);
        void SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_1(TS_BESaldoclid input);
        void SP_ITBCP_ACTUALIZAR_SALDOCLIENTE_2(TS_BESaldoclid input);
        void SP_ITBCP_ELIMINAR_TMPMOVPUNTOS(TS_BETmpmovpuntos input);
        void SP_ITBCP_INSERTAR_TARJETABONUS(TS_BETarjbonus input);
        void SP_ITBCP_INSERTAR_STOCK(TS_BEStock input);
        void SP_ITBCP_ACTUALIZAR_STOCK(TS_BEStock input);
        void SP_ITBCP_INSERTAR_INSUMOISR(TS_BEInsumoisr input);
        void SP_ITBCP_ACTUALIZAR_ARTICULO(TS_BEArticulo input);
        void SP_ITBCP_INSERTAR_CIERREMOV(TS_BECierremov input);
        void SP_ITBCP_ACTUALIZAR_CIERREMOV(TS_BECierremov input);
        void SP_ITBCP_INSERTAR_CLIENTE(TS_BECliente input);
        void SP_ITBCP_ACTUALIZAR_CLIENTE(TS_BECliente input);
        void SP_ITBCP_INSERTAR_PLACA(TS_BEPlaca input);

        // agregado 09/03/2019

        void SP_ITBCP_ELIMINAR_CVENTA(TS_BECventa input);
        void SP_ITBCP_ELIMINAR_CVENTAD(TS_BECventad input);
        void SP_ITBCP_ELIMINAR_VALE(TS_BEVale input);
        void SP_ITBCP_INSERTAR_HVALE(TS_BEHvale input);
        void SP_ITBCP_ACTUALIZAR_CDHASH_VENTA(TS_BEVenta input, string nombreTabla);
        void SP_ITBCP_ACTUALIZAR_OPTRAN(TS_BEOp_Tran input);
        List<TS_BEInsumo> SP_ITBCP_SELECT_INSUMOS(TS_BEInsumo input);
        List<TS_BELoteria> SP_ITBCP_SELECT_LOTERIA(TS_BELoteria input);
        List<TS_BELoteriahora> SP_ITBCP_SELECT_LOTERIA_HORA(TS_BELoteriahora input);
        List<TS_BELoteriaart> SP_ITBCP_SELECT_LOTERIART(TS_BELoteriaart input);
        List<TS_BELoteriawin> SP_ITBCP_SELECT_LOTERIAWIN(TS_BELoteriawin input);
        void SP_ITBCP_INSERTAR_LOTERIAWIN(TS_BELoteriawin input);
        void SP_ITBCP_ACTUALIZAR_LOTERIAWIN(TS_BELoteriawin input);
        List<TS_BENropos> SP_ITBCP_LISTAR_NROPOS();

    }
}
