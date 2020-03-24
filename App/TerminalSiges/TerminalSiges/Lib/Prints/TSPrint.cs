using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalSiges.Lib.Prints
{
    public enum PrintEstado
    {
        ErrorInternet = 0,
        ErrorSistema = 1,
        SinAutorizacion = 2,
        Autorizacion = 3,
        EsperandoRespuesta = 4,
        InformacionNoObtenida = 5,
        InformacionObtenida = 6,
        VentaRegistrada = 7,
        VentaNoRegistrada = 8,
        ImpresionCorrecto = 9,
        ImpresionIncorrecto = 10
    }
    public class TSPrint
    {
        public TS_BERespuesta vRespuesta { get; set; }
        public TS_BEMensaje vMensaje { get; set; }
        public TS_BEDepositos vDepositos { get; set; }
        public TS_BEVendedores vVendedores { get; set; }
        public TS_BELados vGriferoCara { get; set; }
        public TS_BEReimpresionLOutput vReImpresion { get; set; }
        public TS_BEInicioDiaOutput vInicioDia { get; set; }
        public PrintEstado EstadoRespuesta { get; private set; }
        public TSPrint(PrintEstado resultado)
        {
            EstadoRespuesta = resultado;
        } 

        public TSPrint(PrintEstado resultado, TS_BEReimpresionLOutput _input)
        {
            EstadoRespuesta = resultado;
            vReImpresion = _input;
        }
        public TSPrint(PrintEstado EstadoRespuesta, TS_BEInicioDiaOutput vInicioDia)
        {
            this.EstadoRespuesta = EstadoRespuesta;
            this.vInicioDia = vInicioDia;
        }
        public TSPrint(PrintEstado resultado, TS_BEDepositos _input)
        {
            EstadoRespuesta = resultado;
            vDepositos = _input;
        }
        public TSPrint(PrintEstado resultado, TS_BERespuesta _input)
        {
            EstadoRespuesta = resultado;
            vRespuesta = _input;
        }
        public TSPrint(PrintEstado resultado, TS_BEMensaje _input)
        {
            EstadoRespuesta = resultado;
            vMensaje = _input;
        }
        public TSPrint(PrintEstado resultado, TS_BEVendedores _input)
        {
            EstadoRespuesta = resultado;
            vVendedores = _input;
        }
        public TSPrint(PrintEstado resultado, TS_BELados _input)
        {
            EstadoRespuesta = resultado;
            vGriferoCara = _input;
        }


    }
}
