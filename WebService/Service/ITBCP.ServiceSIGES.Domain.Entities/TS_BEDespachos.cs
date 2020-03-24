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
	/// <summary> Entidad = Despachos</summary>
	///
	public class TS_BEDespachos
	{

		[DataMember]
		public DateTime? fecha { get; set; }

		[DataMember]
		public decimal? cantidad { get; set; }

		[DataMember]
		public decimal? total { get; set; }

		[DataMember]
		public string codvehiculo { get; set; }

		[DataMember]
		public string codruta { get; set; }

		[DataMember]
		public string hora { get; set; }

		[DataMember]
		public string id { get; set; }

	}
}
