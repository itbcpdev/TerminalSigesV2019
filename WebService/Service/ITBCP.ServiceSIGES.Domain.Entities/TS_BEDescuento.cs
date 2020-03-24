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
	/// <summary> Entidad = Descuento</summary>
	///
	public class TS_BEDescuento
	{

		[DataMember]
		public decimal? nroitem { get; set; }

		[DataMember]
		public decimal? cantidad1 { get; set; }

		[DataMember]
		public decimal? cantidad2 { get; set; }

		[DataMember]
		public decimal? porcentaje { get; set; }

		[DataMember]
		public decimal? descuento { get; set; }

		[DataMember]
		public string cdarticulo { get; set; }

        [DataMember]
        public decimal? cantidad { get; set; }

    }
}
