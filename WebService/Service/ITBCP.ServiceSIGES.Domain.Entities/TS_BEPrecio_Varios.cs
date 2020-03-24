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
	/// <summary> Entidad = Precio_Varios</summary>
	///
	public class TS_BEPrecio_Varios
	{

		[DataMember]
		public DateTime? fechamodificacion { get; set; }

		[DataMember]
		public decimal? rango1 { get; set; }

		[DataMember]
		public decimal? rango2 { get; set; }

		[DataMember]
		public decimal? valor { get; set; }

		[DataMember]
		public string cdcliente { get; set; }

		[DataMember]
		public string cdarticulo { get; set; }

		[DataMember]
		public string tipocli { get; set; }

		[DataMember]
		public string tiporango { get; set; }

		[DataMember]
		public string tipo { get; set; }

	}
}
