using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalSiges.Lib.Customer
{
    public enum CustomerEstado
    {
        ErrorInternet = 0,
        ErrorSistema = 1,
        SinAutorizacion = 2,
        Autorizacion = 3,
        EsperandoRespuesta = 4,
        InformacionNoObtenida = 5,
        InformacionObtenida = 6,
        ClienteSinSaldo =7,
        ClienteConSaldo =8
    }
    public class TSCustomer
    {
        public TS_BESaldoclid vSaldoCliente { get; set; }
        public CustomerEstado EstadoRespuesta { get; private set; }
        public TS_BEClienteLista[] vClient { get; set; }
        public TS_BEClienteOutput vClientOuput { get; set; }
        public TS_BESales vSales { get; set; }
        public TSCustomer(CustomerEstado resultado, TS_BESales sales)
        {
            EstadoRespuesta = resultado;
            vSales = sales;
        }
        public TSCustomer(CustomerEstado resultado)
        {
            EstadoRespuesta = resultado;
        }
        public TSCustomer(CustomerEstado resultado, TS_BEClienteLista[] cliente)
        {
            EstadoRespuesta = resultado;
            vClient = cliente;
        }
        public TSCustomer(CustomerEstado resultado, TS_BESaldoclid saldo)
        {
            EstadoRespuesta = resultado;
            vSaldoCliente = saldo;
        }
        public TSCustomer(CustomerEstado resultado, TS_BEClienteOutput cliente)
        {
            EstadoRespuesta = resultado;
            vClientOuput = cliente;
        }
    }
}
