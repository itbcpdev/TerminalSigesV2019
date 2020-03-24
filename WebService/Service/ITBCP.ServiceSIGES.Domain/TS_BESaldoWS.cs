using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain
{
    public class TS_BESaldoWS
    {
        public TS_BESaldoWS(TS_BEClienteInput cliente,TS_BEParametro parametro,TS_BETerminal terminal,TS_BECabecera cabecera)
        {
            this.cdlocal = parametro.cdlocal;
            this.cdcliente = cliente.cdcliente;
            this.nrotarjeta = cliente.nroTarjeta;
            this.mtosoles = cabecera.mtototal.ToString();
            this.nroseriemaq = terminal.nroseriemaq;
            this.cdtipodoc = cabecera.cdtipodoc;
            this.nrodocumento = cabecera.nrodocumento;
            this.mensaje = "CONSUMO DESDE POS MOVIL";
               
            
        }
        public string cdlocal { get; set; }
        public string cdcliente { get; set; }
        public string nrotarjeta { get; set; }
        public string mtosoles { get; set; }
        public string nroseriemaq { get; set; }
        public string cdtipodoc { get; set; }
        public string nrodocumento { get; set; }
        public string mensaje { get; set; }
    }
}
