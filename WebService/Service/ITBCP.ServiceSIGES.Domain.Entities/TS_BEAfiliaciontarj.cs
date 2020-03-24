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
	/// <summary> Entidad = Afiliaciontarj</summary>
	///
	public class TS_BEAfiliaciontarj
	{

		[DataMember]
		public int? estado { get; set; }

		[DataMember]
		public DateTime? fechaultconsumo { get; set; }

		[DataMember]
		public bool? bloqueado { get; set; }

		[DataMember]
		public bool? csql_actualiza { get; set; }

		[DataMember]
		public decimal? puntos { get; set; }

		[DataMember]
		public decimal? canjeado { get; set; }

		[DataMember]
		public decimal? disponible { get; set; }

		[DataMember]
		public decimal? valoracumula { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string tarjafiliacion { get; set; }

		[DataMember]
		public string cdcliente { get; set; }

		[DataMember]
		public string ruccliente { get; set; }

		[DataMember]
		public string rscliente { get; set; }

		[DataMember]
		public string drcliente { get; set; }

		[DataMember]
		public string tlfcliente { get; set; }

		[DataMember]
		public string tlfcliente1 { get; set; }

		[DataMember]
		public string emcliente { get; set; }

		[DataMember]
		public string provtelefonia { get; set; }

		[DataMember]
		public string provtelefonia1 { get; set; }

		[DataMember]
		public string tarjafiliacion_traspaso { get; set; }

	}
}
