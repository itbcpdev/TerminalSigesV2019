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
	/// <summary> Entidad = Cierre</summary>
	///
	public class TS_BECierre
	{

		[DataMember]
		public bool flggrupo01 { get; set; }

		[DataMember]
		public bool flggrupo02 { get; set; }

		[DataMember]
		public bool flggrupo03 { get; set; }

		[DataMember]
		public bool flggrupo04 { get; set; }

		[DataMember]
		public bool flggrupo05 { get; set; }

		[DataMember]
		public bool flgvendedor { get; set; }

		[DataMember]
		public bool flgdesc { get; set; }

		[DataMember]
		public bool flgarticulodesc { get; set; }

		[DataMember]
		public bool flgdepositogrifero { get; set; }

		[DataMember]
		public bool flgconsolidarlados { get; set; }

		[DataMember]
		public bool flggastogrifero { get; set; }

		[DataMember]
		public bool flgarticulo { get; set; }

		[DataMember]
		public bool flgpago { get; set; }

		[DataMember]
		public bool flgcara { get; set; }

		[DataMember]
		public bool flgdocmanual { get; set; }

		[DataMember]
		public bool flgusuario { get; set; }

		[DataMember]
		public bool flgcanjearticulo { get; set; }

		[DataMember]
		public string cdcierre { get; set; }
        [DataMember]
        public bool flgstcknegativo { get; set; }

	}
}
