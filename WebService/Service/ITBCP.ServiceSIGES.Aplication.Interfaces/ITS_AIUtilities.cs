using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication.Interfaces
{
    public interface ITS_AIUtilities
    {
        string CheckPassword(string input);
        string GetSplitDecimal(decimal input);
        bool IsNumero(string dato);
        bool IsRucValido(string dato);
        bool Valruc(string valor);
        bool EnviarEmail(TS_BECliente input);
        string Encriptar(TS_BEEncripta input);
        string Desencriptar(TS_BEEncripta input);
        bool CopyFiles(string folder);
        string GenerateToken(); 
        TS_BEResultSunat ConsultaRuc(string ruc);
        bool CheckForInternetConnection();
        List<TS_BEArticulo> ReadTopOneFileDbf(string fileName, string cara);
        List<TS_BEArticulo> ReadAllFileDbf(string fileName,string cara);
        TS_BEOpTransOutput ReadTopFileDbf(string fileName, string cant);
        TS_BEClienteCreditoOutput OBTENER_CLIENTE_CREDITO_COORPORATIVO_WS(string xCod);
        TS_BEMensaje ACTUALIZAR_SALDO_CLIENTE_CREDITO_COORPORATIVO_WS(TS_BESaldoWS saldoWS);
        TS_BEMensaje ANULAR_DOCUMENTO_CREDITO_COORPORATIVO(TS_BEDocumento documento);
        int RandomNumber(int min, int max);
        string RandomString(int size, bool lowerCase);
        String ToCardinal(Decimal Numero);
        String Convertir(Decimal Numero, Int32 Decimales, String SeparadorDecimalSalida, String MascaraSalidaDecimal, Boolean EsMascaraNumerica, Boolean LetraCapital, Boolean ConvertirDecimales, Boolean ApocoparUnoParteEntera, Boolean ApocoparUnoParteDecimal);
        int ReadAllFileDbfCount(string fileName);
        void redondea_numero(TS_BEParametro parametros, TS_BECabeceraOutPut cCabeceraOutPut);
        void genera_globales(TS_BEDocumento documento);

        bool RETORNAR_DBF_VENTA(string rutaTran, string cara, string cdtipodoc, string nrodocumento);
        bool ACTUALIZAR_DBF_VENTA(string rutaTran, string cara, string cdtipodoc, string nrodocumento, string gasboy);
        bool ELIMINAR_DBF_VENTA(string rutaTran, string cara, out string respuesta);
        decimal RoundIndecopi(Decimal input);

        string GenerateTokenJwt(string Name, string Password);
        bool VerifyToken(HttpRequestMessage request, out string name, out string token);
    }
}
