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
	/// <summary> Entidad = Cnfgvalorpunto</summary>
	///
	public class TS_BEConceptoVariables
    {

		[DataMember]
		public int? valorid { get; set; }

		[DataMember]
		public int? prefijocard { get; set; }

		[DataMember]
		public int? concepto { get; set; }

		[DataMember]
		public int? tipopunto { get; set; }

		[DataMember]
		public double? valorpunto { get; set; }

		[DataMember]
		public bool? status { get; set; }

		[DataMember]
		public string descripcion { get; set; }

		[DataMember]
		public string tipoacumula { get; set; }

		[DataMember]
		public string tipocanje { get; set; }

		[DataMember]
		public string conceptos_prefijo { get; set; }

        //Variables
        [DataMember]
        public int? varid { get; set; }

        [DataMember]
        public double? valorpto { get; set; }

        [DataMember]
        public bool? flgelimina { get; set; }

        [DataMember]
        public string tipovar { get; set; }

        [DataMember]
        public string clave { get; set; }

        [DataMember]
        public string TipoAA { get; set; }

        [DataMember]
        public string config { get; set; }

        [DataMember]
        public string valor { get; set; }

    }
}
