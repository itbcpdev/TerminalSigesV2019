using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cliente
{
	[DataContract]
	//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
	//Creado por     : Ronald Noé Saavedra Bances (28/01/2019)
	//ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
	/// <summary> Entidad = Cliente</summary>
	///
	public class TS_BECliente
	{

		[DataMember]
		public byte? sunat_actualiza { get; set; }

		[DataMember]
		public int? diascredito { get; set; }

		[DataMember]
		public int? diasmax_nd { get; set; }

		[DataMember]
		public DateTime? fecnacimiento { get; set; }

		[DataMember]
		public DateTime? fecha_creacion { get; set; }

		[DataMember]
		public bool? bloqcredito { get; set; }

		[DataMember]
		public bool? flgpreciond { get; set; }

		[DataMember]
		public bool? consulta_sunat { get; set; }

		[DataMember]
		public bool? flg_pideclave { get; set; }

		[DataMember]
		public bool? flgtotalnd { get; set; }

		[DataMember]
		public decimal? mtolimite { get; set; }

		[DataMember]
		public decimal? mtodisponible { get; set; }

		[DataMember]
		public string cliente { get; set; }

		[DataMember]
		public string contacto { get; set; }

		[DataMember]
		public string cdcliente { get; set; }

		[DataMember]
		public string ruccliente { get; set; }

		[DataMember]
		public string rscliente { get; set; }

		[DataMember]
		public string drcliente { get; set; }

		[DataMember]
		public string cddistrito { get; set; }

		[DataMember]
		public string cddepartamento { get; set; }

		[DataMember]
		public string monlimite { get; set; }

		[DataMember]
		public string emcliente { get; set; }

		[DataMember]
		public string cdalmacen { get; set; }

		[DataMember]
		public string tipocli { get; set; }

		[DataMember]
		public string cdgrupocli { get; set; }

		[DataMember]
		public string gruporuta { get; set; }

		[DataMember]
		public string cdzona { get; set; }

		[DataMember]
		public string drcobranza { get; set; }

		[DataMember]
		public string drentrega { get; set; }

		[DataMember]
		public string tlfcliente { get; set; }

		[DataMember]
		public string tlfcliente1 { get; set; }

		[DataMember]
		public string faxcliente { get; set; }

        [DataMember]
        public decimal mtodisminuir { get; set; }
        [DataMember]
        public string nroTarjeta { get; set; }
       
    }
}
