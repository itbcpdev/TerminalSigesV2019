using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    public class TS_BEDocumento
    {
        public TS_BEEmisor cEmisor;
        public TS_BECabecera cCabecera { get; set; }
        public List<TS_BEArticulo> cDetalles { get; set; }
        public List<TS_BEPago> cPagos { get; set; }
        public TS_BETerminal cTerminal { get; set; }
        public TS_BEParametro cParametro { get; set; }
        public TS_BEParameters cTab0S00 { get; set; }
        public TS_BEClienteInput cCliente { get; set; }
        public TS_BECambio cTipoCambio { get; set; }
        public TS_BELocal cLocal { get; set; }
        public TS_BEFormato cFormato { get; set; }
        public TS_BEGlobal cGlobal { get; set; }
        public TS_BEVentag cVentag { get; set; }
        public TS_BEVentar cVentar { get; set; }
        public TS_BELoadInput cLoading { get; set; }
        public string lextension { get; set; }
        public string ltrama { get; set; }
        public TS_BEGrabarConfig cConfig {get; set;}

    }
}
