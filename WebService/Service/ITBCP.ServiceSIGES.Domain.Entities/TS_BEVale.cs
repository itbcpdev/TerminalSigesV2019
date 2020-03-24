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
	/// <summary> Entidad = Vale</summary>
	///
	public class TS_BEVale
	{

		[DataMember]
		public DateTime? fecvale { get; set; }

		[DataMember]
		public bool? flgbloqueado { get; set; }

		[DataMember]
		public decimal? mtovale { get; set; }

		[DataMember]
		public string nrovale { get; set; }

		[DataMember]
		public string cdmoneda { get; set; }

		[DataMember]
		public string cdcliente { get; set; }

	}
}
