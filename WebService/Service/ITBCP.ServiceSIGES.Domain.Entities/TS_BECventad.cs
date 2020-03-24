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
	/// <summary> Entidad = Cventad</summary>
	///
	public class TS_BECventad
	{

		[DataMember]
		public DateTime? fecha { get; set; }
        public string nropos { get; set; }
        [DataMember]
        public Decimal? precio { get; set; }
        [DataMember]
        public decimal cantidad { get; set; }
        [DataMember]
        public decimal mtototal { get; set; }
        [DataMember]
        public string glosa { get; set; }
        [DataMember]
        public string cdunimed { get; set; }

    }
}
