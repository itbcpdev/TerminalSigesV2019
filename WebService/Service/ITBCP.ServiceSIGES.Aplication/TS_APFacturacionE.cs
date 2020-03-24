using System;
using System.Text;
using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain.Entities;
using ITBCP.ServiceSIGES.Domain.Entities.Facturacion.Electronica;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities.Sales;
using System.Web;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APFacturacionE : ITS_AIFacturacionE
    {
        ITS_AIUtilities ITS_AIUtilities;
        ITS_DOAceptaFE ITS_DOAceptaFE;
        
        public TS_APFacturacionE(ITS_AIUtilities ITS_AIUtilities, ITS_DOAceptaFE ITS_DOAceptaFE)
        {
            this.ITS_AIUtilities = ITS_AIUtilities;
            this.ITS_DOAceptaFE = ITS_DOAceptaFE;

        }
        public TS_BEMensaje VALIDAR_DATOS(TS_BEDocumento Documento)
        {
            string errores = "";
            int cont_errores = 0;
            TimeSpan time = DateTime.Now - Documento.cCabecera.fecdocumento;
            if ((Documento.cCabecera.nrodocumento.Length != 10)) { errores += "El numero de documento consta de 10 digitos\n"; cont_errores++; }
            if (Documento.cCabecera.cdtipodoc.Length != 5) { errores += "El tipo de documento consta de 5 digitos\n"; cont_errores++; }
            if (Documento.cCabecera.fecdocumento == null) { errores += "La fecha de emisión es obligatoría\n"; cont_errores++; }
            if (time.Days > 7) { errores = "La fecha de emisión no puede ser menor a 7 días anteriores\n"; cont_errores++; }
            if (DateTime.Compare(DateTime.Now, Documento.cCabecera.fecdocumento) < 0) { errores += "La fecha de emisión no puede ser mayor que el día actual\n"; cont_errores++; }
            if (Documento.cCabecera.mtoimpuesto < 0) { errores += "El impuesto no puede ser menor a 0 ni un numero negativo\n"; cont_errores++; }
            if (Documento.cCabecera.mtototal < 0) { errores += "El monto total no puede ser menor a 0 ni un numero negativo\n"; cont_errores++; }
            if (Documento.cDetalles.Count < 1) { errores += "No se puede emitir un documento electrónico sin detalles\n"; cont_errores++; }
            if (Documento.cCabecera.mtototal + 1 < Documento.cCabecera.mtodscto) { errores += "El descuento global no puede superar el monto total del documento electronico\n"; cont_errores++; }
            foreach (TS_BEArticulo Detalle in Documento.cDetalles)
            {
                if (Detalle.cantidad < 0) { errores += "La cantidad del producto : " + Detalle.dsarticulo.Trim() + ", no puede ser \"0\" o menor a el\n"; cont_errores++; }
                if (String.IsNullOrEmpty(Detalle.dsarticulo.Trim())) { errores += "El nombre del artículo no puede ser nulo"; cont_errores++; }
                if (Detalle.item < 0) { errores = "El número de item del producto : " + Detalle.dsarticulo.Trim() + ", no puede ser \"0\" o menor a el\n"; cont_errores++; }
                if (String.IsNullOrEmpty(Detalle.cdunimed)) { errores += "La unidad de medida del producto : " + Detalle.dsarticulo.Trim() + ", no puede ser nula o vacía\n"; cont_errores++; }
                /*if (Detalle.mtodscto < 0) { errores = "El descuento del producto : " + Detalle.dsarticulo.Trim() + ", no puede ser menor a 0 ni un numero negativo"; cont_errores++; }*/
                if (Detalle.mtototal < 0) { errores += "El total del producto : " + Detalle.dsarticulo.Trim() + ", no puede ser menor a 0 ni un numero negativo\n"; cont_errores++; }
                if (Detalle.valorvta < 0) { errores += "El subtotal del producto : " + Detalle.dsarticulo.Trim() + ", no puede ser menor a 0 ni un numero negativo\n"; cont_errores++; }
                if (Detalle.impuesto < 0) { errores += "El impuesto del producto : " + Detalle.dsarticulo.Trim() + ", no puede ser menor a 0 ni un numero negativo\n"; cont_errores++; }
            }

            if (String.IsNullOrEmpty(Documento.cEmisor.Departamento)) { errores += "El campo de Departamento de la empresa emisora es obligatorio\n"; cont_errores++; }
            if (String.IsNullOrEmpty(Documento.cEmisor.Direccion)) { errores += "El campo de Dirección de la empresa emisora es obligatorio\n"; cont_errores++; }
            if (String.IsNullOrEmpty(Documento.cEmisor.Distrito)) { errores += "El campo de Distrito de la empresa emisora es obligatorio\n"; cont_errores++; }
            if (String.IsNullOrEmpty(Documento.cEmisor.RUC)) { errores += "El campo de RUC de la empresa emisora es obligatorio\n"; cont_errores++; }
            if ((!String.IsNullOrEmpty(Documento.cEmisor.RUC)) && (Documento.cEmisor.RUC.Length < 11)) { errores += "El campo de RUC consta de 11 dígitos\n"; cont_errores++; }
            if (String.IsNullOrEmpty(Documento.cEmisor.RazonSocial)) { errores += "El campo de Razon Social de la empresa emisora es obligatorio\n"; cont_errores++; }
            if (String.IsNullOrEmpty(Documento.cEmisor.Ubigeo)) { errores += "El campo de Ubigeo de la empresa emisora es obligatorio\n"; cont_errores++; }
            if (String.IsNullOrEmpty(Documento.cEmisor.nroautorizacion)) { errores += "El campo de Número de autorización de la empresa emisora es obligatorio\n"; cont_errores++; }
            if (String.IsNullOrEmpty(Documento.cEmisor.Urbanizacion)) { errores += "El campo de Urbanización de la empresa emisora es obligatorio\n"; cont_errores++; }



            if (Documento.cPagos.Count < 0) { errores += "No se puede emitir un documento electrónico sin los tipos de pagos\n"; cont_errores++; }
            foreach (TS_BEPago Pago in Documento.cPagos)
            {
                if (String.IsNullOrEmpty(Pago.cdtppago) || Pago.cdtppago.Length < 5) { errores += "El campo de código de pago consta de 5 dígitos y es obligatorio\n"; cont_errores++; }
                if (Convert.ToDecimal(Pago.mtopagosol)<0 || Convert.ToDecimal(Pago.mtopagodol) < 0) { errores += "El monto de pago no puede ser menor a 0\n"; cont_errores++; }
            }

            if (Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("03")) {
                if (Documento.cCabecera.mtototal >= 700)
                {
                    if (Documento.cCliente.cdcliente.Length != 8) { errores += "\nPara montos mayores a 700 soles en boleta el DNI es obligatorio\n"; cont_errores++; }
                    if (Documento.cCliente.rscliente.Length < 1) { errores += "\nPara montos mayores a 700 soles en boleta la razón social es obligatoria\n"; cont_errores++; }
                }
                else
                {
                    if (Documento.cCliente.cdcliente.Length > 0)
                    {
                        /*if (Documento.cCliente.cdcliente.Length != 8) { errores += "El DNI del cliente consta de 8 digitos\n"; cont_errores++; }*/
                        if (Documento.cCliente.rscliente.Length < 1) { errores += "La razon social del cliente es obligatorío si se coloca DNI\n"; cont_errores++; }
                    }
                }

            }
            if (Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("01"))
            {
                if (Documento.cCliente.cdcliente.Length != 11) { errores += "El RUC del cliente es obligatorío y consta de 11 digitos\n"; cont_errores++; }
                if (String.IsNullOrEmpty(Documento.cCliente.rscliente.Replace("-", ""))) { errores += "La razon social del cliente es obligatoría en facturas\n"; cont_errores++; }

            }
            if (cont_errores == 0)
            {
                Documento.cCabecera.numero_texto = ITS_AIUtilities.ToCardinal(Documento.cCabecera.mtototal);
            }
            if (cont_errores > 0) { return new TS_BEMensaje(errores, false); }
            else { return new TS_BEMensaje("Validación de datos terminada correctamente.", true); }
        }
        public TS_BERespuestaFE OBTENER_RESPUESTA(TS_BEDocumento Documento)
        {
            TS_BEParametro Parametro = Documento.cParametro;
            TS_BEParameters Tab00S0 = Documento.cTab0S00;
            TS_BEMensaje MensajeValidacion = VALIDAR_DATOS(Documento);
            if (MensajeValidacion.Ok)
            {
                if (Tab00S0.fe_proveedor.Equals("AC2") || Tab00S0.fe_proveedor.Equals("ACT"))
                {
                    if (String.IsNullOrEmpty(Tab00S0.fe_proveedor) || String.IsNullOrEmpty(Tab00S0.fe_act_rutaprocesamiento))
                    {
                        return new TS_BERespuestaFE() { Respuesta = "La configuración del facturador electronico o el servidor de procesamiento es incorrecta para Acepta", OK = false };
                    }
                    else
                    {
                        string Cabecera = ITS_DOAceptaFE.OBTENER_CABECERA(Documento);
                        string Detalle = ITS_DOAceptaFE.OBTENER_DETALLES(Documento);
                        string Global = ITS_DOAceptaFE.OBTENER_GLOBAL(Documento);
                        string Pagos = ITS_DOAceptaFE.OBTENER_PAGOS(Documento);
                        string lTrama = Cabecera + Detalle + Global + Pagos+ "~\\";
                        string TramaEncode = HttpUtility.UrlEncode(lTrama);
                        string postData =
                                "docid=" + Documento.cCabecera.cdtipodoc.Substring(3, 2) +
                                (Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("01") ? "F" : // F En caso de cdtipodoc 00001
                                 Documento.cCabecera.cdtipodoc.Substring(3, 2).Equals("03") ? "B" : // B En caso de cdtipodoc 00003
                                 "0") + // En caso de cdtipodoc 00008 nota de debito agregamos el documento de referencia
                                (Documento.cCabecera.nrodocumento.Substring(0, 3)) + // Agremagos la serie de 3 digitos
                                "0" + // Agregamos un 0 faltante para el nrodocumento sea de 8 digitos + 3 de la serie
                                (Documento.cCabecera.nrodocumento.Substring(3, 7)) + // agregamos el resto de los 7 digitos que maneja el sistema
                                "&comando=emitir" + // comando emitir
                                "&parametros=" + // parametros en blanco
                                "&datos=" + TramaEncode; // Trama con Encode tipo HTTP
                        return new TS_BERespuestaFE() { Respuesta = postData, OK = true };

                    }
                }
                else
                {
                    return new TS_BERespuestaFE() { Respuesta = "Proveedor electronico no soportado : " + Tab00S0.fe_proveedor.Trim(), OK = false };
                }

            }
            else
            {
                return new TS_BERespuestaFE() { Respuesta = MensajeValidacion.mensaje, OK = MensajeValidacion.Ok };
            }

        }

               
    }
}

