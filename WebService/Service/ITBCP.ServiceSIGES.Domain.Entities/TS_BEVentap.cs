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
	/// <summary> Entidad = Ventap</summary>
	///
	public class TS_BEVentap
	{

		[DataMember]
		public DateTime? fecproceso { get; set; }

		[DataMember]
		public DateTime? fecdocumento { get; set; }

		[DataMember]
		public bool? flgcierrez { get; set; }

		[DataMember]
		public decimal? mtopagosol { get; set; }

		[DataMember]
		public decimal? mtopagodol { get; set; }

		[DataMember]
		public decimal? turno { get; set; }

		[DataMember]
		public decimal? valoracumula { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string nroseriemaq { get; set; }

		[DataMember]
		public string nropos { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string cdtppago { get; set; }

		[DataMember]
		public string cdbanco { get; set; }

		[DataMember]
		public string nrocuenta { get; set; }

		[DataMember]
		public string nrocheque { get; set; }

		[DataMember]
		public string cdtarjeta { get; set; }

		[DataMember]
		public string nrotarjeta { get; set; }

		[DataMember]
		public string nroncredito { get; set; }

	}
}
