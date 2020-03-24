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
	/// <summary> Entidad = Loteriahora</summary>
	///
	public class TS_BELoteriahora
	{

		[DataMember]
		public bool? flglunes { get; set; }

		[DataMember]
		public bool? flgmartes { get; set; }

		[DataMember]
		public bool? flgmiercoles { get; set; }

		[DataMember]
		public bool? flgjueves { get; set; }

		[DataMember]
		public bool? flgviernes { get; set; }

		[DataMember]
		public bool? flgsabado { get; set; }

		[DataMember]
		public bool? flgdomingo { get; set; }

		[DataMember]
		public bool? flgprod { get; set; }

		[DataMember]
		public decimal? item { get; set; }

		[DataMember]
		public decimal? nroganador { get; set; }

		[DataMember]
		public decimal? mtomax { get; set; }

		[DataMember]
		public decimal? frecuencia { get; set; }

		[DataMember]
		public string horainicio { get; set; }

		[DataMember]
		public string horafin { get; set; }

		[DataMember]
		public string monmto { get; set; }

        [DataMember]
        public string hora { get; set; }

        [DataMember]
        public int dia { get; set; }
    }
}
