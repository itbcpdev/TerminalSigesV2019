using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Articulo;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOArticulo
    {
        List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULO_POR_GRUPO_COMBUSTIBLE(string cdgrupo02);
        TS_BEArticulo ObtenerArticulByCodigo(string cdarticulo);
        List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULO(string cdgrupo02);
        List<TS_BEArticulo> SP_ITBCP_LISTAR_ARTICULOS(string cdgrupo02);
        List<TS_BEArticulo> ListarArticuloPrecios(string glosa);
    }
}
