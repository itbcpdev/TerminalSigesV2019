using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.CierreX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface ITS_AICierre
    { //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        //Metodo         : SP_ITBCP_OBTENER_CIERRE
        //Creado por     : Teófilo Chambilla Aquino (01/02/2019)
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        ///<summary>Permite recuperar datos de la Tabla =  [ cierre] </summary>
        ///
        TS_BECierre OBTENER_CIERRE(TS_BECierre input);
        TS_BE_ReporteCierreX GENERAR_REPORTE_CIERRE_X(TS_BECierreXInput input);
        List<TS_BECierres> SP_ITBCP_LISTAR_ULTIMO_CIERRE(TS_BECierres input);
        List<TS_BECierre> SP_ITBCP_LISTAR_CIERRE(TS_BECierre input);
    }
}
