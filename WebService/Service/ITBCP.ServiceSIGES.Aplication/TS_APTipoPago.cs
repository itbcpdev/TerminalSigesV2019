using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APTipoPago: ITS_AITipoPago
    {
        private readonly ITS_DOTipoPago _ITS_DOTipoPago;

        public TS_APTipoPago(ITS_DOTipoPago ITS_DOTipoPago)
        {
            _ITS_DOTipoPago = ITS_DOTipoPago;
        }

        public List<TS_BETipopago> LISTAR_TIPO_PAGOS(TS_BETipopago input)
        {
            List<TS_BETipopago> output = new List<TS_BETipopago>();
            try
            {
                output = _ITS_DOTipoPago.LISTAR_TIPO_PAGOS(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BETipopago> LISTAR_TIPO_PAGO_EFECTIVO(TS_BETipopago input)
        {
            List<TS_BETipopago> output = new List<TS_BETipopago>();
            try
            {
                output = _ITS_DOTipoPago.LISTAR_TIPO_PAGO_EFECTIVO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }
    }
}
