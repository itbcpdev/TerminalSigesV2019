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
	//Creado por     : Ronald Noé Saavedra Bances (09/03/2019)
	//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
	/// <summary> Entidad = Loteriawin</summary>
	///
	public class TS_BELoteriawin
	{

		[DataMember]
		public DateTime? fecha { get; set; }

		[DataMember]
		public DateTime? fecdocumento { get; set; }

		[DataMember]
		public DateTime? fecproceso { get; set; }

		[DataMember]
		public decimal? item { get; set; }

		[DataMember]
		public decimal? mtototal { get; set; }

		[DataMember]
		public decimal? nroganador { get; set; }

		[DataMember]
		public decimal? frecuencia { get; set; }

		[DataMember]
		public string nroseriemaq { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string cdmoneda { get; set; }

	}
}
