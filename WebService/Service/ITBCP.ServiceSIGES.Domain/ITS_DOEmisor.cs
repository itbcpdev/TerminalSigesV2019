using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOEmisor
    {
        TS_BEEmisor OBTENER_EMISOR_POR_EMPRESA(TS_BEEmisor input);
    }
}
