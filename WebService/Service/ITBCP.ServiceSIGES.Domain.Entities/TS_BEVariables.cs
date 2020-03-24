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
	/// <summary> Entidad = Variables</summary>
	///
	public class TS_BEVariables
	{

		[DataMember]
		public int? varid { get; set; }

		[DataMember]
		public double? valorpto { get; set; }

		[DataMember]
		public bool? flgelimina { get; set; }

		[DataMember]
		public string tipovar { get; set; }

		[DataMember]
		public string clave { get; set; }

		[DataMember]
		public string descripcion { get; set; }

		[DataMember]
		public string config { get; set; }

		[DataMember]
		public string valor { get; set; }

	}
}
