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
	/// <summary> Entidad = Op_Tran</summary>
	///
	public class TS_BEOp_Tran
	{

		[DataMember]
		public int? manguera { get; set; }

		[DataMember]
		public DateTime? fecha { get; set; }

		[DataMember]
		public string hora { get; set; }

		[DataMember]
		public DateTime? dateproce { get; set; }

		[DataMember]
		public DateTime? fecsistema { get; set; }

		[DataMember]
		public decimal? soles { get; set; }

		[DataMember]
		public decimal? precio { get; set; }

		[DataMember]
		public decimal? galones { get; set; }

		[DataMember]
		public string documento { get; set; }

		[DataMember]
		public long? c_interno { get; set; }

		[DataMember]
		public string controlador { get; set; }

		[DataMember]
		public string numero { get; set; }

		[DataMember]
		public string producto { get; set; }

		[DataMember]
		public string cara { get; set; }

		[DataMember]
		public string turno { get; set; }

		[DataMember]
		public string estado { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

	}
}
