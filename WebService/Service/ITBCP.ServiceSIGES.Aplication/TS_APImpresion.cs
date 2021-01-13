using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres.XObjetos;
using ITBCP.ServiceSIGES.Domain.Entities.Cierrres.ZObjetos;
using ITBCP.ServiceSIGES.Domain.Entities.Cliente;
using ITBCP.ServiceSIGES.Domain.Entities.Reimpresion;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using ITBCP.ServiceSIGES.Domain.Entities.Users;
using Newtonsoft.Json;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APImpresion : ITS_AIImpresion
    {
        ITS_DOTerminal ITS_DOTerminal;
        ITS_DOParametro ITS_DOParametro;
        ITS_DOCara ITS_DOCara;
        ITS_DOOpTransaction ITS_DOOpTransaction;
        ITS_AIUtilities ITS_AIUtilities;
        ITS_DOCierre ITS_DOCierre;
        ITS_DOXCierre ITS_DOXCierre;
        ITS_DOTurno ITS_DOTurno;
        ITS_DOInicioDia ITS_DOInicioDia;
        ITS_DOReimpresion ITS_DOReimpresion;
        ITS_DOZCierre ITS_DOZCierre;
        ITS_DOBackOffice ITS_DOBackOffice;
        ITS_DODeposito ITS_DODeposito;
        ITS_AICliente ITS_AICliente;

        public TS_APImpresion(ITS_DOTerminal ITS_DOTerminal, ITS_DOParametro ITS_DOParametro, ITS_DOCara ITS_DOCara, ITS_DOOpTransaction ITS_DOOpTransaction, ITS_AIUtilities ITS_AIUtilities, ITS_DOCierre ITS_DOCierre, ITS_DOTurno ITS_DOTurno, ITS_DOInicioDia ITS_DOInicioDia, ITS_DOReimpresion ITS_DOReimpresion, ITS_DOXCierre ITS_DOXCierre, ITS_DOZCierre ITS_DOZCierre, ITS_DOBackOffice ITS_DOBackOffice, ITS_DODeposito ITS_DODeposito, ITS_AICliente ITS_AICliente)
        {
            this.ITS_DOTerminal = ITS_DOTerminal;
            this.ITS_DOParametro = ITS_DOParametro;
            this.ITS_DOCara = ITS_DOCara;
            this.ITS_DOOpTransaction = ITS_DOOpTransaction;
            this.ITS_AIUtilities = ITS_AIUtilities;
            this.ITS_DOCierre = ITS_DOCierre;
            this.ITS_DOTurno = ITS_DOTurno;
            this.ITS_DOInicioDia = ITS_DOInicioDia;
            this.ITS_DOReimpresion = ITS_DOReimpresion;
            this.ITS_DOXCierre = ITS_DOXCierre;
            this.ITS_DOZCierre = ITS_DOZCierre;
            this.ITS_DOBackOffice = ITS_DOBackOffice;
            this.ITS_DODeposito = ITS_DODeposito;
            this.ITS_AICliente = ITS_AICliente;
        }
        public TS_BEMensaje OBTENER_ULTIMO_DOCUMENTO_IMPRESO(TS_BEUltimoDocumentoInput input)
        {
            if (string.IsNullOrEmpty(input.nropos) || input.nropos.Equals("?"))
            {
                return new TS_BEMensaje("El codigo del Punto de venta es obligatoria", false);
            }
            else
            {
                TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = input.nropos });
                if (String.IsNullOrEmpty(Terminal.nropos))
                {
                    return new TS_BEMensaje("El punto de venta mencionado no existe", false);
                }
                else
                {


                    input = ITS_DOReimpresion.OBTENER_DATOS_ULTIMO_DOCUMENTO(input);

                    if (input.Ok)
                    {
                        TS_BEDocumento Documento = new TS_BEDocumento();
                        Documento.cEmisor = ITS_DOReimpresion.OBTENER_EMISOR();
                        Documento.cCabecera = ITS_DOReimpresion.OBTENER_VENTA_ULTIMO_DOCUMENTO(input);
                        Documento.cDetalles = ITS_DOReimpresion.OBTENER_VENTAD_ULTIMO_DOCUMENTO(input);
                        Documento.cPagos = ITS_DOReimpresion.OBTENER_VENTAP_ULTIMO_DOCUMENTO(input);
                        Documento.cCliente = ITS_DOReimpresion.OBTENER_CLIENTE(Documento, ITS_AICliente.ObtenerClienteByCodigo(new TS_BEClienteSearch() { Codigo = Documento.cCabecera.cdcliente }));
                        Documento.cTerminal = Terminal;
                        TS_BEVendedor vVendedor = ITS_DODeposito.OBTENER_VENDEDOR(Documento.cCabecera.cdusuario);
                        if (vVendedor != null)
                        {
                            Documento.cCabecera.dsusuario = vVendedor.dsvendedor;
                        }

                        string lado = "";
                        foreach(TS_BEArticulo Detail in Documento.cDetalles)
                        {
                            if (String.IsNullOrEmpty(Detail.cara) == false)
                            {
                                if (String.IsNullOrEmpty(lado))
                                {
                                    lado += Detail.cara;
                                }
                                else
                                {
                                    lado += "," + Detail.cara; 
                                }
                            }
                        }
                        Documento.cCabecera.lado = lado;

                        TS_BETicket cTicket = new TS_BETicket();

                        switch (Documento.cCabecera.cdtipodoc)
                        {
                            case "00001":
                                cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                                break;
                            case "00003":
                                cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                                break;
                            case "99999":
                                cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA();
                                break;
                            case "99998":
                                cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_SERAFIN();
                                break;
                            default:
                                break;
                        }

                        Documento.cFormato = new TS_BEFormato(cTicket.cabecera, cTicket.pie);
                       
                        Documento.cCabecera.numero_texto = ITS_AIUtilities.ToCardinal(Convert.ToDecimal(Documento.cCabecera.mtototal));
                        ITS_AIUtilities.genera_globales(Documento);
                        try
                        {
                            

                            string impresora = Documento.cCabecera.cdtipodoc.Equals("00001") ? Terminal.facturaimpre :
                                               Documento.cCabecera.cdtipodoc.Equals("00003") ? Terminal.boletaimpre :
                                               Documento.cCabecera.cdtipodoc.Equals("00007") ? Terminal.ncreditoimpre :
                                               Documento.cCabecera.cdtipodoc.Equals("00008") ? Terminal.ndebitoimpre :
                                               Documento.cCabecera.cdtipodoc.Equals("99998") ? Terminal.ticketimpre :
                                               Documento.cCabecera.cdtipodoc.Equals("99999") ? Terminal.ticketimpre :
                                               Terminal.ticketimpre;
                            string formato =   Documento.cCabecera.cdtipodoc.Equals("00001") ? Terminal.facturafmt :
                                               Documento.cCabecera.cdtipodoc.Equals("00003") ? Terminal.boletafmt :
                                               Documento.cCabecera.cdtipodoc.Equals("00007") ? Terminal.ncreditofmt :
                                               Documento.cCabecera.cdtipodoc.Equals("00008") ? Terminal.ndebitofmt :
                                               Documento.cCabecera.cdtipodoc.Equals("99998") ? Terminal.serafinfmt :
                                               Documento.cCabecera.cdtipodoc.Equals("99999") ? Terminal.nventafmt :
                                               "";
                            string nombre =   (Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("01") ? "F" :
                                               Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("03") ? "B" :
                                               Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("99") ? "ND" :
                                               Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("98") ? "SE" :
                                               "0") +
                                               Documento.cCabecera.nrodocumento.Substring(0, 3) + "-" +
                                              (Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("01") ? "0" :
                                               Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("03") ? "0" :
                                               "") +
                                               Documento.cCabecera.nrodocumento.Substring(3);

                            var json = JsonConvert.SerializeObject(Documento);

                            string url = $@"{Terminal.rutaservicio}/api/print?formato={HttpUtility.UrlEncode(formato)}&impresora={HttpUtility.UrlEncode(impresora)}&type=";

                            WebRequest request = WebRequest.Create(url);
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

                            return new TS_BEMensaje(responseFromServer, responseFromServer.Equals("OK"));

                        }
                        catch (Exception ex)
                        {
                            return new TS_BEMensaje(ex.InnerException.Message, false);
                        }
                    }
                    else
                    {
                        return new TS_BEMensaje(input.Mensaje, input.Ok);
                    }

                }

            }

        }
        public TS_BEReimpresionLOutput OBTENER_DOCUMENTO_IMPRESO_VENTAG(TS_BEVentagInput input)
        {
            if (String.IsNullOrEmpty(input.nropos))
            {
                return new TS_BEReimpresionLOutput(new TS_BEMensaje("Es obligatorio el punto de venta", false));
            }
            if (String.IsNullOrEmpty((ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = input.nropos })).nropos))
            {
                return new TS_BEReimpresionLOutput(new TS_BEMensaje("El punto de venta especificado no existe", false));
            }
            if (string.IsNullOrEmpty(input.nrodocumento) || input.nrodocumento.Length != 10)
            {
                return new TS_BEReimpresionLOutput() { Mensaje = new TS_BEMensaje("El numero de digitos de documento debe ser 10", false) };
            }
            if (string.IsNullOrEmpty(input.cdtipodoc) || input.cdtipodoc.Length != 5)
            {
                return new TS_BEReimpresionLOutput() { Mensaje = new TS_BEMensaje("El numero de digitos del tipo de documento de ser 5", false) };
            }
            else
            {
                return ITS_DOReimpresion.OBTENER_VENTAG(input);
            }

        }
        public TS_BEMensaje OBTENER_DOCUMENTO_IMPRESO(TS_BEDocumentoInput input)
        {

            if (string.IsNullOrEmpty(input.nrodocumento) || input.nrodocumento.Length != 10)
            {
                return new TS_BEMensaje("El numero de digitos de documento debe ser 10", false);
            }
            if (string.IsNullOrEmpty(input.cdtipodoc) || input.cdtipodoc.Length != 5)
            {
                return new TS_BEMensaje("El numero de digitos del tipo de documento de ser 5", false);
            }
            if (string.IsNullOrEmpty(input.fecha) || input.fecha.Length != 6)
            {
                return new TS_BEMensaje("Formato de fecha incorrecto", false);
            }
            else
            {
                TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = input.nropos });
                if (String.IsNullOrEmpty(Terminal.nropos))
                {
                    return new TS_BEMensaje("El punto de venta no existe", false);
                }
                TS_BEDocumento Documento = new TS_BEDocumento();
                Documento.cEmisor = ITS_DOReimpresion.OBTENER_EMISOR();
                Documento.cCabecera = ITS_DOReimpresion.OBTENER_VENTA_CABECERA(input);
                Documento.cDetalles = ITS_DOReimpresion.OBTENER_VENTA_DETALLE(input);
                Documento.cPagos = ITS_DOReimpresion.OBTENER_VENTA_PAGO(input);
                Documento.cCliente = ITS_DOReimpresion.OBTENER_CLIENTE(Documento, ITS_AICliente.ObtenerClienteByCodigo(new TS_BEClienteSearch() { Codigo = Documento.cCabecera.cdcliente }));
                Documento.cCabecera.numero_texto = ITS_AIUtilities.ToCardinal(Convert.ToDecimal(Documento.cCabecera.mtototal));
                Documento.cTerminal = Terminal;
                TS_BEVendedor vVendedor = ITS_DODeposito.OBTENER_VENDEDOR(Documento.cCabecera.cdusuario);
                if (vVendedor != null)
                {
                    Documento.cCabecera.dsusuario = vVendedor.dsvendedor;
                }

                string lado = "";
                foreach (TS_BEArticulo Detail in Documento.cDetalles)
                {
                    if (String.IsNullOrEmpty(Detail.cara) == false)
                    {
                        if (String.IsNullOrEmpty(lado))
                        {
                            lado += Detail.cara;
                        }
                        else
                        {
                            lado += "," + Detail.cara;
                        }
                    }
                }
                Documento.cCabecera.lado = lado;

                TS_BETicket cTicket = new TS_BETicket();

                switch (Documento.cCabecera.cdtipodoc)
                {
                    case "00001":
                        cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                        break;
                    case "00003":
                        cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                        break;
                    case "99999":
                        cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_NOTA_VENTA();
                        break;
                    case "99998":
                        cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_SERAFIN();
                        break;
                    default:
                        cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                        break;
                }

                Documento.cFormato = new TS_BEFormato(cTicket.cabecera, cTicket.pie);
                ITS_AIUtilities.genera_globales(Documento);
                try
                {
                    string impresora = Documento.cCabecera.cdtipodoc.Equals("00001") ? Terminal.facturaimpre :
                                              Documento.cCabecera.cdtipodoc.Equals("00003") ? Terminal.boletaimpre :
                                              Documento.cCabecera.cdtipodoc.Equals("00007") ? Terminal.ncreditoimpre :
                                              Documento.cCabecera.cdtipodoc.Equals("00008") ? Terminal.ndebitoimpre :
                                              Documento.cCabecera.cdtipodoc.Equals("99998") ? Terminal.ticketimpre :
                                              Documento.cCabecera.cdtipodoc.Equals("99999") ? Terminal.ticketimpre :
                                              Terminal.ticketimpre;

                    string formato = Documento.cCabecera.cdtipodoc.Equals("00001") ? Terminal.facturafmt :
                                              Documento.cCabecera.cdtipodoc.Equals("00003") ? Terminal.boletafmt :
                                              Documento.cCabecera.cdtipodoc.Equals("00007") ? Terminal.ncreditofmt :
                                              Documento.cCabecera.cdtipodoc.Equals("00008") ? Terminal.ndebitofmt :
                                              Documento.cCabecera.cdtipodoc.Equals("99998") ? Terminal.serafinfmt :
                                              Documento.cCabecera.cdtipodoc.Equals("99999") ? Terminal.nventafmt :
                                              "";
                    string nombre = (Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("01") ? "F" :
                                    Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("03") ? "B" :
                                    Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("99") ? "ND" :
                                    Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("98") ? "SE" :
                                    "0") +
                                    Documento.cCabecera.nrodocumento.Substring(0,3)+ "-" +
                                   (Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("01") ? "0" :
                                    Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("03") ? "0" :
                                    "") + 
                                    Documento.cCabecera.nrodocumento.Substring(3); 

                    var json = JsonConvert.SerializeObject(Documento);

                    string url = $@"{Terminal.rutaservicio}/api/print?formato={HttpUtility.UrlEncode(formato)}&impresora={HttpUtility.UrlEncode(impresora)}&type=";

                    WebRequest request = WebRequest.Create(url);
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

                    return new TS_BEMensaje(responseFromServer, responseFromServer.Equals("OK"));
                }
                catch (Exception ex)
                {
                    return new TS_BEMensaje(ex.InnerException.Message, false);
                }
            }


        }
        public TS_BEMensaje OBTENER_CAMBIO_TURNO(bool Enviar, bool OmitirBloqueoPlaya)
        {
            List<TS_BETerminal> Terminales = ITS_DOTerminal.LISTAR_TERMINALES(null);
            TS_BEParameters Tab00S0 = ITS_DOParametro.ObtenerParameters();
            TS_BEParametro Parametros = ITS_DOParametro.ObtenerParametros();
            TS_BEMensaje Respuesta = OBTENER_VENTAS_PENDIENTES_POR_TERMINALES(Terminales, Tab00S0, Parametros, OmitirBloqueoPlaya);

            if (Enviar)
            {
                if (Respuesta.Ok)
                {
                    if (Convert.ToBoolean(Parametros.conexiondispensador))
                    {
                        if (Parametros.tipocontrol.Trim().Equals("SYSCON"))
                        {
                            if (Parametros.tipocontrol.Trim().Equals("SYSCON") && Convert.ToBoolean(Parametros.activasawa) == true)
                            {
                                if (ITS_DOTurno.INICIAR_CAMBIO_TURNO_SYSCON())
                                {
                                    int Tiempo = 0;
                                    bool Estado = false;
                                    do
                                    {
                                        Estado = ITS_DOTurno.VERIFICAR_CAMBIO_TURNO_SISCON();
                                        if (Estado)
                                        {
                                            Tiempo = 1000;
                                        }
                                        Tiempo++;
                                        Thread.Sleep(1000);
                                    } while (Tiempo <= 60);
                                    if (Estado)
                                    {
                                        if (ITS_DOTurno.TERMINAR_CAMBIO_TURNO_SISCON())
                                        {
                                            return new TS_BEMensaje("Se ha realizado correctamente el cambio de turno", true);
                                        }
                                        else
                                        {
                                            if (ITS_DOTurno.DESHACER_CAMBIO_TURNO_SISCON())
                                            {
                                                return new TS_BEMensaje("Se ha producido un error al editar los parametros del sistema que impiden terminar el cambio de turno", false);
                                            }
                                            else
                                            {
                                                return new TS_BEMensaje("No se pudo deshacer los cambio de la solicitud del cambio de turno", false);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (ITS_DOTurno.DESHACER_CAMBIO_TURNO_SISCON())
                                        {
                                            return new TS_BEMensaje("Se agoto el tiempo de espera de " + (Tiempo - 1) + " sg, debido a que la interfaz no ha respondido", false);
                                        }
                                        else
                                        {
                                            return new TS_BEMensaje("Se agoto el tiempo de espera de " + (Tiempo - 1) + " sg, no se logro revertir los cambios ", false);
                                        }

                                    }
                                }
                                else
                                {
                                    return new TS_BEMensaje("No se pudo iniciar el cambio de turno debido a un error al modificar los parametros de la interfaz", false);
                                }

                            }
                            else
                            {
                                return new TS_BEMensaje("Los parametros para cambio de turno en SYSCON no coinciden con los establecidos, TIPOCONTROL = SYSCON  y ActivaSawa = T", false);
                            }
                        }
                        if (Parametros.tipocontrol.Trim().Equals("PEC"))
                        {
                            if (Parametros.tipocontrol.Trim().Equals("PEC") && Convert.ToBoolean(Parametros.activasawa) == false)
                            {


                                if (ITS_DOTurno.INICIAR_CAMBIO_TURNO_PEC())
                                {
                                    if (ITS_DOTurno.BLOQUEAR_DESBLOQUEAR_PLAYA_PEC(true))
                                    {
                                        int Tiempo = 0;
                                        bool Estado = false;
                                        do
                                        {
                                            Estado = ITS_DOTurno.VERIFICAR_CAMBIO_TURNO_PEC();
                                            if (Estado)
                                            {
                                                Tiempo = 100;
                                            }
                                            Tiempo++;
                                            Thread.Sleep(1000);
                                        } while (Tiempo <= 60);

                                        if (Estado)
                                        {
                                            if (ITS_DOTurno.TERMINAR_CAMBIO_TURNO_PEC())
                                            {
                                                ITS_DOTurno.BLOQUEAR_DESBLOQUEAR_PLAYA_PEC(false);
                                                return new TS_BEMensaje("Se realizo correctamente el cambio de turno", true);
                                            }
                                            else
                                            {
                                                if (ITS_DOTurno.BLOQUEAR_DESBLOQUEAR_PLAYA_PEC(false))
                                                {
                                                    return new TS_BEMensaje("Se ha producido un error al editar los parametros del sistema que impiden terminar el cambio de turno", false);
                                                }
                                                else
                                                {
                                                    return new TS_BEMensaje("Se ha producido un error al editar los parametros del sistema y no se pudo terminar correctamente el bloqueo de la venta en playa", false);
                                                }
                                            }

                                        }
                                        else
                                        {
                                            ITS_DOTurno.DESHACER_CAMBIO_TURNO_PEC();
                                            ITS_DOTurno.BLOQUEAR_DESBLOQUEAR_PLAYA_PEC(false);
                                            return new TS_BEMensaje("Se agoto el tiempo de espera de " + (Tiempo - 1) + " sg y no se obtuvo respuesta del controlador", false);
                                        }
                                    }
                                    else
                                    {
                                        ITS_DOTurno.BLOQUEAR_DESBLOQUEAR_PLAYA_PEC(false);
                                        return new TS_BEMensaje("Se ha producido un error al editar los parametros del sistema y se detuvo inesperadamente el cambio de turno", false);
                                    }

                                }
                                else
                                {
                                    return new TS_BEMensaje("No se pudo iniciar el cambio de turno", false);
                                }
                            }
                            else
                            {
                                return new TS_BEMensaje("Los parametros para cambio de turno en PEC no coinciden con los establecidos, TIPOCONTROL = PEC  y ActivaSawa = F", false);
                            }
                        }
                        if (Parametros.tipocontrol.Trim().Equals("CEM"))
                        {
                            if(Parametros.activasawa ?? false)
                            {
                                return new TS_BEMensaje("El controlador CEM con OP_TRAN No esta soportado en esta version", false);
                            }
                            else
                            {
                                try
                                {
                                    string InitFile = AppDomain.CurrentDomain.BaseDirectory + "assets\\resources\\CloseShift.do";
                                    string FinalFifle = (Tab00S0.path_loteria ?? "").Trim() + "CloseShift.do";
                                    File.Copy(InitFile, FinalFifle,true);

                                    foreach (TS_BETerminal Terminal in Terminales)
                                    {

                                        if (Convert.ToBoolean(Terminal.conexion_dispensador ?? 1))
                                        {
                                            List<TS_BECara> Caras = ITS_DOCara.LISTAR_CARA_POR_POSICION(new TS_BECara() { nropos = Terminal.nropos });

                                            foreach (TS_BECara caraActual in Caras)
                                            {
                                                var cAlias = (Tab00S0.path_gasboy ?? "").Trim() + "tran" + caraActual.cara + ".DBF";

                                                if (!File.Exists(cAlias))
                                                {
                                                    return new TS_BEMensaje(" La tabla " + cAlias + " no Existe", false);
                                                }
                                                if (!ITS_AIUtilities.ELIMINAR_DBF_VENTA((Tab00S0.path_gasboy ?? "").Trim(), caraActual.cara, out string respuesta))
                                                {
                                                    return new TS_BEMensaje(respuesta + " "+ caraActual.cara, false);
                                                }

                                            }

                                        }
                                    }

                                    if (ITS_DOTurno.PROCESAR_CAMBIO_TURNO_SIN_CONTROLADOR())
                                    {
                                        return new TS_BEMensaje("Se proceso correctamente el cambio de turno", true);
                                    }
                                    else
                                    {
                                        return new TS_BEMensaje("Hubo un problema al intentar terminar el cambio de turno", false);
                                    }
                                }
                                catch(IOException ex)
                                {
                                    return new TS_BEMensaje("No se pudo copiar el archivo necesario para cambiar el turno \n" + ex.Message, false);
                                }
                                catch(Exception ex)
                                {
                                    return new TS_BEMensaje("No se pudo copiar el archivo necesario para cambiar el turno \n" + ex.Message, false);
                                }
                              
                            }
                        }
                        else
                        {
                            return new TS_BEMensaje("Debido a la conexión con el dispensador la configuración de la interfaz actual no es reconocidad por el sistema para realizar el proceso del turno respectivo", true);
                        }
                    }
                    else
                    {
                        if (ITS_DOTurno.PROCESAR_CAMBIO_TURNO_SIN_CONTROLADOR())
                        {
                            return new TS_BEMensaje("Se proceso correctamente el cambio de turno", true);
                        }
                        else
                        {
                            return new TS_BEMensaje("Hubo un problema al intentar terminar el cambio de turno", false);
                        }
                    }
                }
                else
                {
                    return Respuesta;
                }
            }
            else
            {
                return new TS_BEMensaje("Para cambiar el turno el valor de envio debe ser = true", false);
            }

        }
        public TS_BERespuesta OBTENER_CIERRE_X(TS_BEXCierreInput input)
        {
            TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = input.nropos });

            if (String.IsNullOrEmpty(Terminal.nropos))
            {
                return new TS_BERespuesta() { respuesta = "No se encontro el punto de venta: ", ok = false, base64encodepdf = "" };
            }

            TS_BECierre ParametrosCierreX = ITS_DOCierre.OBTENER_CIERRE(new TS_BECierre() { cdcierre = "X" });

            if (String.IsNullOrEmpty(ParametrosCierreX.cdcierre))
            {
                return new TS_BERespuesta() { respuesta = "No se cargaron los parametros del Cierre X", ok = false, base64encodepdf = "" };
            }

            TS_BEParameters Tab00S0 = ITS_DOParametro.ObtenerParameters();
            TS_BEParametro Parametros = ITS_DOParametro.ObtenerParametros();
            TS_BEMensaje Respuesta = OBTENER_VENTAS_PENDIENTES_POR_TERMINAL(Terminal, Tab00S0, Parametros, Convert.ToBoolean(input.ignorar_bloqueo_playa));

            if (Respuesta.Ok)
            {
                
                TS_BEXCierre cCierreX = new TS_BEXCierre
                {
                    cCabecera = ITS_DOXCierre.OBTENER_CABECERA_CIERRE_X(Parametros, Terminal),
                    cVentasPorDocumentos = ITS_DOXCierre.OBTENER_VENTAS_POR_DOCUMENTO(Parametros, Terminal),
                    cVentasPorTipoPago = ITS_DOXCierre.OBTENER_TIPOS_PAGO(Parametros, Terminal),
                    cParametros = ParametrosCierreX
                };

                cCierreX.cCabecera.usuario = input.usuario == null ? "" : input.usuario;

                if (ParametrosCierreX.flggrupo01)
                {
                    cCierreX.cGrupo01 = ITS_DOXCierre.OBTENER_GRUPO(Parametros, Terminal, "G1");// flggrupo01 true
                    if (cCierreX.cGrupo01.Count == 0) { cCierreX.cParametros.flggrupo01 = false; }
                }
                if (ParametrosCierreX.flggrupo02)
                {
                    cCierreX.cGrupo02 = ITS_DOXCierre.OBTENER_GRUPO(Parametros, Terminal, "G2");// flggrupo02 true
                    if (cCierreX.cGrupo02.Count == 0) { cCierreX.cParametros.flggrupo02 = false; }
                }
                if (ParametrosCierreX.flggrupo03)
                {
                    cCierreX.cGrupo03 = ITS_DOXCierre.OBTENER_GRUPO(Parametros, Terminal, "G3");// flggrupo03 true
                    if (cCierreX.cGrupo03.Count == 0) { cCierreX.cParametros.flggrupo03 = false; }
                }
                if (ParametrosCierreX.flggrupo04)
                {
                    cCierreX.cGrupo04 = ITS_DOXCierre.OBTENER_GRUPO(Parametros, Terminal, "G4");// flggrupo04 true
                    if (cCierreX.cGrupo04.Count == 0) { cCierreX.cParametros.flggrupo04 = false; }
                }
                if (ParametrosCierreX.flggrupo05)
                {
                    cCierreX.cGrupo05 = ITS_DOXCierre.OBTENER_GRUPO(Parametros, Terminal, "G5");// flggrupo05 true
                    if (cCierreX.cGrupo05.Count == 0) { cCierreX.cParametros.flggrupo05 = false; }
                }
                if (ParametrosCierreX.flgvendedor)//flgvendedor true 
                {
                    cCierreX.cVentasPorVendedor = ITS_DOXCierre.OBTENER_VENTAS_USUARIO_VENDEDOR(Parametros, Terminal, "VV");
                    if (cCierreX.cVentasPorVendedor.Count == 0) { cCierreX.cParametros.flgvendedor = false; }
                    else if (cCierreX.cVentasPorVendedor.Count > 0)
                    {
                        TS_BEVendedores cVendedores = ITS_DODeposito.OBTENER_VENDEDORES();
                        foreach (TS_BEVendedor cVendedor in cVendedores.cVendedores)
                        {
                            foreach (TS_BEXVendedor vVendedor in cCierreX.cVentasPorVendedor)
                            {
                                if ((vVendedor.nombre ?? "").Trim().Equals((cVendedor.cdusuario ?? "").Trim()))
                                {
                                    vVendedor.nombre = cVendedor.dsvendedor;
                                }
                            }
                        }
                    }
                }
                if (ParametrosCierreX.flgarticulo || ParametrosCierreX.flgarticulodesc)
                {
                    cCierreX.cVentasPorProducto = ITS_DOXCierre.OBTENER_VENTAS_POR_PRODUCTO(Parametros, Terminal);
                    if (cCierreX.cVentasPorProducto.Count == 0) { cCierreX.cParametros.flgarticulo = false; cCierreX.cParametros.flgarticulodesc = false; }
                }
                if (ParametrosCierreX.flgcara || ParametrosCierreX.flgdesc)
                {
                    cCierreX.cVentasPorCara = ITS_DOXCierre.OBTENER_VENTAS_POR_CARA(Parametros, Terminal);
                    if (cCierreX.cVentasPorCara.Count == 0) { cCierreX.cParametros.flgcara = false; cCierreX.cParametros.flgdesc = false; }
                }
                if (ParametrosCierreX.flgusuario)
                {
                    cCierreX.cVentasPorUsuario = ITS_DOXCierre.OBTENER_VENTAS_USUARIO_VENDEDOR(Parametros, Terminal, "VU");
                    if (cCierreX.cVentasPorUsuario.Count == 0) { cCierreX.cParametros.flgusuario = false;}
                    else if(cCierreX.cVentasPorUsuario.Count > 0)
                    {
                        List<TS_BEUsers> cUsuarios = ITS_DODeposito.OBTENER_USUARIOS_TODOS();
                        foreach(TS_BEUsers cUsuario in cUsuarios)
                        {
                            foreach(TS_BEXVendedor vUsuario in cCierreX.cVentasPorUsuario)
                            {
                                if (vUsuario.nombre.Equals(cUsuario.cdusuario))
                                {
                                    vUsuario.nombre = cUsuario.dsusuario;
                                }
                            }
                        }
                    }
                }
                if (ParametrosCierreX.flgdepositogrifero)
                {
                    cCierreX.cDepositos = ITS_DOXCierre.OBTENER_DEPOSITOS(cCierreX, Parametros, Terminal);
                    if (cCierreX.cDepositos.Count == 0) { cCierreX.cParametros.flgdepositogrifero = false; }
                    else if(cCierreX.cDepositos.Count > 0)
                    {
                        TS_BEVendedores cVendedores = ITS_DODeposito.OBTENER_VENDEDORES();
                        foreach (TS_BEVendedor cVendedor in cVendedores.cVendedores)
                        {
                            foreach (TS_BEXDepositosVendedor vDeposito in cCierreX.cDepositos)
                            {
                                if ((vDeposito.nombre ?? "").Trim().Equals((cVendedor.cdusuario ?? "").Trim()))
                                {
                                    vDeposito.nombre = cVendedor.dsvendedor;
                                }
                            }
                        }
                    }
                }
                if (ParametrosCierreX.flgconsolidarlados)
                {
                    cCierreX.cTotales = ITS_DOXCierre.OBTENER_TOTALIZADOS(Parametros, Terminal);
                }
                if (ParametrosCierreX.flgcanjearticulo)
                {
                    cCierreX.cTotalCanjes = ITS_DOXCierre.OBTENER_TOTAL_CANJES(Parametros, Terminal);
                }
                if (ParametrosCierreX.flgstcknegativo)
                {
                    cCierreX.cStockNegativos = ITS_DOXCierre.OBTENER_ARTICULOS_VENDIDOS_STOCK_NEGATIVO(Parametros, Terminal);
                    if (cCierreX.cStockNegativos.Count == 0) { cCierreX.cParametros.flgstcknegativo = false; }
                }

                

                try
                {

                    TS_BETicket cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                    cCierreX.cFormato = new TS_BEFormato(cTicket.cabecera, cTicket.pie);

                    var json = JsonConvert.SerializeObject(cCierreX);
                    if (input.imprimir)
                    {
                        string impresora = Terminal.ticketimpre;
                        string formato   = Terminal.cierrexfmt;
                        string nombre    = "CX "+ DateTime.Now.ToString("yyyyMMdd") + " T" + Terminal.turno;
                        string url = $@"{Terminal.rutaservicio}/api/print?formato={HttpUtility.UrlEncode(formato)}&impresora={HttpUtility.UrlEncode(impresora)}&type=";

                        WebRequest request = WebRequest.Create(url);
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
                        return new TS_BERespuesta() { respuesta = responseFromServer, ok = (responseFromServer ?? "").Equals("OK") , base64encodepdf ="" };
                    }
                    else
                    {
                        string formato = Terminal.cierrexfmt;
                        string url = $@"{Terminal.rutaservicio}/api/print?formato={HttpUtility.UrlEncode(formato)}&impresora=&type=PDF";

                        WebRequest request = WebRequest.Create(url);
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
                        TS_BERespuesta reponse = JsonConvert.DeserializeObject<TS_BERespuesta>(responseFromServer);
                        return reponse;
                    }
                }
                catch (Exception ex)
                {
                    return new TS_BERespuesta() { respuesta = ex.InnerException.Message, ok= false , base64encodepdf="" };
                }

            }
            else
            {
                return new TS_BERespuesta() { respuesta = Respuesta.mensaje, ok = Respuesta.Ok, base64encodepdf = "" };
            }
        }
        public TS_BERespuesta OBTENER_CIERRE_Z(TS_BEZCierreInput input)
        {
            TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = input.nropos });

            if (String.IsNullOrEmpty(Terminal.nropos))
            {
                return new TS_BERespuesta() { respuesta = "No se encontro el punto de venta: ", ok = false, base64encodepdf = "" };
            }

            TS_BECierre ParametrosCierreZ = ITS_DOCierre.OBTENER_CIERRE(new TS_BECierre() { cdcierre = "Z" });
            if (String.IsNullOrEmpty(ParametrosCierreZ.cdcierre))
            {
                return new TS_BERespuesta() { respuesta = "No se cargaron los parametros del Cierre Z", ok = false, base64encodepdf = "" };
            }

            TS_BEParameters Tab00S0 = ITS_DOParametro.ObtenerParameters();
            TS_BEParametro Parametros = ITS_DOParametro.ObtenerParametros();
            TS_BEMensaje Respuesta = this.OBTENER_VENTAS_PENDIENTES_POR_TERMINAL(Terminal, Tab00S0, Parametros, Convert.ToBoolean(input.ignorar_bloqueo_playa));

            if (Respuesta.Ok)
            {
                TS_BEZCierre cCierreZ = new TS_BEZCierre()
                {
                    cCabecera = ITS_DOZCierre.OBTENER_CABECERA_CIERRE_Z(Parametros, Terminal),
                    cVentasPorDocumentos = ITS_DOZCierre.OBTENER_VENTAS_POR_DOCUMENTO(Parametros, Terminal),
                    cVentasPorTipoPago = ITS_DOZCierre.OBTENER_TIPOS_PAGO(Parametros, Terminal),
                    cParametros = ParametrosCierreZ
                };
                cCierreZ.cCabecera.usuario = input.usuario == null ? "" : input.usuario;

                if (ParametrosCierreZ.flggrupo01)
                {
                    cCierreZ.cGrupo01 = ITS_DOZCierre.OBTENER_GRUPO(Parametros, Terminal, "G1");// flggrupo01 true
                    if (cCierreZ.cGrupo01.Count == 0) { cCierreZ.cParametros.flggrupo01 = false; }
                }
                if (ParametrosCierreZ.flggrupo02)
                {
                    cCierreZ.cGrupo02 = ITS_DOZCierre.OBTENER_GRUPO(Parametros, Terminal, "G2");// flggrupo02 true
                    if (cCierreZ.cGrupo02.Count == 0) { cCierreZ.cParametros.flggrupo02 = false; }
                }
                if (ParametrosCierreZ.flggrupo03)
                {
                    cCierreZ.cGrupo03 = ITS_DOZCierre.OBTENER_GRUPO(Parametros, Terminal, "G3");// flggrupo03 true
                    if (cCierreZ.cGrupo03.Count == 0) { cCierreZ.cParametros.flggrupo03 = false; }
                }
                if (ParametrosCierreZ.flggrupo04)
                {
                    cCierreZ.cGrupo04 = ITS_DOZCierre.OBTENER_GRUPO(Parametros, Terminal, "G4");// flggrupo04 true
                    if (cCierreZ.cGrupo04.Count == 0) { cCierreZ.cParametros.flggrupo04 = false; }
                }
                if (ParametrosCierreZ.flggrupo05)
                {
                    cCierreZ.cGrupo05 = ITS_DOZCierre.OBTENER_GRUPO(Parametros, Terminal, "G5");// flggrupo05 true
                    if (cCierreZ.cGrupo05.Count == 0) { cCierreZ.cParametros.flggrupo05 = false; }
                }
                if (ParametrosCierreZ.flgvendedor)//flgvendedor true 
                {
                    cCierreZ.cVentasPorVendedor = ITS_DOZCierre.OBTENER_VENTAS_USUARIO_VENDEDOR(Parametros, Terminal, "VV");
                    if (cCierreZ.cVentasPorVendedor.Count == 0) { cCierreZ.cParametros.flgvendedor = false; }
                    else if (cCierreZ.cVentasPorVendedor.Count > 0)
                    {
                        TS_BEVendedores cVendedores = ITS_DODeposito.OBTENER_VENDEDORES();
                        foreach (TS_BEVendedor cVendedor in cVendedores.cVendedores)
                        {
                            foreach (TS_BEZVendedor vVendedor in cCierreZ.cVentasPorVendedor)
                            {
                                if ((vVendedor.nombre ?? "").Trim().Equals((cVendedor.cdusuario ?? "").Trim()))
                                {
                                    vVendedor.nombre = cVendedor.dsvendedor;
                                }
                            }
                        }
                    }
                }
                if (ParametrosCierreZ.flgarticulo || ParametrosCierreZ.flgarticulodesc)
                {
                    cCierreZ.cVentasPorProducto = ITS_DOZCierre.OBTENER_VENTAS_POR_PRODUCTO(Parametros, Terminal);
                    if (cCierreZ.cVentasPorProducto.Count == 0) { cCierreZ.cParametros.flgarticulo = false; cCierreZ.cParametros.flgarticulodesc = false; }
                }
                if (ParametrosCierreZ.flgcara || ParametrosCierreZ.flgdesc)
                {
                    cCierreZ.cVentasPorCara = ITS_DOZCierre.OBTENER_VENTAS_POR_CARA(Parametros, Terminal);
                    if (cCierreZ.cVentasPorCara.Count == 0) { cCierreZ.cParametros.flgcara = false; cCierreZ.cParametros.flgdesc = false; }
                }
                if (ParametrosCierreZ.flgusuario)
                {
                    cCierreZ.cVentasPorUsuario = ITS_DOZCierre.OBTENER_VENTAS_USUARIO_VENDEDOR(Parametros, Terminal, "VU");
                    if (cCierreZ.cVentasPorUsuario.Count == 0) { cCierreZ.cParametros.flgusuario = false; }
                    else if (cCierreZ.cVentasPorUsuario.Count > 0)
                    {
                        List<TS_BEUsers> cUsuarios = ITS_DODeposito.OBTENER_USUARIOS_TODOS();
                        foreach (TS_BEUsers cUsuario in cUsuarios)
                        {
                            foreach (TS_BEZVendedor vUsuario in cCierreZ.cVentasPorUsuario)
                            {
                                if (vUsuario.nombre.Equals(cUsuario.cdusuario))
                                {
                                    vUsuario.nombre = cUsuario.dsusuario;
                                }
                            }
                        }
                    }
                }
                if (ParametrosCierreZ.flgdepositogrifero)
                {
                    cCierreZ.cDepositos = ITS_DOZCierre.OBTENER_DEPOSITOS(cCierreZ, Parametros, Terminal);
                    if (cCierreZ.cDepositos.Count == 0) { cCierreZ.cParametros.flgdepositogrifero = false; }
                    else if (cCierreZ.cDepositos.Count > 0)
                    {
                        TS_BEVendedores cVendedores = ITS_DODeposito.OBTENER_VENDEDORES();
                        foreach (TS_BEVendedor cVendedor in cVendedores.cVendedores)
                        {
                            foreach (TS_BEZDepositosVendedor vDeposito in cCierreZ.cDepositos)
                            {
                                if ((vDeposito.nombre ?? "").Trim().Equals((cVendedor.cdusuario ?? "").Trim()))
                                {
                                    vDeposito.nombre = cVendedor.dsvendedor;
                                }
                            }
                        }

                    }
                }
                if (ParametrosCierreZ.flgconsolidarlados)
                {
                    cCierreZ.cTotales = ITS_DOZCierre.OBTENER_TOTALIZADOS(Parametros, Terminal);
                }
                if (ParametrosCierreZ.flgcanjearticulo)
                {
                    cCierreZ.cTotalCanjes = ITS_DOZCierre.OBTENER_TOTAL_CANJES(Parametros, Terminal);
                }
                if (ParametrosCierreZ.flgstcknegativo)
                {
                    cCierreZ.cStockNegativos = ITS_DOZCierre.OBTENER_ARTICULOS_VENDIDOS_STOCK_NEGATIVO(Parametros, Terminal);
                    if (cCierreZ.cStockNegativos.Count == 0) { cCierreZ.cParametros.flgstcknegativo = false; }
                }

                try
                {
                    TS_BETicket cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                    cCierreZ.cFormato = new TS_BEFormato(cTicket.cabecera, cTicket.pie);
                    var json = JsonConvert.SerializeObject(cCierreZ);

                    if (input.imprimir)
                    {
                        string impresora = Terminal.ticketimpre;
                        string formato = Terminal.cierrexfmt;
                        string nombre = "CZ " + DateTime.Now.ToString("yyyyMMdd");
                        string url = $@"{Terminal.rutaservicio}/api/print?formato={HttpUtility.UrlEncode(formato)}&impresora={HttpUtility.UrlEncode(impresora)}&type=";

                        WebRequest request = WebRequest.Create(url);
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

                        return new TS_BERespuesta() { respuesta = responseFromServer, ok = (responseFromServer ?? "").Equals("OK"), base64encodepdf = "" };
                    }
                    else
                    {
                        string formato = Terminal.cierrezfmt;
                        string url = $@"{Terminal.rutaservicio}/api/print?formato={HttpUtility.UrlEncode(formato)}&impresora=&type=PDF";

                        WebRequest request = WebRequest.Create(url);
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
                        TS_BERespuesta reponse = JsonConvert.DeserializeObject<TS_BERespuesta>(responseFromServer);
                        return reponse;
                    }
                }
                catch (Exception ex)
                {
                    return new TS_BERespuesta() { respuesta = ex.InnerException.Message, ok = false, base64encodepdf = "" };
                }

            }
            else
            {
                return new TS_BERespuesta() { respuesta = Respuesta.mensaje, ok = Respuesta.Ok, base64encodepdf = "" };
            }

        }
        public TS_BEInicioDiaOutput OBTENER_INICIO_DIA(string seriehd, string cdusuario)
        {
            if ((String.IsNullOrEmpty(seriehd) || seriehd.Equals("?")) || (cdusuario.Equals("?") || String.IsNullOrEmpty(cdusuario)))
            {
                return new TS_BEInicioDiaOutput(){ Mensaje = new TS_BEMensaje("La serie HD y el codigo de usuario es obligatorio para realizar el inicio de día", false)};
            }
            else
            {
                TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_SERIEHD(new TS_BETerminal() { seriehd = seriehd });
                TS_BEParametro Parametros = ITS_DOParametro.ObtenerParametros();
                TS_BEParameters Tab00S0 = ITS_DOParametro.ObtenerParameters();
                List<TS_BETerminal> Terminales = ITS_DOTerminal.LISTAR_TERMINALES(new TS_BETerminal());
                TS_BEMensaje Respuesta = OBTENER_VENTAS_PENDIENTES_POR_TERMINALES(Terminales, Tab00S0, Parametros, false);

                if(Respuesta.Ok == false)
                {
                    return new TS_BEInicioDiaOutput() { Mensaje = Respuesta };
                }
                if (Terminal.nropos != null)
                {
                    if (ITS_DOInicioDia.EJECUTAR_INICIO_DIA(seriehd, cdusuario))
                    {
                        return new TS_BEInicioDiaOutput() { Mensaje = new TS_BEMensaje("Se realizo correctamente el inicio de día", true), vTerminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_SERIEHD(new TS_BETerminal() { seriehd = seriehd }) };
                    }
                    else
                    {
                        return new TS_BEInicioDiaOutput() { Mensaje = new TS_BEMensaje("Hubo problemas al ejecutar el inicio de día por favor intentelo más tarde", false)};
                    }
                }
                else
                {
                    return new TS_BEInicioDiaOutput() { Mensaje = new TS_BEMensaje("No se encontro el punto de venta relacionado", false) };
                }


            }
        }
        public TS_BEMensaje OBTENER_VENTAS_PENDIENTES_POR_TERMINAL(TS_BETerminal Terminal, TS_BEParameters Tab00S0, TS_BEParametro Parametros, bool ignorar_bloqueo_playa)
        {
            List<TS_BECara> Caras = ITS_DOCara.LISTAR_CARA_POR_POSICION(new TS_BECara() { nropos = Terminal.nropos });

            if (ignorar_bloqueo_playa)
            {
                return new TS_BEMensaje("OK", true);
            }
            if (string.IsNullOrEmpty(Terminal.nropos))
            {
                return new TS_BEMensaje("No se encontro el punto de venta en terminal", false);
            }
            if (Convert.ToBoolean(Parametros.conexiondispensador))
            {
                if (Convert.ToBoolean(Parametros.bloqventaplaya))
                {
                    return new TS_BEMensaje("No se pueden realizar tramites mientras se realiza un cambio de turno", false);
                }
                else
                {
                    if (Terminal.conexion_dispensador == null || Convert.ToBoolean(Terminal.conexion_dispensador) == true)
                    {
                        if (Convert.ToBoolean(Parametros.activasawa))
                        {
                            List<TS_BEArticulo> OpTransaccions = new List<TS_BEArticulo>();

                            foreach (TS_BECara caraActual in Caras)
                            {
                                OpTransaccions = ITS_DOOpTransaction.LISTAR_TRANSACTIONS(new TS_BEOp_Tran() { cara = caraActual.cara });

                                if (OpTransaccions.Count > 0)
                                {
                                    return new TS_BEMensaje("Existen ventas pendientes en la cara: " + caraActual.cara, false);
                                }
                            }
                            return new TS_BEMensaje("OK", true);
                        }
                        else
                        {
                            foreach (TS_BECara caraActual in Caras)
                            {
                                string cAlias = Tab00S0.path_gasboy.Trim() + "tran" + caraActual.cara + ".DBF";
                                if (!File.Exists(cAlias))
                                {
                                    return new TS_BEMensaje(" La Tabla " + cAlias + " No Existe", false);

                                }
                                if (ITS_AIUtilities.ReadAllFileDbfCount(cAlias) > 0)
                                {
                                    return new TS_BEMensaje("Existen transacciones pendiente en la cara: " + caraActual.cara, false);
                                }

                            }
                            return new TS_BEMensaje("OK", true);
                        }
                    }
                    else
                    {
                        return new TS_BEMensaje("OK", true);
                    }

                }
            }
            else
            {
                return new TS_BEMensaje("OK", true);
            }

        }   
        public bool OBTENER_VENTAS_PENDIENTES_POR_TERMINAL_SEMI_AUTOMATIC(string nropos)
        {
            TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = nropos });

            if (string.IsNullOrEmpty(Terminal.nropos))
            {
                return false;
            }

            List<TS_BECara> Caras = ITS_DOCara.LISTAR_CARA_POR_POSICION(new TS_BECara() { nropos = Terminal.nropos });
            TS_BEParameters Tab00S0 = ITS_DOParametro.ObtenerParameters();
            TS_BEParametro Parametros = ITS_DOParametro.ObtenerParametros();

            if (Convert.ToBoolean(Parametros.conexiondispensador))
            {
                if (Convert.ToBoolean(Parametros.bloqventaplaya))
                {
                    return false;
                }
                else
                {
                    if (Terminal.conexion_dispensador == null || Convert.ToBoolean(Terminal.conexion_dispensador) == true)
                    {
                        if (Convert.ToBoolean(Parametros.activasawa))
                        {
                            int EvaluarPendientesMayorAUno = 0;
                            foreach (TS_BECara caraActual in Caras)
                            {
                                List<TS_BEArticulo>  OpTransaccions = ITS_DOOpTransaction.LISTAR_TRANSACTIONS(new TS_BEOp_Tran() { cara = caraActual.cara });

                                if (OpTransaccions.Count > 1)
                                {
                                    EvaluarPendientesMayorAUno ++;
                                }
                            }
                            return EvaluarPendientesMayorAUno > 0;
                        }
                        else
                        {
                            int EvaluarPendientesMayorAUno = 0;
                            foreach (TS_BECara caraActual in Caras)
                            {
                                string cAlias = Tab00S0.path_gasboy.Trim() + "tran" + caraActual.cara + ".DBF";

                                if (ITS_AIUtilities.ReadAllFileDbfCount(cAlias) > 1)
                                {
                                    EvaluarPendientesMayorAUno++;
                                }

                            }
                            return EvaluarPendientesMayorAUno>0;
                        }
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            else
            {
                return false;
            }

        }
        public TS_BEMensaje OBTENER_VENTAS_PENDIENTES_POR_TERMINALES(List<TS_BETerminal> Terminales, TS_BEParameters Tab00S0, TS_BEParametro Parametros, bool ignorar_bloqueo_playa)
        {
            List<TS_BECara> Caras;

            if (ignorar_bloqueo_playa)
            {
                return new TS_BEMensaje("OK", true);
            }
            if (Parametros.bloqventaplaya == true)
            {
                return new TS_BEMensaje("Ya esta en proceso un cambio de turno por favor espere", false);
            }
            else
            {
                if (Parametros.conexiondispensador == true)
                {

                    foreach (TS_BETerminal Terminal in Terminales)
                    {

                        if (Terminal.conexion_dispensador == null || Convert.ToBoolean(Terminal.conexion_dispensador) == true)
                        {
                            if (Parametros.activasawa == true)
                            {

                                Caras = ITS_DOCara.LISTAR_CARA_POR_POSICION(new TS_BECara() { nropos = Terminal.nropos });

                                foreach (TS_BECara caraActual in Caras)
                                {

                                    List<TS_BEArticulo> Transacciones = ITS_DOOpTransaction.LISTAR_TRANSACTIONS(new TS_BEOp_Tran() { cara = caraActual.cara });
                                    if (Transacciones.Count > 0)
                                    {
                                        return new TS_BEMensaje("Existen ventas pendientes en la cara: " + caraActual.cara, false);
                                    }
                                }


                            }
                            else
                            {
                                Caras = ITS_DOCara.LISTAR_CARA_POR_POSICION(new TS_BECara() { nropos = Terminal.nropos });

                                foreach (TS_BECara caraActual in Caras)
                                {
                                    var cAlias = Tab00S0.path_gasboy.Trim() + "tran" + caraActual.cara + ".DBF";
                                    if (!File.Exists(cAlias))
                                    {
                                        return new TS_BEMensaje(" La tabla " + cAlias + " no Existe", false);
                                    }
                                    if (ITS_AIUtilities.ReadAllFileDbfCount(cAlias) > 0)
                                    {
                                        return new TS_BEMensaje("Existen transacciones pendiente en la cara: " + caraActual.cara, false);
                                    }

                                }
                            }
                        }
                    }
                    return new TS_BEMensaje("OK_TERMINALES", true);

                }
                else
                {
                    return new TS_BEMensaje("OK_PARAMETRO", true);
                }

            }

        }
        public TS_BEMensaje NOTIFICAR_IMPRESION(TS_BETerminal Terminal)
        {

            if (String.IsNullOrEmpty(Terminal.nropos))
            {
                return new TS_BEMensaje("El punto de venta mencionado no existe", false);
            }
            if (String.IsNullOrEmpty(Terminal.rutaservicio))
            {
                return new TS_BEMensaje("La ruta del servicio esta en blanco o nula", false);
            }
            try
            {
                string url = Terminal.rutaservicio + "/api/print/VerifyAllTransactions";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream)) { 
                    string respuesta = reader.ReadToEnd().ToString();
                    return new TS_BEMensaje(respuesta, respuesta.Equals("OK"));
                }
               
            }
            catch (Exception ex)
            {
                return new TS_BEMensaje(ex.ToString(), false);
            }

        }
        public TS_BEMensaje REGISTRAR_DEPOSITO(TS_BEDepositoInput input)
        {
            TS_BEVendedor Vendedor = ITS_DODeposito.OBTENER_VENDEDOR(input.cdvendedor);
            TS_BEDeposito Output = new TS_BEDeposito()
            {
                nropos         = input.nropos,
                cdvendedor     = input.cdvendedor,
                cdtppago       = input.cdtppago,
                mtosoles       = input.mtosoles,
                mtodolares     = input.mtodolares,
                nrosobres      = input.nrosobres,
                dsvendedor     = Vendedor.dsvendedor,
                turno_anterior = input.turno_anterior
            };
            if (String.IsNullOrEmpty(Output.nropos))
            {
                return new TS_BEMensaje("El numero POS es obligatorio", false);
            }

            TS_BETerminal terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = Output.nropos });

            if (String.IsNullOrEmpty(terminal.nropos))
            {
                return new TS_BEMensaje("El punto de venta no existe", false);
            }
            if (String.IsNullOrEmpty(Output.cdvendedor))
            {
                return new TS_BEMensaje("El codigo de vendedor es obligatorio", false);
            }
            if((Output.cdtppago == null ? "" : Output.cdtppago.Trim()).Length != 5)
            {
                return new TS_BEMensaje("El codigo de pago es de 5 digitos", false);
            }
            if(Output.mtodolares < 0)
            {
                return new TS_BEMensaje("El monto de pago en dolares no puede ser menor a cero", false);
            }
            if (Output.mtosoles < 0)
            {
                return new TS_BEMensaje("El monto de pago en soles no puede ser menor a cero", false);
            }
            if (Output.mtosoles == 0 && input.mtodolares == 0)
            {
                return new TS_BEMensaje("El deposito debe tener un monto de deposito en cualquier moneda", false);
            }
            if (Output.nrosobres <= 0)
            {
                return new TS_BEMensaje("Debe colocar la cantidad de sobres a depositar", false);
            }

            TS_BEMensaje Respuesta = ITS_DODeposito.REGISTRAR_DEPOSITO(Output, terminal);

            if (Respuesta.Ok)
            {
                try
                {
                    TS_BETicket cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();

                    Output.cFormato     = new TS_BEFormato(cTicket.cabecera, cTicket.pie);
                    Output.nrodocumento = Output.nrodeposito;
                    Output.nroseriemaq  = terminal.nroseriemaq ?? "N\\A";
                    Output.fecdocumento = DateTime.Now;

                    var json = JsonConvert.SerializeObject(Output);

                    string impresora = terminal.ticketimpre;
                    string formato = terminal.depositofmt;
                    string nombre = "DE " + Convert.ToString(Output.nrodeposito) + " " + DateTime.Now.ToString("yyyyMMdd");
                    string cdtipodoc = "80003";
                    string url = $@"{terminal.rutaservicio}/api/print?formato={HttpUtility.UrlEncode(formato)}&impresora={impresora}&type=&cdtipodoc={cdtipodoc}";

                    WebRequest request = WebRequest.Create(url);
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

                    return new TS_BEMensaje(responseFromServer, (responseFromServer ?? "").Equals("OK"));
                }
                catch
                {
                    return new TS_BEMensaje("Se proceso el correctamente el registro del deposito, pero hubo un problema al enviar la solicitud al servicio de impresión debe revisar el estado del mismo.",false);
                }
            }
            else
            {
                return Respuesta;
            }
            
        }
        public TS_BEDepositos CONSULTAR_DEPOSITOS(string nropos,string cdvendedor)
        {
            if (String.IsNullOrEmpty(nropos))
            {
                return new TS_BEDepositos() { cMensaje = new TS_BEMensaje("El numero POS es obligatorio", false) };
            }
            if (String.IsNullOrEmpty(cdvendedor))
            {
                return new TS_BEDepositos() { cMensaje = new TS_BEMensaje("El codigo de vendedor es obligatorio", false) };
            }
            TS_BETerminal terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = nropos });

            if (String.IsNullOrEmpty(terminal.nropos))
            {
                return new TS_BEDepositos() { cMensaje = new TS_BEMensaje("El punto de venta no existe", false) };
            }
            return ITS_DODeposito.CONSULTAR_DEPOSITOS(new TS_BEDeposito() { nropos = nropos , cdvendedor = cdvendedor},terminal);
        }
        public TS_BEMensaje AUTENTICAR_DEPOSITO_GRIFERO(TS_BELoginVendedor input)
        {
            if (String.IsNullOrEmpty(input.usuario))
            {
                return new TS_BEMensaje("El codigo de usuario es obligatorio", false);
            }
            if (String.IsNullOrEmpty(input.clave))
            {
                return new TS_BEMensaje("La clave de autenticación es obligatoria", false);
            }
            if (String.IsNullOrEmpty(input.cdempresa))
            {
                return new TS_BEMensaje("La empresa del vendedor es obligatoria", false);
            }

            TS_BEMensaje Respuesta = ITS_DODeposito.VERIFICAR_GRIFERO_LADOS();

            if (Respuesta.Ok)
            {
                return ITS_DODeposito.AUTENTICAR_DEPOSITO_GRIFERO(input);
            }
            else
            {
                return Respuesta;
            }
        }
        public TS_BEMensaje REGISTRAR_GRIFERO_LADOS(TS_BELado input)
        {
            if (String.IsNullOrEmpty(input.cdvendedor))
            {
                return new TS_BEMensaje("El codigo de vendedor es obligatorio", false);
            }
            if (String.IsNullOrEmpty(input.lado))
            {
                return new TS_BEMensaje("El lado es obligatorio", false);
            }
            if (String.IsNullOrEmpty(input.nropos))
            {
                return new TS_BEMensaje("El punto de venta es obligatorio", false);
            }

            TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = input.nropos });
   
            if (String.IsNullOrEmpty(Terminal.nropos))
            {
                return new TS_BEMensaje("El punto de venta no existe", false);
            }
            else
            {
                input.turno  = Convert.ToString(Terminal.turno ?? 0);
                input.fecproceso = Terminal.fecproceso;

                return ITS_DODeposito.REGISTRAR_GRIFERO_LADOS(input);
            }
        }
        public TS_BELados OBTENER_GRIFERO_LADOS(string nropos)
        {
            TS_BELado input = new TS_BELado();

            if (String.IsNullOrEmpty(nropos))
            {
                return new TS_BELados (){ Mensaje = new TS_BEMensaje("El punto de venta es obligatorio", false)};
            }

            TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = nropos });

            if (String.IsNullOrEmpty(Terminal.nropos))
            {
                 return new TS_BELados() { Mensaje = new TS_BEMensaje("El punto de venta no existe", false) };
            }
            else
            {
                input.nropos = nropos;
                input.turno = Convert.ToString(Terminal.turno ?? 0);
                input.fecproceso = Terminal.fecproceso;
                TS_BELados cGriferoLados = ITS_DODeposito.OBTENER_GRIFERO_LADOS(input);
                TS_BEVendedores cVendedores = ITS_DODeposito.OBTENER_VENDEDORES();
                foreach(TS_BELado cLado in cGriferoLados.cLados)
                {
                    foreach(TS_BEVendedor cVendedor in cVendedores.cVendedores)
                    {
                        if (cLado.cdvendedor.Equals(cVendedor.cdusuario))
                        {
                            cLado.dsvendedor = cVendedor.dsvendedor;
                        }
                        if (String.IsNullOrEmpty(cVendedor.dsvendedor))
                        {
                            cVendedor.dsvendedor = "N\\A";
                        }
                    }
                }
                return cGriferoLados;
            }
        }
        public TS_BEMensaje ELIMINAR_GRIFERO_LADOS(TS_BELadoEInput input)
        {
            if (String.IsNullOrEmpty(input.nropos))
            {
                return new TS_BEMensaje("El punto de venta es obligatorio", false);
            }
            if (String.IsNullOrEmpty(input.lado))
            {
                return new TS_BEMensaje("El lado a eliminar es obligatorio", false);
            }
            TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = input.nropos });

            if (String.IsNullOrEmpty(Terminal.nropos))
            {
                return new TS_BEMensaje("El punto de venta no existe", false);
            }
            else
            {
                
                input.turno = Convert.ToString(Terminal.turno ?? 0);
                input.fecproceso = Terminal.fecproceso;

                return ITS_DODeposito.ELIMINAR_GRIFERO_LADOS(input);
            }
        }
        public TS_BEMensaje ELIMINAR_DEPOSITOS(TS_BEDepositoEInput input)
        {
            if (String.IsNullOrEmpty(input.nropos))
            {
                return new TS_BEMensaje("El punto de venta es obligatorio", false);
            }
            if (String.IsNullOrEmpty(input.nrodeposito))
            {
                return new TS_BEMensaje("El numero de deposito es obligatorio", false);
            }
            if (String.IsNullOrEmpty(input.turno))
            {
                return new TS_BEMensaje("El turno es obligatorio", false);
            }

            TS_BETerminal Terminal = ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = input.nropos });

            if (String.IsNullOrEmpty(Terminal.nropos))
            {
                return new TS_BEMensaje("El punto de venta no existe", false);
            }

            TS_BEDeposito Output = ITS_DODeposito.OBTENER_DEPOSITO(input, Terminal);
            TS_BEVendedor vVendero = ITS_DODeposito.OBTENER_VENDEDOR(Output.cdvendedor);
            Output.dsvendedor = vVendero.dsvendedor;
            if (Output == null)
            {
                return new TS_BEMensaje("El deposito descrito no existe", false);
            }


            else
            {
                TS_BEMensaje Respuesta =  ITS_DODeposito.ELIMINAR_DEPOSITOS(input,Terminal);

                if (Respuesta.Ok)
                {
                    try
                    {
                        TS_BETicket cTicket = ITS_DOBackOffice.SP_ITBCP_LISTAR_FORMATO_TICKET();
                        Output.mtosoles = Output.mtosoles *-1;
                        Output.mtodolares = Output.mtodolares * -1;
                        Output.cFormato = new TS_BEFormato(cTicket.cabecera, cTicket.pie);
                        Output.cFormato.header = Output.cFormato.header + "\nANULACION DE OPERACION \n";
                        Output.nrodocumento = Output.nrodeposito;
                        Output.nroseriemaq = Terminal.nroseriemaq ?? "N\\A";
                        Output.fecdocumento = DateTime.Now;

                        var json = JsonConvert.SerializeObject(Output);

                        string impresora = Terminal.ticketimpre;
                        string formato = Terminal.depositofmt;
                        string nombre = "DE-" + Output.nrodeposito + " " + DateTime.Now.ToString("yyyyMMdd") + " - ANUL";
                        string cdtipodoc = "80003";
                        string url = Terminal.rutaservicio + "/print?" + "printer=" + HttpUtility.UrlEncode(impresora) +
                                                                        "&formato=" + HttpUtility.UrlEncode(formato) +
                                                                        "&cdtipodoc=" + cdtipodoc +
                                                                        "&nombre=" + HttpUtility.UrlEncode(nombre) +
                                                                        "&DOC=" + (true) +
                                                                        "&PDF=" + (Terminal.generapdf == true ? true : false) + "";
                        WebRequest request = WebRequest.Create(url);
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

                        return new TS_BEMensaje(responseFromServer, (responseFromServer ?? "").Equals("OK"));
                    }
                    catch (Exception ex)
                    {
                        return new TS_BEMensaje(ex.InnerException.Message, false);
                    }
                }
                else
                {
                    return Respuesta;
                }
            }
        }
        public TS_BEVendedores OBTENER_VENDEDORES(string cdempresa)
        {
            if (String.IsNullOrEmpty(cdempresa))
            {
                return new TS_BEVendedores() { Mensaje = new TS_BEMensaje("El codigo de la empresa no puede estar nulo o vacio", true) };
            }
            else
            {
                return ITS_DODeposito.OBTENER_VENDEDORES(cdempresa);
            }
        }
        public TS_BEMensaje AUTENTICAR_GRIFERO_LADOS(TS_BELoginVendedor input)
        {
            if (String.IsNullOrEmpty(input.usuario))
            {
                return new TS_BEMensaje("El codigo de usuario es obligatorio", false);
            }
            if (String.IsNullOrEmpty(input.clave))
            {
                return new TS_BEMensaje("La clave de autenticación es obligatoria", false);
            }
            if (String.IsNullOrEmpty(input.cdempresa))
            {
                return new TS_BEMensaje("La empresa del vendedor es obligatoria", false);
            }

            return ITS_DODeposito.AUTENTICAR_DEPOSITO_GRIFERO(input);
        }
        public TS_BEDocumento OBTENER_DOCUMENTO(TS_BEDAnulaInput input)
        {
            TS_BEDocumentoInput Output = new TS_BEDocumentoInput()
            {
                nropos = input.nropos,
                nrodocumento = input.nrodocumento,
                cdtipodoc = input.cdtipodoc,
                nroseriemaq = input.nroseriemaq,
                fecha = input.fecha
            };

                TS_BEDocumento Documento = new TS_BEDocumento();
                Documento.cEmisor = ITS_DOReimpresion.OBTENER_EMISOR();
                Documento.cCabecera = ITS_DOReimpresion.OBTENER_VENTA_CABECERA(Output);
                Documento.cDetalles = ITS_DOReimpresion.OBTENER_VENTA_DETALLE(Output);
                Documento.cPagos = ITS_DOReimpresion.OBTENER_VENTA_PAGO(Output);
                Documento.cCliente = ITS_DOReimpresion.OBTENER_CLIENTE(Documento, ITS_AICliente.ObtenerClienteByCodigo(new TS_BEClienteSearch() { Codigo = Documento.cCabecera.cdcliente }) );
                Documento.cCabecera.numero_texto = ITS_AIUtilities.ToCardinal(Convert.ToDecimal(Documento.cCabecera.mtototal));
                return Documento;
        }
        public TS_BEReimpresionLOutput LISTAR_DOCUMENTOS_REIMPRESION(TS_BEReimpresionLInput input)
        {
            if (String.IsNullOrEmpty(input.nropos))
            {
                return new TS_BEReimpresionLOutput(new TS_BEMensaje("Es obligatorio el punto de venta", false));
            }
            if (String.IsNullOrEmpty( ( ITS_DOTerminal.OBTENER_TERMINAL_POR_NROPOS(new TS_BETerminal() { nropos = input.nropos }) ).nropos))
            {
                return new TS_BEReimpresionLOutput(new TS_BEMensaje("El punto de venta especificado no existe", false));
            }
            if (string.IsNullOrEmpty(input.nrodocumento))
            {
                return new TS_BEReimpresionLOutput(new TS_BEMensaje("El numero de documento no puede estar vacio", false));
            }
            if (string.IsNullOrEmpty(input.cdtipodoc))
            {
                return new TS_BEReimpresionLOutput(new TS_BEMensaje("Se debe especificar el tipo de documento", false));
            }
            if (Regex.Replace(input.nrodocumento,"[^0-9]","").Length < 3)
            {
                return new TS_BEReimpresionLOutput(new TS_BEMensaje("Se debe indiciar al menos el numero de serie del documento", false));
            }
            if (Regex.Replace(input.cdtipodoc, "[^0-9]", "").Length !=5)
            {
                return new TS_BEReimpresionLOutput(new TS_BEMensaje("Se debe indiciar un tipo de documento valido", false));
            }
            else
            {
                return ITS_DOReimpresion.LISTAR_DOCUMENTOS_REIMPRESION(input);
            }
        }
        public TS_BEMensaje AUTENTICAR_CONFIGURACION_LADOS(TS_BELoginVendedor input)
        {
            if (String.IsNullOrEmpty(input.usuario))
            {
                return new TS_BEMensaje("El codigo de usuario es obligatorio", false);
            }
            if (String.IsNullOrEmpty(input.clave))
            {
                return new TS_BEMensaje("La clave de autenticación es obligatoria", false);
            }
            if (String.IsNullOrEmpty(input.cdempresa))
            {
                return new TS_BEMensaje("La empresa del vendedor es obligatoria", false);
            }

            input.clave = ITS_AIUtilities.CheckPassword((input.clave ?? "").Trim());

            return ITS_DODeposito.AUTENTICAR_CONFIGURACION_LADOS(input);
        }
    }

}
