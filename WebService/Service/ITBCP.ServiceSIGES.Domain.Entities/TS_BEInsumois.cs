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
	//Creado por     : Ronald Noé Saavedra Bances (02/03/2019)
	//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
	/// <summary> Entidad = Insumois201601</summary>
	///
	public class TS_BEInsumois
	{

		[DataMember]
		public DateTime? fecproceso { get; set; }

		[DataMember]
		public DateTime? fecdocumento { get; set; }

		[DataMember]
		public DateTime? fecsistema { get; set; }

		[DataMember]
		public bool? flganulacion { get; set; }

		[DataMember]
		public decimal? nroitem { get; set; }

		[DataMember]
		public decimal? cantidad { get; set; }

		[DataMember]
		public decimal? ctoreposicion { get; set; }

		[DataMember]
		public decimal? ctopromedio { get; set; }

		[DataMember]
		public decimal? tcambio { get; set; }

		[DataMember]
		public decimal? precio { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string nroseriemaq { get; set; }

		[DataMember]
		public string cdtpmov { get; set; }

		[DataMember]
		public string nromov { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string movimiento { get; set; }

		[DataMember]
		public string cdalmacen { get; set; }

		[DataMember]
		public string cdarticulo { get; set; }

		[DataMember]
		public string talla { get; set; }

		[DataMember]
		public string monctorepo { get; set; }

	}
}
