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
	/// <summary> Entidad = Tarjbonus</summary>
	///
	public class TS_BETarjbonus
	{

		[DataMember]
		public bool? enviado { get; set; }

		[DataMember]
		public string cdestacion { get; set; }

		[DataMember]
		public string nrobonus { get; set; }

		[DataMember]
		public string fecha { get; set; }

		[DataMember]
		public string hora { get; set; }

		[DataMember]
		public string nroequipo { get; set; }

		[DataMember]
		public string nrotransac { get; set; }

		[DataMember]
		public string total { get; set; }

		[DataMember]
		public string cdproducto { get; set; }

		[DataMember]
		public string cantidad { get; set; }

		[DataMember]
		public string totalvta { get; set; }

	}
}
