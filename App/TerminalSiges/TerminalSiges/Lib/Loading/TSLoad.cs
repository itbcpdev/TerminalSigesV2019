using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalSiges.Lib.Loading
{
    public enum LoadEstado
    {
        ErrorInternet = 0,
        ErrorSistema = 1,
        SinAutorizacion = 2,
        Autorizacion = 3,
        EsperandoRespuesta = 4,
        InformacionNoObtenida = 5,
        InformacionObtenida = 6
    }
    public class TSLoad
    {

        public LoadEstado EstadoRespuesta { get; private set; }
        public TS_BESales vSales { get; set; }
        public TSLoad(LoadEstado resultado, TS_BESales result)
        {
            EstadoRespuesta = resultado;
            vSales = result;
        }
        public TSLoad(LoadEstado resultado )
        {
            EstadoRespuesta = resultado;
        }
    }
}
