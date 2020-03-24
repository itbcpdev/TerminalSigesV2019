using ITBCP.ServiceSIGES.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOServer
    {
        string OBTENER_FECHA_SERVIDOR();
        bool EXISTE_TABLA(string nombreTabla);
        TS_BEUsers OBTENER_USUARIO(string cdusuario);
    }
}
