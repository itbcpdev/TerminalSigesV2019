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
	public class TS_BETmpmovpuntos
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

	}
}
