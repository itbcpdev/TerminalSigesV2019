using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using System.Collections.Generic;

namespace ITBCP.ServiceSIGES.Domain
{
    public interface ITS_DODeposito
    {
        TS_BEMensaje   VERIFICAR_GRIFERO_LADOS();
        TS_BEMensaje   AUTENTICAR_DEPOSITO_GRIFERO(TS_BELoginVendedor input);
        TS_BEMensaje   REGISTRAR_DEPOSITO(TS_BEDeposito input,TS_BETerminal terminal);
        TS_BEDepositos CONSULTAR_DEPOSITOS(TS_BEDeposito input,TS_BETerminal terminal);
        TS_BEMensaje   REGISTRAR_GRIFERO_LADOS(TS_BELado input);
        TS_BELados OBTENER_GRIFERO_LADOS(TS_BELado input);
        TS_BEDeposito OBTENER_DEPOSITO(TS_BEDepositoEInput input, TS_BETerminal terminal);
        TS_BEMensaje ELIMINAR_GRIFERO_LADOS(TS_BELadoEInput input);
        TS_BEMensaje ELIMINAR_DEPOSITOS(TS_BEDepositoEInput input, TS_BETerminal terminal);
        TS_BEVendedores OBTENER_VENDEDORES(string cdempresa);
        TS_BEVendedores OBTENER_VENDEDORES();
        List<TS_BEUsers> OBTENER_USUARIOS_TODOS();
        TS_BEVendedor OBTENER_VENDEDOR(string cdusuario);
        TS_BEMensaje AUTENTICAR_CONFIGURACION_LADOS(TS_BELoginVendedor input);
    }
}
