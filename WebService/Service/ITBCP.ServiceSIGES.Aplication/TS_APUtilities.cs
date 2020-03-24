using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APUtilities : ITS_AIUtilities
    {
        readonly string stringWSSaldo = ConfigurationManager.AppSettings["stringWSSaldo"];
        private static Service1SoapClient _clientSaldos;

        #region Numeros a texto
        private const int UNI = 0, DIECI = 1, DECENA = 2, CENTENA = 3;
        private static string[,] _matriz = new string[CENTENA + 1, 10]
            {
            {null," uno", " dos", " tres", " cuatro", " cinco", " seis", " siete", " ocho", " nueve"},
            {" diez"," once"," doce"," trece"," catorce"," quince"," dieciséis"," diecisiete"," dieciocho"," diecinueve"},
            {null,null,null," treinta"," cuarenta"," cincuenta"," sesenta"," setenta"," ochenta"," noventa"},
            {null,null,null,null,null," quinientos",null," setecientos",null," novecientos"}
            };

        private const Char sub = (Char)26;
        public const String SeparadorDecimalSalidaDefault = "con";
        public const String MascaraSalidaDecimalDefault = "00'/100 SOLES'";
        public const Int32 DecimalesDefault = 2;
        public const Boolean LetraCapitalDefault = false;
        public const Boolean ConvertirDecimalesDefault = false;
        public const Boolean ApocoparUnoParteEnteraDefault = false;
        public const Boolean ApocoparUnoParteDecimalDefault = false;

        public String ToCardinal(Decimal Numero)
        {
            return Convertir(Numero, DecimalesDefault, SeparadorDecimalSalidaDefault, MascaraSalidaDecimalDefault, true, LetraCapitalDefault, ConvertirDecimalesDefault, ApocoparUnoParteEnteraDefault, ApocoparUnoParteDecimalDefault);
        }
        public String Convertir(Decimal Numero, Int32 Decimales, String SeparadorDecimalSalida, String MascaraSalidaDecimal, Boolean EsMascaraNumerica, Boolean LetraCapital, Boolean ConvertirDecimales, Boolean ApocoparUnoParteEntera, Boolean ApocoparUnoParteDecimal)
        {
            Int64 Num;
            Int32 terna, centenaTerna, decenaTerna, unidadTerna, iTerna;
            String cadTerna;
            StringBuilder Resultado = new StringBuilder();

            Num = (Int64)Math.Abs(Numero);

            if (Num >= 1000000000000 || Num < 0) throw new ArgumentException("El número '" + Numero.ToString() + "' excedió los límites del conversor: [0;1.000.000.000.000)");
            if (Num == 0)
                Resultado.Append(" cero");
            else
            {
                iTerna = 0;
                while (Num > 0)
                {
                    iTerna++;
                    cadTerna = String.Empty;
                    terna = (Int32)(Num % 1000);

                    centenaTerna = (Int32)(terna / 100);
                    decenaTerna = terna % 100;
                    unidadTerna = terna % 10;

                    if ((decenaTerna > 0) && (decenaTerna < 10))
                        cadTerna = _matriz[UNI, unidadTerna] + cadTerna;
                    else if ((decenaTerna >= 10) && (decenaTerna < 20))
                        cadTerna = cadTerna + _matriz[DIECI, unidadTerna];
                    else if (decenaTerna == 20)
                        cadTerna = cadTerna + " veinte";
                    else if ((decenaTerna > 20) && (decenaTerna < 30))
                        cadTerna = " veinti" + _matriz[UNI, unidadTerna].Substring(1);
                    else if ((decenaTerna >= 30) && (decenaTerna < 100))
                        if (unidadTerna != 0)
                            cadTerna = _matriz[DECENA, (Int32)(decenaTerna / 10)] + " y" + _matriz[UNI, unidadTerna] + cadTerna;
                        else
                            cadTerna += _matriz[DECENA, (Int32)(decenaTerna / 10)];

                    switch (centenaTerna)
                    {
                        case 1:
                            if (decenaTerna > 0) cadTerna = " ciento" + cadTerna;
                            else cadTerna = " cien" + cadTerna;
                            break;
                        case 5:
                        case 7:
                        case 9:
                            cadTerna = _matriz[CENTENA, (Int32)(terna / 100)] + cadTerna;
                            break;
                        default:
                            if ((Int32)(terna / 100) > 1) cadTerna = _matriz[UNI, (Int32)(terna / 100)] + "cientos" + cadTerna;
                            break;
                    }

                    if ((iTerna > 1 | ApocoparUnoParteEntera) && decenaTerna == 21)
                        cadTerna = cadTerna.Replace("veintiuno", "veintiún");
                    else if ((iTerna > 1 | ApocoparUnoParteEntera) && unidadTerna == 1 && decenaTerna != 11)
                        cadTerna = cadTerna.Substring(0, cadTerna.Length - 1);

                    else if (decenaTerna == 22) cadTerna = cadTerna.Replace("veintidos", "veintidós");
                    else if (decenaTerna == 23) cadTerna = cadTerna.Replace("veintitres", "veintitrés");
                    else if (decenaTerna == 26) cadTerna = cadTerna.Replace("veintiseis", "veintiséis");

                    switch (iTerna)
                    {
                        case 3:
                            if (Numero < 2000000) cadTerna += " millón";
                            else cadTerna += " millones";
                            break;
                        case 2:
                        case 4:
                            if (terna > 0) cadTerna += " mil";
                            break;
                    }
                    Resultado.Insert(0, cadTerna);
                    Num = (Int32)(Num / 1000);
                }
            }


            if (Decimales > 0)
            {
                Resultado.Append(" " + SeparadorDecimalSalida + " ");
                Int32 EnteroDecimal = (Int32)Math.Round((Double)(Numero - (Int64)Numero) * Math.Pow(10, Decimales), 0);
                if (ConvertirDecimales)
                {
                    Boolean esMascaraDecimalDefault = MascaraSalidaDecimal == MascaraSalidaDecimalDefault;
                    Resultado.Append(Convertir((Decimal)EnteroDecimal, 0, null, null, EsMascaraNumerica, false, false, (ApocoparUnoParteDecimal && !EsMascaraNumerica/*&& !esMascaraDecimalDefault*/), false) + " "
                        + (EsMascaraNumerica ? "" : MascaraSalidaDecimal));
                }
                else
                    if (EsMascaraNumerica) Resultado.Append(EnteroDecimal.ToString(MascaraSalidaDecimal));
                else Resultado.Append(EnteroDecimal.ToString() + " " + MascaraSalidaDecimal);
            }
            return Resultado.ToString().Trim();
        }
        #endregion FinNumerosAtexto

        public string CheckPassword(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            var lvalor = 0;
            for (int i = 1; i < input.Length + 1; i++)
            {
                var lCar = 0;
                switch (i)
                {
                    case 1:
                        lCar = 1;
                        break;
                    case 2:
                        lCar = 3;
                        break;
                    case 3:
                        lCar = 5;
                        break;
                    case 4:
                        lCar = 7;
                        break;
                    case 5:
                        lCar = 9;
                        break;
                    case 6:
                        lCar = 11;
                        break;

                }
                lvalor += (Convert.ToChar(input.Substring(i - 1, 1))) * lCar;
            }

            return lvalor.ToString();
        }
        public bool IsNumero(string dato)
        {
            try
            {
                long result = Convert.ToInt64(dato);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string GetSplitDecimal (decimal input)
        {
            var values = input.ToString().Split('.');
            string firstValue = "0";
            string secondValue = "00";
            if (values.Length == 2)
            {
                firstValue = (values[0]);
                secondValue = (values[1]);
                
            }
            else
            {
                firstValue = (values[0]);               
            }
            return secondValue;
        }
        public decimal RoundIndecopi(Decimal input)
        {
            var values = input.ToString().Split('.');
            if (values.Length == 2)
            {
                var secondValue = (values[1]);
                if(secondValue.Length == 2)
                {
                    return (Convert.ToDecimal(secondValue.Substring(1, 1)) / 100);
                }
            }
            return 0;
        }
        public bool IsRucValido(string dato)
        {
            return (!(string.IsNullOrEmpty(dato) || !IsNumero(dato) || dato.Length != 11 || !Valruc(dato)));
        }
        public bool Valruc(string valor)
        {
            valor = valor.Trim();
            if (IsNumero(valor))
            {
                if (valor.Length == 11)
                {
                    var suma = 0;
                    var x = 6;
                    for (int i = 0; i < valor.Length - 1; i++)
                    {
                        if (i == 4) x = 8;
                        var digito = valor[i] - '0';
                        x--;
                        if (i == 0) suma += (digito * x);
                        else suma += (digito * x);
                    }
                    var resto = suma % 11;
                    resto = 11 - resto;
                    if (resto >= 10) resto = resto - 10;
                    if (resto == valor[(valor.Length - 1)] - '0')
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool EnviarEmail(TS_BECliente input)
        {
            try
            {
                if (input.emcliente == null)
                {
                    return true;
                }

                var pathserver = HostingEnvironment.MapPath(@"~/assets/resources/CorreoCliente.html");
                var htmlCorreo = File.ReadAllText(pathserver);
                SmtpClient servidor = new SmtpClient(ConfigurationManager.AppSettings["SMTP_SERVER"], Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_PORT"]));
                servidor.DeliveryMethod = SmtpDeliveryMethod.Network;
                servidor.UseDefaultCredentials = false;
                servidor.EnableSsl = true;
                MailMessage msj = new MailMessage();
                msj.Subject = "Enviando comprobante de Pago";
                msj.To.Add(input.emcliente);
                var correosbcc = ConfigurationManager.AppSettings["EmailBCC"].ToString().Split(',');
                foreach (var correoDes in correosbcc)
                {
                    msj.Bcc.Add(correoDes);
                }
                msj.From = new MailAddress(ConfigurationManager.AppSettings["EmailRemitenteAC"]);
                msj.IsBodyHtml = true;
                msj.Body = htmlCorreo.Replace("[NOMBRES]", input.cliente).Replace("[CODIGO]", input.cdcliente);

                servidor.Send(msj);
                return true;
            }
            catch 
            {
                return false;

            }

        }
        public string Encriptar(TS_BEEncripta input)
        {
            const string _vct = "@1B2c3D4e5F6g7&'H8";
            const string _psw = "]p$ar@¡1x&?*";
            string strKey = "Pas5pr@se";

            if (input.key != null)
                strKey = input.key;

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(_vct);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(_psw);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(input.texto);
            try
            {
                PasswordDeriveBytes password = new PasswordDeriveBytes(strKey, saltValueBytes, "SHA1", 2);
                byte[] keyBytes = password.GetBytes(256 / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();

                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();

                string cipherText = Convert.ToBase64String(cipherTextBytes);
                return cipherText;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Desencriptar(TS_BEEncripta input)
        {
            const string _vct = "@1B2c3D4e5F6g7&'H8";
            const string _psw = "]p$ar@¡1x&?*";

            string strKey = "Pas5pr@se";

            if (input.key != null)
                strKey = input.key;

            try
            {

                byte[] initVectorBytes = Encoding.ASCII.GetBytes(_vct);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(_psw);
                byte[] cipherTextBytes = Convert.FromBase64String(input.texto);

                PasswordDeriveBytes password = new PasswordDeriveBytes(strKey, saltValueBytes, "SHA1", 2);
                byte[] keyBytes = password.GetBytes(256 / 8);

                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;

                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);

                memoryStream.Close();
                cryptoStream.Close();

                string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                return plainText;
            }
            catch (CryptographicException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool CopyFiles(string folder)
        {
            try
            {
                var pathserver = HostingEnvironment.MapPath("~/Uploads/" + folder);
                string pathForSaving = HostingEnvironment.MapPath("~/File/" + folder);

                DirectoryInfo dirOrigen = new DirectoryInfo(pathserver);
                DirectoryInfo dirDestino = new DirectoryInfo(pathForSaving);
                if (this.CreateFolderIfNeeded(pathForSaving))
                {
                    FileInfo[] files = dirOrigen.GetFiles();

                    foreach (FileInfo file in files)
                    {
                        string temppath = Path.Combine(dirDestino.ToString(), file.Name);
                        //string filePath = Path.Combine(dirOrigen.ToString(), file.Name);
                        file.CopyTo(temppath, false);
                        file.Delete();
                    }
                    DeleteFolderIfNeeded(pathserver);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
        public TS_BEResultSunat ConsultaRuc(string ruc)
        {
            try
            { 
                string json = "{\"usuario\":\"\",\"clave\":\"\",\"ruc\":\"" + (ruc ?? "").Trim() + "\"}";
                WebRequest request = WebRequest.Create("http://161.132.177.54:9010/consultar");
                request.Method = "POST";
                string postData = json;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/json;";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
                response.Close();
                return JsonConvert.DeserializeObject<TS_BEResultSunat>(responseFromServer);
            }
            catch(Exception ex)
            {
                return null;
            }
            
        }
        public string GenerateToken()
        {
            throw new NotImplementedException();
        }
        public bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("https://www.google.com/"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool DeleteFolderIfNeeded(string path)
        {
            bool result = false;
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path);
                }
                catch 
                {
                    /*TODO: You must process this exception.*/
                    result = true;
                }
            }
            return result;
        }
        private bool CreateFolderIfNeeded(string path)
        {
            bool result = true;
            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }
        public TS_BEClienteCreditoOutput OBTENER_CLIENTE_CREDITO_COORPORATIVO_WS(string xCod)
        {
            TS_BEClienteCreditoOutput cSaldosCorp = new TS_BEClienteCreditoOutput() { Mensaje = new TS_BEMensaje("",false)};
            try
            {
                _clientSaldos = new Service1SoapClient(Helpers.ServicioSoapBinding(), new EndpointAddress(stringWSSaldo));
                var saldosws = _clientSaldos.Saldos_Consultar(xCod);
                if (saldosws.Rows.Count <= 0)
                {
                    cSaldosCorp.Mensaje.Ok = false;
                    cSaldosCorp.Mensaje.mensaje = "Tarjeta de cliente corporativo no configurada";
                    return cSaldosCorp;
                }
                foreach (DataRow row in saldosws.Rows)
                {
                    cSaldosCorp.Mensaje.Ok = true;
                    cSaldosCorp.Mensaje.mensaje = "";
                    cSaldosCorp.cdcliente = row["cdcliente"] == DBNull.Value ? null : row["cdcliente"].ToString();
                    cSaldosCorp.nrotarjeta = row["nrotarjeta"] == DBNull.Value ? null : row["nrotarjeta"].ToString();
                    cSaldosCorp.cdgrupo02 = row["cdgrupo02"] == DBNull.Value ? null : row["cdgrupo02"].ToString();
                    cSaldosCorp.cdarticulo = row["cdarticulo"] == DBNull.Value ? null : row["cdarticulo"].ToString();
                    cSaldosCorp.limitemto = row["limitemto"] == DBNull.Value ? (Decimal)0 : Convert.ToDecimal(row["limitemto"]);
                    cSaldosCorp.consumto = row["consumto"] == DBNull.Value ? (Decimal)0 : Convert.ToDecimal(row["consumto"]);
                    cSaldosCorp.nrobonus = row["nrobonus"] == DBNull.Value ? null : row["nrobonus"].ToString();
                    cSaldosCorp.nroplaca = row["nroplaca"] == DBNull.Value ? null : row["nroplaca"].ToString();
                    cSaldosCorp.flgilimit = row["flgilimit"] == DBNull.Value ? (bool)false : Convert.ToBoolean(row["flgilimit"]);
                    cSaldosCorp.flgbloquea = row["flgbloquea"] == DBNull.Value ? (bool)false : Convert.ToBoolean(row["flgbloquea"]);
                    cSaldosCorp.tpsaldo = row["tpsaldo"] == DBNull.Value ? null : row["tpsaldo"].ToString();
                    cSaldosCorp.consumtoC = row["consumto"] == DBNull.Value ? (Decimal)0 : Convert.ToDecimal(row["consumtoc"]);
                    cSaldosCorp.flgbloqueaC = row["flgbloqueaC"] == DBNull.Value ? (bool)false : Convert.ToBoolean(row["flgbloqueaC"]);
                    cSaldosCorp.limitemtoC = row["limitemtoC"] == DBNull.Value ? (Decimal)0 : Convert.ToDecimal(row["limitemtoC"]);
                    cSaldosCorp.flgilimitC = row["flgilimitC"] == DBNull.Value ? (bool)false : Convert.ToBoolean(row["flgilimitC"]);
                    cSaldosCorp.ruc = row["RUC"] == DBNull.Value ? null : row["RUC"].ToString();
                    cSaldosCorp.razonsocial = row["RazonSocial"] == DBNull.Value ? null : row["RazonSocial"].ToString();
                    cSaldosCorp.direccion = row["Direccion"] == DBNull.Value ? null : row["Direccion"].ToString();
                    cSaldosCorp.tipocli = "C";

                }
            }
            catch (Exception)
            {

                throw;
            }
            return cSaldosCorp;

        }
        public TS_BEMensaje ACTUALIZAR_SALDO_CLIENTE_CREDITO_COORPORATIVO_WS(TS_BESaldoWS saldoWS)
        {
            try
            {
                _clientSaldos = new Service1SoapClient(Helpers.ServicioSoapBinding(), new EndpointAddress(stringWSSaldo));
                var saldosws = _clientSaldos.Saldo_Corporativo_Actualizar(saldoWS.cdlocal, saldoWS.cdcliente, saldoWS.nrotarjeta, saldoWS.mtosoles, saldoWS.nroseriemaq, saldoWS.cdtipodoc, saldoWS.nrodocumento, saldoWS.mensaje);
                if (saldosws.Rows.Count <= 0)
                {
                    return new TS_BEMensaje("No se obtuvo respuesta del Servicio coorporativo" , false);
                }
                else
                {
                    foreach (DataRow row in saldosws.Rows)
                    {
                        return new TS_BEMensaje("", (row["Resultado"] == DBNull.Value ? "" : row["Resultado"].ToString()).Equals("SI"));
                    }
                    return new TS_BEMensaje("El formato de respuesta del Servicio coorporativo no corresponde al soportado por el sistema", false);
                }
            }
            catch (Exception)
            {
                return new TS_BEMensaje("Hubo un error al conectarse al Servicio coorporativo", false);
            }

        }

        public TS_BEMensaje ANULAR_DOCUMENTO_CREDITO_COORPORATIVO(TS_BEDocumento documento)
        {

            if (documento.cCabecera.cdtipodoc.Equals("99999"))
            {
                try
                {
                    _clientSaldos = new Service1SoapClient(Helpers.ServicioSoapBinding(), new EndpointAddress(stringWSSaldo));
                    var saldosws = _clientSaldos.Saldo_Corporativo_Anulacion( (documento.cCabecera.cdlocal ?? "").Trim(), (documento.cCabecera.cdcliente ?? "").Trim(), (documento.cCabecera.nrotarjeta ?? "").Trim(), documento.cCabecera.mtototal.ToString(("0. ##")), (documento.cCabecera.nroseriemaq ?? "").Trim(), (documento.cCabecera.cdtipodoc ?? "").Trim(), (documento.cCabecera.nrodocumento ?? "").Trim(), "ELIMINADO DESDE POS ANDROID " + DateTime.Now);
                    if (saldosws.Rows.Count <= 0)
                    {
                        return new TS_BEMensaje("No se obtuvo respuesta del Servicio coorporativo", false);
                    }
                    else
                    {
                        foreach (DataRow row in saldosws.Rows)
                        {
                            return new TS_BEMensaje("", (row["Resultado"] == DBNull.Value ? "" : row["Resultado"].ToString()).Equals("SI"));
                        }

                        return new TS_BEMensaje("El formato de respuesta del Servicio coorporativo no corresponde al soportado por el sistema", false);
                    }
                }
                catch 
                {
                    return new TS_BEMensaje("Hubo un error al conectarse al Servicio coorporativo", false);
                }
            }
            else
            {
                return new TS_BEMensaje("", true);
            }
        }

        public List<TS_BEArticulo> ReadAllFileDbf(string fileName,string cara)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
            string constr = @"Provider=vfpoledb;Data Source=" + Path.GetDirectoryName(fileName) + ";Collating Sequence=machine;";
            OleDbConnection con = new OleDbConnection(constr);
            try
            {
                var sql = "select * from " + Path.GetFileName(fileName) + " Where Alltrim(cdtipodoc) == '' And Alltrim(documento) == ''";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet(); ;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (String.IsNullOrEmpty((row["cara"] == DBNull.Value ? "" : row["cara"].ToString()).Trim() ?? "") == false)
                    {
                        output = new TS_BEArticulo();
                        string anhio = row["fecha"].ToString().Substring(0, 2);
                        string mes = row["fecha"].ToString().Substring(2, 2) + "/";
                        string dia = row["fecha"].ToString().Substring(4, 2) + "/";
                        output.nrogasboy = row["numero"] == DBNull.Value ? null : row["numero"].ToString();
                        output.total = Math.Round(row["soles"] == DBNull.Value ? 0 : Convert.ToDecimal(String.IsNullOrEmpty((row["soles"].ToString() ?? "").Trim()) ? "1" : row["soles"].ToString()) / 100, 2);
                        output.total_display = Math.Round(row["soles"] == DBNull.Value ? 0 : Convert.ToDecimal(String.IsNullOrEmpty((row["soles"].ToString() ?? "").Trim()) ? "1" : row["soles"].ToString()) / 100, 2);
                        output.precio = Math.Round(row["precio"] == DBNull.Value ? 0 : Convert.ToDecimal(String.IsNullOrEmpty((row["precio"].ToString() ?? "").Trim()) ? "1" : row["precio"].ToString()) / 100, 2);
                        output.cantidad = row["galones"] == DBNull.Value ? 0 : Convert.ToDecimal(String.IsNullOrEmpty((row["galones"].ToString() ?? "").Trim()) ? "1" : row["galones"].ToString()) / 1000;
                        // output.fecha = row["fecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dia + mes + anhio);
                        // output.hora = row["hora"] == DBNull.Value ? null : (row["hora"].ToString().Substring(0, 2) + ":" + row["hora"].ToString().Substring(2, 2));
                        output.manguera = row["manguera"] == DBNull.Value ? "" : row["manguera"].ToString();
                        output.cdarticulo = row["producto"] == DBNull.Value ? null : row["producto"].ToString();
                        output.cara = cara;
                        output.turno = row["turno"] == DBNull.Value ? null : row["turno"].ToString();
                        //output. = row["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(row["fecproceso"]);
                        lista.Add(output);
                    }

                }
                con.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }

            return lista;

        }
        public List<TS_BEArticulo> ReadTopOneFileDbf(string fileName, string cara)
        {
            List<TS_BEArticulo> lista = new List<TS_BEArticulo>();
            TS_BEArticulo output;
            string constr = @"Provider=vfpoledb;Data Source=" + Path.GetDirectoryName(fileName) + ";Collating Sequence=machine;";
            OleDbConnection con = new OleDbConnection(constr);
            try
            {
                var sql = "select TOP 1 * from " + Path.GetFileName(fileName) + " Where Alltrim(cdtipodoc) == '' And Alltrim(documento) == ''";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet(); ;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (String.IsNullOrEmpty((row["cara"] == DBNull.Value ? "" : row["cara"].ToString()).Trim() ?? "") == false)
                    {
                        output = new TS_BEArticulo();
                        string anhio = row["fecha"].ToString().Substring(0, 2);
                        string mes = row["fecha"].ToString().Substring(2, 2) + "/";
                        string dia = row["fecha"].ToString().Substring(4, 2) + "/";
                        output.nrogasboy = row["numero"] == DBNull.Value ? null : row["numero"].ToString();
                        output.total = Math.Round(row["soles"] == DBNull.Value ? 0 : Convert.ToDecimal(row["soles"]) / 100, 2);
                        output.total_display = Math.Round(row["soles"] == DBNull.Value ? 0 : Convert.ToDecimal(row["soles"]) / 100, 2);
                        output.precio = Math.Round(row["precio"] == DBNull.Value ? 0 : Convert.ToDecimal(row["precio"]) / 100, 2);
                        output.cantidad = row["galones"] == DBNull.Value ? 0 : Convert.ToDecimal(row["galones"]) / 1000;
                        // output.fecha = row["fecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dia + mes + anhio);
                        // output.hora = row["hora"] == DBNull.Value ? null : (row["hora"].ToString().Substring(0, 2) + ":" + row["hora"].ToString().Substring(2, 2));
                        output.manguera = row["manguera"] == DBNull.Value ? "" : row["manguera"].ToString();
                        output.cdarticulo = row["producto"] == DBNull.Value ? null : row["producto"].ToString();
                        output.cara = cara;
                        output.turno = row["turno"] == DBNull.Value ? null : row["turno"].ToString();
                        //output. = row["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(row["fecproceso"]);
                        lista.Add(output);
                    }

                }
                con.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }
            }

            return lista;

        }
        public TS_BEOpTransOutput ReadTopFileDbf(string fileName, string cant)
        {
            TS_BEOpTransOutput output = new TS_BEOpTransOutput();
            string constr = @"Provider=vfpoledb;Data Source=" + Path.GetDirectoryName(fileName) + ";Collating Sequence=machine;";
            OleDbConnection con = new OleDbConnection(constr);
            try
            {
                var sql = "select * from " + Path.GetFileName(fileName) + " Where Alltrim(cdtipodoc) == '' And Alltrim(documento) == '' ";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    if ( String.IsNullOrEmpty((row["cara"] == DBNull.Value ? "" : row["cara"].ToString()).Trim() ?? "") == false)
                    {
                        string anhio = row["fecha"].ToString().Substring(0, 2);
                        string mes = row["fecha"].ToString().Substring(2, 2) + "/";
                        string dia = row["fecha"].ToString().Substring(4, 2) + "/";
                        string fecha = dia + mes + anhio;
                        output.numero = row["numero"] == DBNull.Value ? null : row["numero"].ToString();
                        output.soles = row["soles"] == DBNull.Value ? 0 : Convert.ToDecimal(row["soles"]) / 100;
                        output.precio = row["precio"] == DBNull.Value ? 0 : Convert.ToDecimal(row["precio"]) / 100;
                        output.galones = row["galones"] == DBNull.Value ? 0 : Convert.ToDecimal(row["galones"]) / 1000;
                        //output.fecha = row["fecha"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dia + mes + anhio);
                        output.hora = row["hora"] == DBNull.Value ? null : (row["hora"].ToString().Substring(0, 2) + ":" + row["hora"].ToString().Substring(2, 2));
                        output.manguera = row["manguera"] == DBNull.Value ? null : row["manguera"].ToString();
                        output.producto = row["producto"] == DBNull.Value ? null : row["producto"].ToString();
                        output.cara = row["cara"] == DBNull.Value ? null : row["cara"].ToString();
                        output.turno = row["turno"] == DBNull.Value ? null : row["turno"].ToString();
                        output.dateproce = row["fecproceso"] == DBNull.Value ? (DateTime?)null : (DateTime?)(row["fecproceso"]);
                    }

                }
                con.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }

            }

            return output;

        }
        public bool RETORNAR_DBF_VENTA(string rutaTran,string cara, string cdtipodoc,string nrodocumento)
        {
            cara = (cara ?? "").Trim();
            rutaTran = (rutaTran ?? "").Trim();
            cdtipodoc = (cdtipodoc ?? "").Trim();
            nrodocumento = (nrodocumento ?? "").Trim();

            string Directory = Path.GetDirectoryName(rutaTran) + "\\" + "tran" + cara + ".dbf";  

            bool retorno = false;
            string constr = @"Provider=vfpoledb;Data Source=" + Directory + ";Collating Sequence=machine;";
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                try
                {
                    string updateRow = $"UPDATE " + Directory + " SET cdtipodoc='',documento='' Where Alltrim(cdtipodoc) == '" + cdtipodoc + "' And Alltrim(documento) == '" + nrodocumento + "' ";
                    OleDbCommand cmd = new OleDbCommand(updateRow, con);

                    con.Open();
                    retorno =  cmd.ExecuteNonQuery() > 0;
                    con.Close();
                }
                catch
                {
                    retorno = false;
                }
                finally
                {
                    con.Close();
                }
            }
            return retorno;
        }
        public bool ACTUALIZAR_DBF_VENTA(string rutaTran, string cara, string cdtipodoc, string nrodocumento, string gasboy)
        {
            cara = (cara ?? "").Trim();
            rutaTran = (rutaTran ?? "").Trim();
            cdtipodoc = (cdtipodoc ?? "").Trim();
            nrodocumento = (nrodocumento ?? "").Trim();
            gasboy = (gasboy ?? "").Trim();

            string Directory = Path.GetDirectoryName(rutaTran)  + "\\" + "tran" + cara + ".dbf";

            bool retorno = false;
            string constr = @"Provider=vfpoledb;Data Source=" + Directory + ";Collating Sequence=machine;";
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                try
                {

                    string updateRow = $"UPDATE " + Directory + " SET CDTIPODOC='" + cdtipodoc + "' , DOCUMENTO = '" + nrodocumento + "' WHERE NUMERO = '" + gasboy + "'  ";
                    OleDbCommand cmd = new OleDbCommand(updateRow, con);

                    con.Open();
                    retorno = cmd.ExecuteNonQuery() > 0;
                    con.Close();
                }
                catch
                {
                    retorno = false;
                }
                finally
                {
                    con.Close();
                }
            }
            return retorno;
        }

        public bool ELIMINAR_DBF_VENTA(string rutaTran, string cara,out string respuesta)
        {
            cara = (cara ?? "").Trim();
            rutaTran = (rutaTran ?? "").Trim();
            respuesta = "";
            string Directory = Path.GetDirectoryName(rutaTran) + "\\" + "tran" + cara + ".dbf";

            bool retorno = false;
            string constr = @"Provider=vfpoledb;Data Source=" + Directory + ";Exclusive=Yes;";
            using (OleDbConnection con = new OleDbConnection(constr))
            {
                try
                {
                    OleDbCommand cmd = new OleDbCommand("EXECSCRIPT('USE "+ Directory + " EXCLUSIVE'+CHR(13)+'ZAP')", con);

                    con.Open();
                    cmd.ExecuteReader();
                    retorno = true;
                }
                catch(Exception e)
                {
                    respuesta = e.Message;
                    retorno = false;
                }
                finally
                {
                    con.Close();
                }
            }
            return retorno;
        }
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public int ReadAllFileDbfCount(string fileName)
        {
            int Transacciones = 0;
            TS_BEOpTransOutput output = new TS_BEOpTransOutput();
            string constr = @"Provider=vfpoledb;Data Source=" + Path.GetDirectoryName(fileName) + ";Collating Sequence=machine;";
            OleDbConnection con = new OleDbConnection(constr);
            try
            {
                var sql = "select * from " + Path.GetFileName(fileName) + " Where Alltrim(cdtipodoc) == '' And Alltrim(documento) == ''";
                OleDbCommand cmd = new OleDbCommand(sql, con);
                con.Open();
                DataSet ds = new DataSet(); ;
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(ds);
                Transacciones = ds.Tables[0].Rows.Count;
                con.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                }

            }

            return Transacciones;

        }
        public static bool EnviarCorreo(string CuerpoCorreo)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["ServidorSMTP"].ToString();
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["ServidorPuertoSMTP"].ToString());
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["UserCorreoEnvio"].ToString(),
                                                        ConfigurationManager.AppSettings["UserPasswordEnvio"].ToString());

                MailMessage sendMail = new MailMessage();
                sendMail.Subject = "Alerta SIGE: Error";
                sendMail.To.Add(ConfigurationManager.AppSettings["UserCorreoPara"].ToString());
                sendMail.From = new MailAddress(ConfigurationManager.AppSettings["UserCorreoEnvio"].ToString());
                sendMail.Body = CuerpoCorreo;
                sendMail.BodyEncoding = Encoding.UTF8;
                sendMail.Priority = MailPriority.Normal;
                sendMail.IsBodyHtml = true;

                smtp.Send(sendMail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Permite registrar el Error presentado
        /// </summary>
        public static void Log_Consumo(string strMensaje)
        {
            string strRutLog = ConfigurationManager.AppSettings.Get("RutaLog");
            if (Directory.Exists(strRutLog) == false)
            {
                Directory.CreateDirectory(strRutLog);
            }

            StreamWriter oStream = new StreamWriter(Path.Combine(strRutLog, "Log_" + DateTime.Now.ToString("yyyyMMdd") + ".siges"), true);
            oStream.WriteLine(DateTime.Now.ToLongTimeString().ToString() + " | " + strMensaje);
            oStream.Flush();
            oStream.Close();
        }
        public void redondea_numero(TS_BEParametro parametros, TS_BECabeceraOutPut cCabeceraOutPut)
        {
            if (Convert.ToBoolean(parametros.redondeasolescombus ?? false))
            {
                foreach (var item in cCabeceraOutPut.cDetalleOutPut)
                {
                    var lndecimal = GetSplitDecimal(item.total);
                    switch (lndecimal)
                    {
                        case "99":
                            item.total += Convert.ToDecimal(0.01);
                            break;
                        case "89":
                            item.total += Convert.ToDecimal(0.02);
                            break;
                        case "01":
                            item.total -= Convert.ToDecimal(0.01);
                            break;
                        case "49":
                            item.total += Convert.ToDecimal(0.01);
                            break;
                    }
                }
            }

            decimal Lredondea_indecopi = 0;
            if (Convert.ToBoolean(parametros.flg_round_dec_indecopi ?? false))
            {
                foreach (var item in cCabeceraOutPut.cDetalleOutPut)
                {
                    var lndecimal = GetSplitDecimal(item.total);

                    if (Convert.ToBoolean(parametros.flg_round_indecopi_1_9 ?? false))
                    {
                        Decimal indecopi = item.total - Math.Ceiling(item.total);
                        lndecimal = indecopi.ToString();
                        Decimal otro = Math.Round(item.total, 1,MidpointRounding.AwayFromZero);
                        Decimal final = item.total - otro;
                    }

                    item.redondea_indecopi = Lredondea_indecopi;
                    item.tipo = "COMBUSTIBLE";

                    if (parametros.galones_decimales == 0)
                    {
                        item.cantidad = Math.Round(item.cantidad, 3);
                        item.cantidad_orig = item.cantidad;
                    }

                    else
                    {
                        item.cantidad = Math.Round(item.cantidad, parametros.galones_decimales);
                    }

                    item.total = Math.Round(item.cantidad * item.precio, 2);
                    decimal MtoSubTot = item.total / ((100 + item.impuesto) / 100);
                    item.subtotal = Math.Round(MtoSubTot, 2);
                    item.mtoimpuesto = Math.Round(item.total - MtoSubTot, 2);
                    item.mtodscto = Math.Round( (item.precio_orig - item.precio) * item.cantidad , 2);

                }

            }
        }
        public void genera_globales(TS_BEDocumento documento)
        {
            TS_BEGlobal globales = new TS_BEGlobal();
            decimal gravada = 0;
            decimal gratuita = 0;
            decimal exonerada = 0;
            decimal inafecta = 0;
            decimal igv = 0;
            decimal descuentos = 0;
            decimal total = 0;
            decimal monto_no_afecto = 0;
            decimal roundindecopi = documento.cCabecera.redondea_indecopi;

            foreach (TS_BEArticulo producto in documento.cDetalles)
            {
                if (producto.impuesto > 0)
                {
                    if((documento.cCabecera.tipoventa ?? "").Trim().Equals("T"))
                    {
                        gratuita += producto.valorvta + producto.mtoimpuesto;
                    }
                    else
                    {
                        gravada = gravada + (((producto.total + (producto.mtodscto < 0 ? 0 : producto.mtodscto)) / (100 + producto.impuesto)) * 100);
                        igv = igv + (((producto.total + (producto.mtodscto < 0 ? 0 : producto.mtodscto)) / (100 + producto.impuesto)) * producto.impuesto);
                        descuentos += (producto.mtodscto < 0 ? 0 : producto.mtodscto);
                        total = total + producto.total;
                    }
                }
                else
                {
                    if ((documento.cCabecera.tipoventa ?? "").Trim().Equals("T"))
                    {
                        gratuita += producto.total;
                    }
                    else
                    {
                        descuentos += producto.mtodscto;
                        exonerada += producto.total + (producto.mtodscto < 0 ? 0  : producto.mtodscto );
                        total += producto.total;
                        producto.mtonoafecto = producto.total - (producto.mtodscto < 0 ? 0 : producto.mtodscto);
                        monto_no_afecto += producto.total - (producto.mtodscto < 0 ? 0 : producto.mtodscto);

                    }
                }
            }
            globales.op_gravada = Math.Round(gravada, 2);
            globales.op_gratuita = Math.Round(gratuita, 2);
            globales.op_exonerada = Math.Round(exonerada, 2);
            globales.op_inafecta = Math.Round(inafecta, 2);
            globales.monto_descuentos = Math.Round(descuentos, 2);
            globales.monto_igv = Math.Round(igv, 2);
            globales.monto_total = Math.Round(total - roundindecopi, 2) ;

            documento.cGlobal = globales;
            documento.cCabecera.mtonoafecto = monto_no_afecto;
        }


        public string GenerateTokenJwt(string Name, string Password)
        {

            var Key = new SymmetricSecurityKey(Encoding.Default.GetBytes(ConfigurationManager.AppSettings["JWT_SECRET_KEY"]));

            ClaimsIdentity Identity = new ClaimsIdentity();
            Identity.AddClaim(new Claim("NAME", Name));
            Identity.AddClaim(new Claim("PASSWORD", Password));

            var TokenHandler = new JwtSecurityTokenHandler();

            var jwtSecurityToken = TokenHandler.CreateJwtSecurityToken(
                audience: ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"],
                issuer: ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"],
                subject: Identity,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256Signature));

            return TokenHandler.WriteToken(jwtSecurityToken);
        }

        public bool VerifyToken(HttpRequestMessage request, out string name, out string token)
        {
            name = null;
            token = null;
            try
            {
                
                if (!request.Headers.TryGetValues("Authorization", out IEnumerable<string> authzHeaders) || authzHeaders.Count() > 1)
                {
                    return false;
                }

                token = authzHeaders.ElementAt(0).StartsWith("Bearer ") ? authzHeaders.ElementAt(0).Substring(7) : authzHeaders.ElementAt(0);
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;

                TokenValidationParameters validationParameters = new TokenValidationParameters()
                {
                    ValidAudience = ConfigurationManager.AppSettings["JWT_AUDIENCE_TOKEN"],
                    ValidIssuer = ConfigurationManager.AppSettings["JWT_ISSUER_TOKEN"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(ConfigurationManager.AppSettings["JWT_SECRET_KEY"])),
                };


                name = tokenHandler.ValidateToken(token, validationParameters, out securityToken).Claims.FirstOrDefault(item => item.Type.Equals("NAME"))?.Value;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
