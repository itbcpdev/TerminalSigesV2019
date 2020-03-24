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
	/// <summary> Entidad = Afiliacionptos</summary>
	///
	public class TS_BEAfiliacionptos
	{

		[DataMember]
		public byte? item { get; set; }

		[DataMember]
		public DateTime? fecproceso { get; set; }

		[DataMember]
		public DateTime? fecha { get; set; }

		[DataMember]
		public bool? enviado { get; set; }

		[DataMember]
		public decimal? total { get; set; }

		[DataMember]
		public decimal? cantidad { get; set; }

		[DataMember]
		public decimal? puntos { get; set; }

		[DataMember]
		public decimal? canjeados { get; set; }

		[DataMember]
		public decimal? valoracumula { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string tarjafiliacion { get; set; }

		[DataMember]
		public string tipo { get; set; }

		[DataMember]
		public string nropos { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string cdproducto { get; set; }

		[DataMember]
		public string estado { get; set; }

		[DataMember]
		public string cdusuario { get; set; }

		[DataMember]
		public string tarjafiliacion_traspaso { get; set; }

	}
}
