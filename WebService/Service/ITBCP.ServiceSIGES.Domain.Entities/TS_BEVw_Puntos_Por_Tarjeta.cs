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
	/// <summary> Entidad = Vw_Puntos_Por_Tarjeta</summary>
	///
	public class TS_BEVw_Puntos_Por_Tarjeta
	{

		[DataMember]
		public int? valorid { get; set; }

		[DataMember]
		public double? valorpunto { get; set; }

		[DataMember]
		public string tipovar { get; set; }

		[DataMember]
		public string descripcion { get; set; }

		[DataMember]
		public string ctipo_punto { get; set; }

		[DataMember]
		public string expr1 { get; set; }

		[DataMember]
		public string tarjafiliacion { get; set; }

		[DataMember]
		public string cdgrupo02 { get; set; }

		[DataMember]
		public string cdarticulo { get; set; }

		[DataMember]
		public string dsarticulo { get; set; }

		[DataMember]
		public string ruccliente { get; set; }

	}
}
