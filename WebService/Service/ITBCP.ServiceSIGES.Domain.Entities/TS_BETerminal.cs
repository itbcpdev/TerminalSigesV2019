using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
	[DataContract]
	//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
	//Creado por     : Ronald Noé Saavedra Bances (28/01/2019)
	//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
	/// <summary> Entidad = Terminal</summary>
	///
	public class TS_BETerminal
	{

		[DataMember]
		public byte? conexion_dispensador { get; set; }

		[DataMember]
		public int? fe_idpos { get; set; }

		[DataMember]
		public DateTime? fecproceso { get; set; }

		[DataMember]
		public bool? tktfactura { get; set; }

		[DataMember]
		public bool? tktboleta { get; set; }

		[DataMember]
		public bool? tktpromocion { get; set; }

		[DataMember]
		public bool? facturapreimpre { get; set; }

		[DataMember]
		public bool? boletapreimpre { get; set; }

		[DataMember]
		public bool? promocionpreimpre { get; set; }

		[DataMember]
		public bool? activa_boton_playa { get; set; }

		[DataMember]
		public bool? flg_pdf417 { get; set; }

		[DataMember]
		public bool? flg_nc_correlativo { get; set; }

		[DataMember]
		public bool? flg_nd_correlativo { get; set; }

		[DataMember]
		public bool? flg_print_qr { get; set; }

		[DataMember]
		public bool? flg_formato_a4 { get; set; }

		[DataMember]
		public bool? rucinvalido { get; set; }

		[DataMember]
		public bool? _virtual { get; set; }

		[DataMember]
		public bool? tktnotadespacho { get; set; }

		[DataMember]
		public bool? flgtransferencia { get; set; }

		[DataMember]
		public bool? playa_formasdepago { get; set; }

		[DataMember]
		public bool? modif_corr { get; set; }

		[DataMember]
		public bool? flgpagotarjeta { get; set; }

		[DataMember]
		public bool? flgpagocheque { get; set; }

		[DataMember]
		public bool? flgpagocredito { get; set; }

		[DataMember]
		public bool? flgpagoncredito { get; set; }

		[DataMember]
		public bool? flgvalidaz { get; set; }

		[DataMember]
		public bool? flgcierrezok { get; set; }

		[DataMember]
		public bool? flghotkey { get; set; }

		[DataMember]
		public bool? flgfacturacion { get; set; }

		[DataMember]
		public bool? grabarcliente { get; set; }

		[DataMember]
		public bool? flgautomatica { get; set; }

		[DataMember]
		public bool? flgaperturacaja { get; set; }

		[DataMember]
		public bool? flgpagoefectivo { get; set; }

		[DataMember]
		public bool? modocompra { get; set; }

		[DataMember]
		public bool? modservicio { get; set; }

		[DataMember]
		public bool? modobservacion { get; set; }

		[DataMember]
		public bool? moddsctogral { get; set; }

		[DataMember]
		public bool? moddsctoitem { get; set; }

		[DataMember]
		public bool? preciocero { get; set; }

		[DataMember]
		public bool? modfecha { get; set; }

		[DataMember]
		public bool? modmoneda { get; set; }

		[DataMember]
		public bool? modvendedor { get; set; }

		[DataMember]
		public bool? modalmacen { get; set; }

		[DataMember]
		public bool? modlistap { get; set; }

		[DataMember]
		public bool? modprecio { get; set; }

		[DataMember]
		public decimal? nrozeta { get; set; }

		[DataMember]
		public decimal? mtozeta { get; set; }

		[DataMember]
		public decimal? ticketfeed { get; set; }

		[DataMember]
		public decimal? ticketlineacorte { get; set; }

		[DataMember]
		public decimal? ticket2columnas { get; set; }

		[DataMember]
		public decimal? nventafeed { get; set; }

		[DataMember]
		public decimal? promocionfeed { get; set; }

		[DataMember]
		public decimal? mtodsctomax { get; set; }

		[DataMember]
		public decimal? turno { get; set; }

		[DataMember]
		public decimal? tranvirtual { get; set; }

		[DataMember]
		public decimal? nrodeposito { get; set; }

		[DataMember]
		public string facturaimpre { get; set; }

		[DataMember]
		public string boletaimpre { get; set; }

		[DataMember]
		public string gavetachr { get; set; }

		[DataMember]
		public string promocionimpre { get; set; }

		[DataMember]
		public string ncreditoimpre { get; set; }

		[DataMember]
		public string ndebitoimpre { get; set; }

		[DataMember]
		public string guiaimpre { get; set; }

		[DataMember]
		public string proformaimpre { get; set; }

		[DataMember]
		public string letraimpre { get; set; }

		[DataMember]
		public string path_loteria { get; set; }

		[DataMember]
		public string fe_nompos { get; set; }

		[DataMember]
		public string nropos { get; set; }

		[DataMember]
		public string cdusuario { get; set; }

		[DataMember]
		public string seriehd { get; set; }

		[DataMember]
		public string nroseriemaq { get; set; }

		[DataMember]
		public string nroserie1 { get; set; }

		[DataMember]
		public string nroserie2 { get; set; }

		[DataMember]
		public string tipoterminal { get; set; }

		[DataMember]
		public string ticketfactura { get; set; }

		[DataMember]
		public string ncreditoboleta { get; set; }

		[DataMember]
		public string ndebitoboleta { get; set; }

		[DataMember]
		public string guiafmt { get; set; }

		[DataMember]
		public string proforma { get; set; }

		[DataMember]
		public string proformafmt { get; set; }

		[DataMember]
		public string letra { get; set; }

		[DataMember]
		public string letrafmt { get; set; }

		[DataMember]
		public string displayimpre { get; set; }

		[DataMember]
		public string promocionchrfin { get; set; }

		[DataMember]
		public string ncredito { get; set; }

		[DataMember]
		public string ncreditofmt { get; set; }

		[DataMember]
		public string ndebito { get; set; }

		[DataMember]
		public string ndebitofmt { get; set; }

		[DataMember]
		public string guia { get; set; }

		[DataMember]
		public string nventaimpre { get; set; }

		[DataMember]
		public string nventachrini { get; set; }

		[DataMember]
		public string nventachrfin { get; set; }

		[DataMember]
		public string promocion { get; set; }

		[DataMember]
		public string promocionfmt { get; set; }

		[DataMember]
		public string promocionchrini { get; set; }

		[DataMember]
		public string gavetaimpre { get; set; }

		[DataMember]
		public string ticket { get; set; }

		[DataMember]
		public string ticketimpre { get; set; }

		[DataMember]
		public string ticketchrini { get; set; }

		[DataMember]
		public string ticketchrfin { get; set; }

		[DataMember]
		public string nventa { get; set; }

		[DataMember]
		public string cdalmacen { get; set; }

		[DataMember]
		public string cdprecio { get; set; }

		[DataMember]
		public string factura { get; set; }

		[DataMember]
		public string facturafmt { get; set; }

		[DataMember]
		public string boleta { get; set; }

		[DataMember]
		public string boletafmt { get; set; }

        [DataMember]
        public bool? generapdf { get; set; }
        [DataMember]
        public string rutaservicio { get; set; }
        [DataMember]
        public string cierrexfmt { get; set; }
        [DataMember]
        public string cierrezfmt { get; set; }
        [DataMember]
        public string nventafmt { get; set; }
        [DataMember]
        public string serafinfmt { get; set; }
        [DataMember]
        public string depositofmt { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
        
    }
}
