using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOInicioDia
    {
         bool EJECUTAR_INICIO_DIA(string seriehd, string cdusuario);

    }
}
