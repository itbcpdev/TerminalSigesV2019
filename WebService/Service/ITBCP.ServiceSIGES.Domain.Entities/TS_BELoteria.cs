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
	/// <summary> Entidad = Loteria</summary>
	///
	public class TS_BELoteria
	{

		[DataMember]
		public int? id { get; set; }

		[DataMember]
		public DateTime? fecinicio { get; set; }

		[DataMember]
		public DateTime? fecfin { get; set; }

		[DataMember]
		public bool? flgactivo { get; set; }

		[DataMember]
		public bool? flgefectivo { get; set; }

		[DataMember]
		public bool? flgtarjeta { get; set; }

		[DataMember]
		public bool? flgcheque { get; set; }

		[DataMember]
		public bool? flgcredito { get; set; }

		[DataMember]
		public bool? flgpromocion { get; set; }

		[DataMember]
		public bool? nro_centralizacion { get; set; }

	}
}
