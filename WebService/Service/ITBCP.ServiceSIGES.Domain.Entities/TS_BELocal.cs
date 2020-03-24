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
	/// <summary> Entidad = Local</summary>
	///
	public class TS_BELocal
	{

		[DataMember]
		public string nro_centralizacion { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string dslocal { get; set; }

		[DataMember]
		public string drlocal { get; set; }

		[DataMember]
		public string tlflocal { get; set; }

		[DataMember]
		public string tlflocal1 { get; set; }

		[DataMember]
		public string cdzona { get; set; }

		[DataMember]
		public string cdsunat { get; set; }

		[DataMember]
		public string dislocal { get; set; }

		[DataMember]
		public string provlocal { get; set; }

		[DataMember]
		public string deplocal { get; set; }

	}
}
