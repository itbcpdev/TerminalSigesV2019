using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITBCP.ServiceSIGES.Domain.Entities;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DOTurno
    {
        bool INICIAR_CAMBIO_TURNO_SYSCON();
        bool VERIFICAR_CAMBIO_TURNO_SISCON();
        bool TERMINAR_CAMBIO_TURNO_SISCON();
        bool DESHACER_CAMBIO_TURNO_SISCON();


        bool INICIAR_CAMBIO_TURNO_PEC();
        bool VERIFICAR_CAMBIO_TURNO_PEC();
        bool TERMINAR_CAMBIO_TURNO_PEC();
        bool DESHACER_CAMBIO_TURNO_PEC();
        bool BLOQUEAR_DESBLOQUEAR_PLAYA_PEC(bool estado);

        bool PROCESAR_CAMBIO_TURNO_SIN_CONTROLADOR();
    }
}
