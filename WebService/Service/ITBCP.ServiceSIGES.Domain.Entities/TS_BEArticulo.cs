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
	/// <summary> Entidad = Articulo</summary>
	///
	public class TS_BEArticulo
	{
        [DataMember]
        public int valorid { get; set; }
        [DataMember]
        public int item { get; set; }
        [DataMember]
        public string hora { get; set; }
        [DataMember]
        public string tipo { get; set; }
        [DataMember]
        public string cdarticulo { get; set; }
        [DataMember]
        public string dsarticulo { get; set; }
        [DataMember]
        public decimal precio { get; set; }
        [DataMember]
        public decimal cantidad { get; set; }
        [DataMember]
        public decimal total { get; set; }
        [DataMember]
        public string talla { get; set; }
        [DataMember]
        public decimal pordsctoeq { get; set; }
        [DataMember]
        public decimal mtodscto { get; set; }
        [DataMember]
        public decimal pordscto1 { get; set; }
        [DataMember]
        public decimal pordscto2 { get; set; }
        [DataMember]
        public decimal pordscto3 { get; set; }
        [DataMember]
        public string cdtalla { get; set; }
        [DataMember]
        public decimal mtonoafecto { get; set; }
        [DataMember]
        public decimal valorvta { get; set; }
        [DataMember]
        public decimal impuesto { get; set; }
        [DataMember]
        public decimal mtoservicio { get; set; }
        [DataMember]
        public decimal mtoimpuesto { get; set; }
        [DataMember]
        public decimal subtotal { get; set; }
        [DataMember]
        public string tpformula { get; set; }
        [DataMember]
        public bool moverstock { get; set; }
        [DataMember]
        public bool vtaxmonto { get; set; }
        [DataMember]
        public string dsarticulo1 { get; set; }
        [DataMember]
        public string cara { get; set; }
        [DataMember]
        public string manguera { get; set; }
        [DataMember]
        public string nrogasboy { get; set; }
        [DataMember]
        public string cdgrupo01 { get; set; }
        [DataMember]
        public bool movimiento { get; set; }
        [DataMember]
        public string glosa { get; set; }
        [DataMember]
        public decimal costo { get; set; }
        [DataMember]
        public decimal cantidad2 { get; set; }
        [DataMember]
        public decimal precio2 { get; set; }
        [DataMember]
        public string cdunimed { get; set; }
        [DataMember]
        public bool usadecimales { get; set; }
        [DataMember]
        public bool trfgratuita { get; set; }
        [DataMember]
        public decimal origsoles { get; set; }
        [DataMember]
        public decimal precio_orig { get; set; }
        [DataMember]
        public decimal ptosganados { get; set; }
        [DataMember]
        public string tipoacumula { get; set; }
        [DataMember]
        public decimal valoracumula { get; set; }
        [DataMember]
        public string tiposuma { get; set; }
        [DataMember]
        public decimal costo_venta { get; set; }
        [DataMember]
        public decimal precioafiliacion { get; set; }
        [DataMember]
        public bool rev_promo { get; set; }
        [DataMember]
        public decimal porcpercepcion { get; set; }
        [DataMember]
        public bool flgpromocion { get; set; }
        [DataMember]
        public decimal mtopercepcion { get; set; }
        [DataMember]
        public string cdpack { get; set; }
        [DataMember]
        public decimal mtodetraccion { get; set; }
        [DataMember]
        public decimal porcdetraccion { get; set; }
        [DataMember]
        public decimal cantidad_orig { get; set; }
        [DataMember]
        public decimal redondea_indecopi { get; set; }
        [DataMember]
        public string cdarticulosunat { get; set; }
        [DataMember]
        public string turno { get; set; }
        [DataMember]
        public decimal total_display { get; set; }
        [DataMember]
        public DateTime? fecinicial { get; set; }
        [DataMember]
        public DateTime? fecinventario { get; set; }
        [DataMember]
        public DateTime? fecedicion { get; set; }
        [DataMember]
        public bool? bloqvta { get; set; }
        [DataMember]
        public bool? bloqcom { get; set; }
        [DataMember]
        public bool? flgglosa { get; set; }
        [DataMember]
        public bool? venta { get; set; }
        [DataMember]
        public bool? consignacion { get; set; }
        [DataMember]
        public bool is_easytaxi { get; set; }
        [DataMember]
        public bool? bloqgral { get; set; }
        [DataMember]
        public bool? _virtual { get; set; }
        [DataMember]
        public decimal? ctoreposicion { get; set; }
        [DataMember]
        public decimal? impuesto1 { get; set; }
        [DataMember]
        public decimal? ctoinicial { get; set; }
        [DataMember]
        public decimal? ctoinventario { get; set; }
        [DataMember]
        public decimal? ctopromedio { get; set; }
        [DataMember]
        public decimal? mgutilidad { get; set; }
        [DataMember]
        public decimal? montofidelizacion { get; set; }
        [DataMember]
        public decimal? equivalencia { get; set; }
        [DataMember]
        public decimal valorconversion { get; set; }
        [DataMember]
        public decimal? puntosfidelizacion { get; set; }
        [DataMember]
        public decimal? cantfidelizacion { get; set; }
        [DataMember]
        public string c_cuenta { get; set; }
        [DataMember]
        public string c_cuenta_ventas { get; set; }
        [DataMember]
        public string c_centrocosto { get; set; }
        [DataMember]
        public string c_cuenta_compras { get; set; }
        [DataMember]
        public string cdarticulovulcano { get; set; }
        [DataMember]
        public string cdgrupo02 { get; set; }
        [DataMember]
        public string cdgrupo03 { get; set; }
        [DataMember]
        public string ctacompra { get; set; }
        [DataMember]
        public string ctaventa { get; set; }
        [DataMember]
        public string ctacosto { get; set; }
        [DataMember]
        public string ctaalmacen { get; set; }
        [DataMember]
        public string ticketfactura { get; set; }
        [DataMember]
        public string monctoinventario { get; set; }
        [DataMember]
        public string monctoprom { get; set; }
        [DataMember]
        public string monctorepo { get; set; }
        [DataMember]
        public string cdmedequiv { get; set; }
        [DataMember]
        public string cdamarre { get; set; }
        [DataMember]
        public string tpconversion { get; set; }
        [DataMember]
        public string cdgrupo04 { get; set; }
        [DataMember]
        public string cdgrupo05 { get; set; }
        [DataMember]
        public string monctoinicial { get; set; }
        [DataMember]
        public string cdlocal { get; set; }
        [DataMember]
        public string nroseriemaq { get; set; }
        [DataMember]
        public string cdtipodoc { get; set; }
        [DataMember]
        public string nrodocumento { get; set; }
        [DataMember]
        public string cdalterna { get; set; }
        [DataMember]
        public string cdvendedor { get; set; }
        [DataMember]
        public decimal cant_ncredito { get; set; }
        [DataMember]
        public bool flgcierrez { get; set; }
        [DataMember]
        public bool archturno { get; set; }
        [DataMember]
        public decimal mtototal { get; set; }
        [DataMember]
        public bool impuesto_plastico { get; set; }
        [DataMember]
        public decimal monto_impuesto_plastico { get; set; }
        [DataMember]
        public string config { get; set; }
        [DataMember]
        public decimal valor_puntos { get; set; }
        [DataMember]
        public decimal valor_acumulado { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
