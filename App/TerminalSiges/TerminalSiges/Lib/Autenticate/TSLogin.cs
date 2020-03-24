using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace TerminalSiges.Lib.Autenticate
{
    public enum LoginEstado
    {
        ErrorInternet = 0,
        ErrorSistema = 1,
        SinAutorizacion = 2,
        Autorizacion = 3,
        EsperandoRespuesta = 4,
        InformacionObtenida = 5
    }
    public class TSLogin
    {
        public LoginEstado EstadoRespuesta { get; private set; }
        public TS_BELogin vLogin { get; set; }
        public TS_BEMensaje vMensaje { get; set; }
        public TS_BEEmpresaUser[] vEmpresa { get; set; }
        public TS_BELoginOutPut vLoginOutput { get; set; }
        public bool EmpresaConsultado { get; set; }
        public TS_BELoginTurnoOutPut vRespuestaTurno { get; set; }
        public TSLogin(LoginEstado resultado)
        {
            EstadoRespuesta = resultado;
        }
        public TSLogin(LoginEstado EstadoRespuesta, TS_BELoginTurnoOutPut vRespuestaTurno)
        {
            this.EstadoRespuesta = EstadoRespuesta;
            this.vRespuestaTurno = vRespuestaTurno;
        }
        public TSLogin(LoginEstado resultado, TS_BEEmpresaUser[] empresa)
        {
            EstadoRespuesta = resultado;
            vEmpresa = empresa;
        }
        public TSLogin(LoginEstado resultado, TS_BEMensaje _input)
        {
            EstadoRespuesta = resultado;
            vMensaje = _input;
        }
        public TSLogin(LoginEstado resultado, TS_BELoginOutPut loginOutput)
        {
            EstadoRespuesta = resultado;
            vLoginOutput = loginOutput;
        }
    }
}
