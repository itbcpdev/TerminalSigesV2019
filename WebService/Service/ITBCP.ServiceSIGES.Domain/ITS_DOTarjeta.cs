using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOTarjeta
    {
        List<TS_BETarjeta> Obtener_Tarjetas();
        TS_BETarjeta ObtenerTarjeta(TS_BETarjeta input);
        List<TS_BEArticulo> LISTAR_ARTICULOS_CANJE(string tarjeta);
        TS_BEArticuloOutput OBTENER_ARTICULOS_POR_PREFIJO(string prefijo);
        TS_BEArticuloOutput OBTENER_ARTICULOS_POR_TARJETA(string tarjeta);
    }
}
