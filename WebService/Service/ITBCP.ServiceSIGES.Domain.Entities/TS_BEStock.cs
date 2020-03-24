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
	/// <summary> Entidad = Stock</summary>
	///
	public class TS_BEStock
	{

		[DataMember]
		public DateTime? fecinicial { get; set; }

		[DataMember]
		public DateTime? fecinventario { get; set; }

		[DataMember]
		public DateTime? fecingreso { get; set; }

		[DataMember]
		public DateTime? fecsalida { get; set; }

		[DataMember]
		public DateTime? fecventa { get; set; }

		[DataMember]
		public bool? is_recalculo { get; set; }

		[DataMember]
		public decimal? stockinicial { get; set; }

		[DataMember]
		public decimal? ctoinicial { get; set; }

		[DataMember]
		public decimal? stockinventario { get; set; }

		[DataMember]
		public decimal? ctoinventario { get; set; }

		[DataMember]
		public decimal? stockminimo { get; set; }

		[DataMember]
		public decimal? stockactual { get; set; }

		[DataMember]
		public decimal? stockseparado { get; set; }

		[DataMember]
		public decimal? stockmaximo { get; set; }

		[DataMember]
		public decimal? ctoreposicion { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string cdalmacen { get; set; }

		[DataMember]
		public string cdarticulo { get; set; }

		[DataMember]
		public string talla { get; set; }

		[DataMember]
		public string monctoinicial { get; set; }

		[DataMember]
		public string monctoinventario { get; set; }

		[DataMember]
		public string monctorepo { get; set; }

		[DataMember]
		public string usuingreso { get; set; }

		[DataMember]
		public string ususalida { get; set; }

		[DataMember]
		public string usuventa { get; set; }

        [DataMember]
        public decimal cantidad { get; set; }
    }
}
