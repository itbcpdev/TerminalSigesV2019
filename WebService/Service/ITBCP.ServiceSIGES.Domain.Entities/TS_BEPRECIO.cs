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
	/// <summary> Entidad = Precio</summary>
	///
	public class TS_BEPrecio
	{

		[DataMember]
		public DateTime? fecinioferta { get; set; }

		[DataMember]
		public DateTime? fecfinoferta { get; set; }

		[DataMember]
		public DateTime? fecedicion { get; set; }

		[DataMember]
		public decimal? mtoprecio { get; set; }

		[DataMember]
		public decimal? porcomision { get; set; }

		[DataMember]
		public decimal? mtoprecioferta { get; set; }

		[DataMember]
		public string promocionid { get; set; }

		[DataMember]
		public string cdarticulo { get; set; }

		[DataMember]
		public string talla { get; set; }

		[DataMember]
		public string cdprecio { get; set; }

		[DataMember]
		public string cdmoneda { get; set; }

		[DataMember]
		public string cdmonoferta { get; set; }

		[DataMember]
		public string horinioferta { get; set; }

		[DataMember]
		public string horfinoferta { get; set; }

	}
}
