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
	/// <summary> Entidad = Ventad</summary>
	///
	public class TS_BEVentad
	{

		[DataMember]
		public string glosa { get; set; }

		[DataMember]
		public DateTime? fecproceso { get; set; }

		[DataMember]
		public DateTime? fecdocumento { get; set; }

		[DataMember]
		public bool? flgcierrez { get; set; }

		[DataMember]
		public bool? moverstock { get; set; }

		[DataMember]
		public bool? archturno { get; set; }

		[DataMember]
		public bool? trfgratuita { get; set; }

		[DataMember]
		public decimal? nroitem { get; set; }

		[DataMember]
		public decimal? impuesto { get; set; }

		[DataMember]
		public decimal? pordscto1 { get; set; }

		[DataMember]
		public decimal? pordscto2 { get; set; }

		[DataMember]
		public decimal? pordscto3 { get; set; }

		[DataMember]
		public decimal? pordsctoeq { get; set; }

		[DataMember]
		public decimal? redondea_indecopi { get; set; }

		[DataMember]
		public decimal? porcdetraccion { get; set; }

		[DataMember]
		public decimal? mtodetraccion { get; set; }

		[DataMember]
		public decimal? precio_orig { get; set; }

		[DataMember]
		public decimal? ptosganados { get; set; }

		[DataMember]
		public decimal? precioafiliacion { get; set; }

		[DataMember]
		public decimal? valoracumula { get; set; }

		[DataMember]
		public decimal? costo_venta { get; set; }

		[DataMember]
		public decimal? mtopercepcion { get; set; }

		[DataMember]
		public decimal? mtosubtotal { get; set; }

		[DataMember]
		public decimal? mtoservicio { get; set; }

		[DataMember]
		public decimal? mtoimpuesto { get; set; }

		[DataMember]
		public decimal? mtototal { get; set; }

		[DataMember]
		public string turno { get; set; }

		[DataMember]
		public decimal? costo { get; set; }

		[DataMember]
		public decimal? cantidad { get; set; }

		[DataMember]
		public decimal? cant_ncredito { get; set; }

		[DataMember]
		public decimal? precio { get; set; }

		[DataMember]
		public decimal? mtonoafecto { get; set; }

		[DataMember]
		public decimal? valorvta { get; set; }

		[DataMember]
		public decimal? mtodscto { get; set; }

		[DataMember]
		public string tiposuma { get; set; }

		[DataMember]
		public string cdpack { get; set; }

		[DataMember]
		public string cdarticulosunat { get; set; }

		[DataMember]
		public string cdlocal { get; set; }

		[DataMember]
		public string nroseriemaq { get; set; }

		[DataMember]
		public string nropos { get; set; }

		[DataMember]
		public string cdtipodoc { get; set; }

		[DataMember]
		public string nrodocumento { get; set; }

		[DataMember]
		public string cdarticulo { get; set; }

		[DataMember]
		public string nroproforma { get; set; }

		[DataMember]
		public string manguera { get; set; }

		[DataMember]
		public string tipoacumula { get; set; }

		[DataMember]
		public string cdalterna { get; set; }

		[DataMember]
		public string talla { get; set; }

		[DataMember]
		public string cdvendedor { get; set; }

		[DataMember]
		public string cara { get; set; }

		[DataMember]
		public string nrogasboy { get; set; }

		[DataMember]
		public string nroguia { get; set; }

        // Pertenece a la tabla Articulo pero se agrego aquí para el filtro
        [DataMember]
        public string cdgrupo02 { get; set; }
        

    }
}
