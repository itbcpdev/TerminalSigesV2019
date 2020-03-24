using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOTipoPago
    {
        List<TS_BETipopago> LISTAR_TIPO_PAGOS(TS_BETipopago input);
        List<TS_BETipopago> LISTAR_TIPO_PAGO_EFECTIVO(TS_BETipopago input);
    }
}
