using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.CierreX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APCierre : ITS_AICierre
    {

        private readonly ITS_DOCierre _TS_DOCierre;
        private readonly ITS_DOCara _TS_DOCara;
        private readonly ITS_DOTerminal _TS_DOTerminal;
        private readonly ITS_DOMoneda _TS_DOMoneda;
        private readonly ITS_DOOpTransaction _TS_DOOpTransaction;
        public TS_APCierre(
                           ITS_DOCierre TS_DOCierre,
                            ITS_DOCara TS_DOCara,
                                ITS_DOTerminal TS_DOTerminal,
                                    ITS_DOMoneda TS_DOMoneda,
                                        ITS_DOOpTransaction TS_DOOpTransaction)
        {
            _TS_DOCierre = TS_DOCierre;
            _TS_DOCara = TS_DOCara;
            _TS_DOTerminal = TS_DOTerminal;
            _TS_DOMoneda = TS_DOMoneda;
            _TS_DOOpTransaction = TS_DOOpTransaction;
        }

        public TS_BE_ReporteCierreX GENERAR_REPORTE_CIERRE_X(TS_BECierreXInput input)
        {
            input.cara = "01";
            input.seriehd = "00E80BA6";

            string error = "";
            List<TS_BEOp_Tran> list_OpTrans = new List<TS_BEOp_Tran>();
            TS_BETerminal terminal = new TS_BETerminal();
            TS_BECara caras = new TS_BECara();

            caras = _TS_DOCara.OBTENER_CARA_POR_POSICION(new TS_BECara() { cara = input.cara });
            terminal = _TS_DOTerminal.OBTENER_TERMINAL_POR_SERIEHD(new TS_BETerminal() { seriehd = input.seriehd });
            list_OpTrans = _TS_DOOpTransaction.LISTAR_TRANSACTIONS_PENDIENTES(new TS_BEOp_Tran() { cara = caras.cara });
            if (list_OpTrans.Count > 0)
            {
                error += "Existen Transacciones Pendientes de Los Surtidores...";
                return null;
            }
            return null;
        }
        public List<TS_BECierres> SP_ITBCP_LISTAR_ULTIMO_CIERRE(TS_BECierres input)
        {
            List<TS_BECierres> output = new List<TS_BECierres>();
            try
            {
                output = _TS_DOCierre.SP_ITBCP_LISTAR_ULTIMO_CIERRE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }
        public List<TS_BECierre> SP_ITBCP_LISTAR_CIERRE(TS_BECierre input)
        {
            List<TS_BECierre> output = new List<TS_BECierre>();
            try
            {
                output = _TS_DOCierre.SP_ITBCP_LISTAR_CIERRE(input);
            }
            catch (Exception ex)
            {
                throw new Exception(Helpers.RaiseError(ex));
            }
            return output;
        }
        public TS_BECierre OBTENER_CIERRE(TS_BECierre input)
        {
            throw new NotImplementedException();
        }
    }
}
