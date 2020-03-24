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
	/// <summary> Entidad = Tmpmovpuntos</summary>
	///
	public class TS_BETmpmovpuntosArticulo
	{

		[DataMember]
		public byte? turno { get; set; }

		[DataMember]
		public short? item { get; set; }

		[DataMember]
		public DateTime? fechadoc { get; set; }

		[DataMember]
		public DateTime? fechasis { get; set; }

		[DataMember]
		public double? tcambio { get; set; }

		[DataMember]
		public double? impuesto { get; set; }

		[DataMember]
		public double? precio { get; set; }

		[DataMember]
		public double? cantidad { get; set; }

		[DataMember]
		public double? mtodescto { get; set; }

		[DataMember]
		public double? mtosubtotal { get; set; }

		[DataMember]
		public double? mtoimpuesto { get; set; }

		[DataMember]
		public double? mtototal { get; set; }

		[DataMember]
		public double? puntos { get; set; }

		[DataMember]
		public double? valoracumulado { get; set; }

		[DataMember]
		public bool? enviado { get; set; }

		[DataMember]
		public bool? credito { get; set; }

		[DataMember]
		public string tarjafiliacion { get; set; }

		[DataMember]
		public string rscliente { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

		[DataMember]
		public string tipotran { get; set; }

		[DataMember]
		public string localid { get; set; }

		[DataMember]
		public string cdproducto { get; set; }

		[DataMember]
		public string serieprinter { get; set; }

		[DataMember]
		public string almacen { get; set; }

		[DataMember]
		public string clienteid { get; set; }

		[DataMember]
		public string ruccliente { get; set; }

		[DataMember]
		public string nropos { get; set; }

		[DataMember]
		public string moneda { get; set; }

		[DataMember]
		public string estado { get; set; }

		[DataMember]
		public byte[] tmstamp { get; set; }

		[DataMember]
		public string glosa { get; set; }

		[DataMember]
		public string referencia { get; set; }

		[DataMember]
		public string usuario { get; set; }


        // Articulo

        [DataMember]
        public string glosaArticulo { get; set; }

        [DataMember]
        public DateTime? fecinicial { get; set; }

        [DataMember]
        public DateTime? fecinventario { get; set; }

        [DataMember]
        public DateTime? fecedicion { get; set; }

        [DataMember]
        public bool? bloqvta { get; set; }

        [DataMember]
        public bool? bloqcom { get; set; }

        [DataMember]
        public bool? flgglosa { get; set; }

        [DataMember]
        public bool? moverstock { get; set; }

        [DataMember]
        public bool? venta { get; set; }

        [DataMember]
        public bool? consignacion { get; set; }

        [DataMember]
        public bool? trfgratuita { get; set; }

        [DataMember]
        public bool? is_easytaxi { get; set; }

        [DataMember]
        public bool? bloqgral { get; set; }

        [DataMember]
        public bool? movimiento { get; set; }

        [DataMember]
        public bool? vtaxmonto { get; set; }

        [DataMember]
        public bool? flgpromocion { get; set; }

        [DataMember]
        public bool? usadecimales { get; set; }

        [DataMember]
        public bool? _virtual { get; set; }

        [DataMember]
        public decimal? ctoreposicion { get; set; }

        [DataMember]
        public decimal? impuestoArticulo { get; set; }

        [DataMember]
        public decimal? impuesto1 { get; set; }

        [DataMember]
        public decimal? ctoinicial { get; set; }

        [DataMember]
        public decimal? ctoinventario { get; set; }

        [DataMember]
        public decimal? ctopromedio { get; set; }

        [DataMember]
        public decimal? mgutilidad { get; set; }

        [DataMember]
        public decimal? montofidelizacion { get; set; }

        [DataMember]
        public decimal? porcdetraccion { get; set; }

        [DataMember]
        public decimal? equivalencia { get; set; }

        [DataMember]
        public decimal? valorconversion { get; set; }

        [DataMember]
        public decimal? precioafiliacion { get; set; }

        [DataMember]
        public decimal? porcpercepcion { get; set; }

        [DataMember]
        public decimal? puntosfidelizacion { get; set; }

        [DataMember]
        public decimal? cantfidelizacion { get; set; }

        [DataMember]
        public string c_cuenta { get; set; }

        [DataMember]
        public string c_cuenta_ventas { get; set; }

        [DataMember]
        public string c_centrocosto { get; set; }

        [DataMember]
        public string c_cuenta_compras { get; set; }

        [DataMember]
        public string cdarticulovulcano { get; set; }

        [DataMember]
        public string cdarticulosunat { get; set; }

        [DataMember]
        public string cdarticulo { get; set; }

        [DataMember]
        public string dsarticulo { get; set; }

        [DataMember]
        public string dsarticulo1 { get; set; }

        [DataMember]
        public string cdgrupo01 { get; set; }

        [DataMember]
        public string cdgrupo02 { get; set; }

        [DataMember]
        public string cdgrupo03 { get; set; }

        [DataMember]
        public string ctacompra { get; set; }

        [DataMember]
        public string ctaventa { get; set; }

        [DataMember]
        public string ctacosto { get; set; }

        [DataMember]
        public string ctaalmacen { get; set; }

        [DataMember]
        public string ticketfactura { get; set; }

        [DataMember]
        public string monctoinventario { get; set; }

        [DataMember]
        public string monctoprom { get; set; }

        [DataMember]
        public string monctorepo { get; set; }

        [DataMember]
        public string cdmedequiv { get; set; }

        [DataMember]
        public string cdamarre { get; set; }

        [DataMember]
        public string tpconversion { get; set; }

        [DataMember]
        public string cdgrupo04 { get; set; }

        [DataMember]
        public string cdgrupo05 { get; set; }

        [DataMember]
        public string cdunimed { get; set; }

        [DataMember]
        public string cdtalla { get; set; }

        [DataMember]
        public string tpformula { get; set; }

        [DataMember]
        public string monctoinicial { get; set; }
    }
}
