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
	/// <summary> Entidad = Almacen</summary>
	///
	public class TS_BEAlmacen
	{

		[DataMember]
		public DateTime? fecinventario { get; set; }

		[DataMember]
		public bool? inventario { get; set; }

		[DataMember]
		public bool? activo { get; set; }

		[DataMember]
		public string daalmacen { get; set; }

		[DataMember]
		public string cdalmacen { get; set; }

		[DataMember]
		public string dsalmacen { get; set; }

		[DataMember]
		public string tipo { get; set; }

	}
}
