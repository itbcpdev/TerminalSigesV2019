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
	/// <summary> Entidad = Placa</summary>
	///
	public class TS_BEPlaca
	{

		[DataMember]
		public decimal? ano { get; set; }

		[DataMember]
		public decimal? kilometraje { get; set; }

		[DataMember]
		public string nroplaca { get; set; }

		[DataMember]
		public string marca { get; set; }

		[DataMember]
		public string modelo { get; set; }

		[DataMember]
		public string color { get; set; }

		[DataMember]
		public string nroserie { get; set; }

		[DataMember]
		public string nromotor { get; set; }

	}
}
