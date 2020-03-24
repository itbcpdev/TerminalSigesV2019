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
	/// <summary> Entidad = Saldoclid</summary>
	///
	public class TS_BESaldoclid
	{

		[DataMember]
		public DateTime? fechaatencion { get; set; }

		[DataMember]
		public bool? flgilimit { get; set; }

		[DataMember]
		public bool? flgbloquea { get; set; }

		[DataMember]
		public bool? enviado { get; set; }

		[DataMember]
		public decimal? limitemto { get; set; }

		[DataMember]
		public decimal? consumto { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string cdcliente { get; set; }

		[DataMember]
		public string nrotarjeta { get; set; }

		[DataMember]
		public string cdgrupo02 { get; set; }

		[DataMember]
		public string cdarticulo { get; set; }

		[DataMember]
		public string nrobonus { get; set; }

		[DataMember]
		public string nroplaca { get; set; }

		[DataMember]
		public string tipodespacho { get; set; }

		[DataMember]
		public string clave { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
