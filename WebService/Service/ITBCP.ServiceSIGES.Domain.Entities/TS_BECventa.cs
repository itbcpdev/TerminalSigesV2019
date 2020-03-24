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
	/// <summary> Entidad = Cventa</summary>
	///
	public class TS_BECventa
	{

		[DataMember]
		public DateTime? fecha { get; set; }

        [DataMember]
        public string nroseriemaq { get; set; }
        [DataMember]
        public string cdtipodoc { get; set; }
        [DataMember]
        public string nrodocumento { get; set; }
        [DataMember]
        public string fechaemision { get; set; }
        [DataMember]
        public string horaemision { get; set; }
        [DataMember]
        public string nropos { get; set; }
        [DataMember]
        public decimal mtovueltosol { get; set; }
        [DataMember]
        public decimal mtovueltodol { get; set; }
        [DataMember]
        public string cdcliente { get; set; }
        [DataMember]
        public string ruccliente { get; set; }
        [DataMember]
        public string rscliente { get; set; }
        [DataMember]
        public string drcliente { get; set; }
        [DataMember]
        public string cdmoneda { get; set; }
        [DataMember]
        public decimal valorvta { get; set; }
        [DataMember]
        public decimal mtodscto { get; set; }
        [DataMember]
        public decimal mtosubtotal { get; set; }
        [DataMember]
        public decimal mtoimpuesto { get; set; }
        [DataMember]
        public decimal? mtototal { get; set; }
        [DataMember]
        public string nroplaca { get; set; }
        [DataMember]
        public string cdusuario { get; set; }
        [DataMember]
        public string anulado { get; set; }
        [DataMember]
        public string observacion { get; set; }
        [DataMember]
        public string turno { get; set; }
        [DataMember]
        public string nrotarjeta { get; set; }
        [DataMember]
        public string odometro { get; set; }
        [DataMember]
        public string nrolicencia { get; set; }
        [DataMember]
        public string tipoventa { get; set; }
        [DataMember]
        public string nrocelular { get; set; }
        [DataMember]
        public string ptosganados { get; set; }
        [DataMember]
        public decimal precio_orig { get; set; }
        [DataMember]
        public string cdruta { get; set; }
        [DataMember]
        public string codes { get; set; }
        [DataMember]
        public string codeid { get; set; }
        [DataMember]
        public string cdhash { get; set; }
        [DataMember]
        public string scop { get; set; }
        [DataMember]
        public string nroguia { get; set; }
        [DataMember]
        public decimal redondea_indecopi { get; set; }
        [DataMember]
        public string cdmedio_pago { get; set; }
        [DataMember]
        public string montotexto { get; set; }
        [DataMember]
        public string lado { get; set; }
        [DataMember]
        public string nrobonus { get; set; }
        [DataMember]
        public string cdtranspor { get; set; }

    }
}
