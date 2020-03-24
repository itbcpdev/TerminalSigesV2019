using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOTerminal
    {//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        //Metodo         : SP_ITBCP_LISTAR_TERMINALES
        //Creado por     : Teófilo Chambilla Aquino (01/02/2019)
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        ///<summary>Permite recuperar datos de la Tabla =  [ terminal] </summary>
        List<TS_BETerminal> LISTAR_TERMINALES(TS_BETerminal input);
        TS_BETerminal OBTENER_TERMINAL_POR_SERIEHD(TS_BETerminal input);
        TS_BETerminal OBTENER_TERMINAL_POR_NROPOS(TS_BETerminal input);
        TS_BETerminal OBTENER_TERMINAL_POR_USUARIO(TS_BETerminal input);
        List<TS_BETerminal> LISTAR_TERMINAL_POR_USUARIO(TS_BETerminal input);
        List<TS_BENropos> SP_ITBCP_LISTAR_NROPOS();
        bool UpdateCorrelativo(string TipoDoc, string NroDocumento, string SerieHd, SqlTransaction pSqlTransaction);

    }
}
