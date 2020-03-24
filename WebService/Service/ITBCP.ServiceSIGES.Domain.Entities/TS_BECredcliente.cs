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
	//Creado por     : Ronald Noé Saavedra Bances 27/02/2019
	//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
	/// <summary> Entidad = Credcliente</summary>
	///
	public class TS_BECredcliente
	{

		[DataMember]
		public DateTime? fecdocumento { get; set; }

		[DataMember]
		public DateTime? fecvencimiento { get; set; }

		[DataMember]
		public DateTime? fecpago { get; set; }

		[DataMember]
		public DateTime? fecsistema { get; set; }

		[DataMember]
		public DateTime? fecproceso { get; set; }

		[DataMember]
		public decimal? mtototal { get; set; }

		[DataMember]
		public decimal? mtoemision { get; set; }

		[DataMember]
		public decimal? mtosoles { get; set; }

		[DataMember]
		public decimal? mtodolares { get; set; }

		[DataMember]
		public decimal? mtodifcambio { get; set; }

		[DataMember]
		public decimal? tcambio { get; set; }

		[DataMember]
		public decimal? nropago { get; set; }

		[DataMember]
		public string docpago { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string renovacion { get; set; }

		[DataMember]
		public string nropos { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string nrocheque { get; set; }

		[DataMember]
		public string cdtarjeta { get; set; }

		[DataMember]
		public string nrotarjeta { get; set; }

		[DataMember]
		public string referencia { get; set; }

		[DataMember]
		public string cdcobrador { get; set; }

		[DataMember]
		public string nroplanilla { get; set; }

		[DataMember]
		public string nrorecibo { get; set; }

		[DataMember]
		public string cdtppago { get; set; }

		[DataMember]
		public string cdbanco { get; set; }

		[DataMember]
		public string nrocuenta { get; set; }

		[DataMember]
		public string cdalmacen { get; set; }

		[DataMember]
		public string cdcliente { get; set; }

		[DataMember]
		public string cdmoneda { get; set; }

		[DataMember]
		public string cddocaplica { get; set; }

		[DataMember]
		public string nrodocaplica { get; set; }

		[DataMember]
		public string cdvendedor { get; set; }

	}
}
