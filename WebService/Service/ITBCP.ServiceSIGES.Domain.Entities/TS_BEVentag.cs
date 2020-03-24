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
	/// <summary> Entidad = Ventag</summary>
	///
	public class TS_BEVentag
	{

		[DataMember]
		public DateTime? fecdocumento { get; set; }

		[DataMember]
		public DateTime? fecproceso { get; set; }

		[DataMember]
		public DateTime? fecanula { get; set; }

		[DataMember]
		public DateTime? fecanulasis { get; set; }

		[DataMember]
		public bool? declarado { get; set; }

		[DataMember]
		public bool? anulado { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string nroseriemaq { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string nropos { get; set; }

		[DataMember]
		public string cdcliente { get; set; }

        /*Agregado para distingir la tabla a la cual esta ubicada la venta*/
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public TS_BEMensaje Mensaje { get; set; }

    }
}
