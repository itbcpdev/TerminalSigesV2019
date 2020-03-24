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
   public  class TS_APTipoCambio: ITS_AITipoCambio
    {
        private readonly ITS_DOTipoCambio _ITS_DOTipoCambio;
        public TS_APTipoCambio(ITS_DOTipoCambio ITS_DOTipoCambio)
        {
            _ITS_DOTipoCambio = ITS_DOTipoCambio;
        }

        public TS_BECambio OBTENER_TIPOCAMBIO()
        {
            TS_BECambio output = new TS_BECambio();
            try
            {
                output = _ITS_DOTipoCambio.OBTENER_TIPOCAMBIO();
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }

        public List<TS_BECambio> LISTARTIPOCAMBIO(TS_BECambio input)
        {
            List<TS_BECambio> output = new List<TS_BECambio>();
            try
            {
                output = _ITS_DOTipoCambio.LISTARTIPOCAMBIO(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }
    }
}
