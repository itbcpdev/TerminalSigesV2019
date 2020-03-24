using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOIgv
    {
        List<TS_BETipo_Igv> OBTENER_IGV(TS_BETipo_Igv input);
    }
}
