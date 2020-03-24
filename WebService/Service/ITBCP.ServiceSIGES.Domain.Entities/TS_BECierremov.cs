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
	/// <summary> Entidad = Cierremov</summary>
	///
	public class TS_BECierremov
	{

		[DataMember]
		public decimal? ventas { get; set; }

		[DataMember]
		public decimal? ingresos { get; set; }

		[DataMember]
		public decimal? salidas { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string cdalmacen { get; set; }

		[DataMember]
		public string cdarticulo { get; set; }

	}
}
