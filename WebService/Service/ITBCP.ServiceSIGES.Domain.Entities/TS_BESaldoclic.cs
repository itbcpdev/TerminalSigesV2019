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
	/// <summary> Entidad = Saldoclic</summary>
	///
	public class TS_BESaldoclic
	{

		[DataMember]
		public DateTime? fechainicio { get; set; }

		[DataMember]
		public bool? flgilimit { get; set; }

		[DataMember]
		public bool? flgbloquea { get; set; }

		[DataMember]
		public decimal? limitemto { get; set; }

		[DataMember]
		public decimal? consumto { get; set; }

		[DataMember]
		public string nrocontrato { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string cdcliente { get; set; }

		[DataMember]
		public string tpsaldo { get; set; }

		[DataMember]
		public string tipodespacho { get; set; }

		[DataMember]
		public string tipocredito { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

	}
}
