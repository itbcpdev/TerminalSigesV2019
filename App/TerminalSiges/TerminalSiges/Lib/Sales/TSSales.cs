using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalSiges.Lib.Sales
{
    public enum SalesEstado
    {
        ErrorInternet = 0,
        ErrorSistema = 1,
        SinAutorizacion = 2,
        Autorizacion = 3,
        EsperandoRespuesta = 4,
        InformacionNoObtenida = 5,
        InformacionObtenida = 6,
        VentaRegistrada =7 ,
        VentaNoRegistrada =8,
        RegistroEliminado =9,
        RegistroNoEliminado =10
           
    }
    public class TSSales
    {
        public SalesEstado EstadoRespuesta { get; private set; }
        public SalesEstado EstadoCliente { get; private set; }
        public string Respuesta { get; set; }

        public string Codigo { get; set; }
        public TS_BESales vSales { get; set; }
        public TS_BECabeceraOutPut vTransaccion { get; set; }
        public TS_BEArticulo vDetalle { get; set; }
        public TS_BECorrelativoOutput vCorrelativo { get; set; }
        public TS_BEArticulo[] vArticulos { get; set; }
        public TS_BENropos[] vNroPos {get;set;}
        public TS_BELados vLados { get; set; }
        public bool SalesConsultado { get; set; }
        public TS_BECara[] vCaras { get; set; }
        public TS_BEMensaje vMensaje { get; set; }
        public TS_BEPTarjeta[] vPrefijos { get; set; }
        public TS_BEArticuloOutput vArticulosPrefijo { get; set; }
        public TSSales(SalesEstado resultado)
        {
            EstadoRespuesta = resultado;
        }

        public TSSales(SalesEstado resultado,TS_BERetornoTransaccion respuesta)
        {
            EstadoRespuesta = resultado;
            Respuesta = respuesta.Mensaje;
            Codigo = respuesta.Codigo;
        }

        public TSSales(SalesEstado resultado,TS_BECara[] vCaras)
        {
            EstadoRespuesta = resultado;
            this.vCaras = vCaras;
        }

        public TSSales(SalesEstado resultado, string respuesta)
        {
            EstadoRespuesta = resultado;
            Respuesta = respuesta;
        }
        public TSSales(SalesEstado resultado, TS_BENropos[] input)
        {
            EstadoRespuesta = resultado;
            vNroPos = input;
        }
        public TSSales(SalesEstado resultado, TS_BECabeceraOutPut retorno)
        {
            EstadoRespuesta = resultado;
            vTransaccion = retorno;
    
        }
        public TSSales(SalesEstado resultado, TS_BECorrelativoOutput correlativo)
        {
            EstadoRespuesta = resultado;
            vCorrelativo = correlativo;
        }
        public TSSales(SalesEstado resultado, TS_BESales sales)
        {
            EstadoRespuesta = resultado;
            vSales = sales;
        }
       
        public TSSales(SalesEstado resultado, TS_BEArticulo cDetalle)
        {
            EstadoRespuesta = resultado;
            vDetalle = cDetalle;
        }
        public TSSales(SalesEstado resultado, TS_BEArticulo[] cArticulos)
        {
            EstadoRespuesta = resultado;
             vArticulos = cArticulos;
        }
        public TSSales(SalesEstado resultado, TS_BEMensaje respuesta)
        {
            EstadoRespuesta = resultado;
            vMensaje = respuesta;
        }
        public TSSales(SalesEstado resultado, TS_BELados respuesta)
        {
            EstadoRespuesta = resultado;
            vLados = respuesta;
        }
        public TSSales(SalesEstado resultado, TS_BEPTarjeta[] respuesta)
        {
            EstadoRespuesta = resultado;
            vPrefijos = respuesta;
        }
        public TSSales(SalesEstado resultado, TS_BEArticuloOutput respuesta)
        {
            EstadoRespuesta = resultado;
            vArticulosPrefijo = respuesta;
        }
    }
    
}
