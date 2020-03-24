using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface ITS_AITarjeta
    {
        List<TS_BETarjeta> Obtener_Tarjetas();
        TS_BETarjeta ObtenerTarjeta(TS_BETarjeta input);
        TS_BERespuestaCanje VALIDAR_CANJE(List<TS_BEDetalleInput> cDetalle, TS_BEClienteInput cCliente);
        TS_BEArticuloOutput OBTENER_ARTICULOS_POR_PREFIJO(string prefijo);
        TS_BEArticuloOutput OBTENER_ARTICULOS_POR_TARJETA(string tarjeta);
    }
}
