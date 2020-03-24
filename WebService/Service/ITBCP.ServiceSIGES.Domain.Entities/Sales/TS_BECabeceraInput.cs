using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BECabeceraInput
    {
        //[DataMember]
        //public string cdlocal { get; set; }
        //[DataMember]
        //public string nroseriemaq { get; set; }
        //[DataMember]
        //public string cdtipodoc { get; set; }
        //[DataMember]
        //public string nrodocumento { get; set; }
        //[DataMember]
        //public DateTime fecdocumento { get; set; }
        //[DataMember]
        //public DateTime fecproceso { get; set; }
        //[DataMember]
        //public DateTime fecsistema { get; set; }
        //[DataMember]
        //public string nropos { get; set; }
        //[DataMember]
        //public decimal mtovueltosol { get; set; }
        //[DataMember]
        //public decimal mtovueltodol { get; set; }
        //[DataMember]
        //public string cdalmacen { get; set; }
        //[DataMember]
        //public string cdcliente { get; set; }
        //[DataMember]
        //public string ruccliente { get; set; }
        //[DataMember]
        //public string rscliente { get; set; }
        //[DataMember]
        //public string nroproforma { get; set; }
        //[DataMember]
        //public string cdprecio { get; set; }
        //[DataMember]
        //public string cdmoneda { get; set; }
        //[DataMember]
        //public decimal porservicio { get; set; }
        //[DataMember]
        //public decimal pordscto1 { get; set; }
        //[DataMember]
        //public decimal pordscto2 { get; set; }
        //[DataMember]
        //public decimal pordscto3 { get; set; }
        //[DataMember]
        //public decimal pordsctoeq { get; set; }
        //[DataMember]
        //public decimal mtonoafecto { get; set; }
        //[DataMember]
        //public decimal valorvta { get; set; }
        //[DataMember]
        //public decimal mtodscto { get; set; }
        //[DataMember]
        //public decimal mtosubtotal { get; set; }
        //[DataMember]
        //public decimal mtoservicio { get; set; }
        //[DataMember]
        //public decimal mtoimpuesto { get; set; }
        //[DataMember]
        //public decimal mtototal { get; set; }
        //[DataMember]
        //public string cdtranspor { get; set; }
        //[DataMember]
        //public string ructranspor { get; set; }
        //[DataMember]
        //public string nroplaca { get; set; }
        //[DataMember]
        //public string drpartida { get; set; }
        //[DataMember]
        //public string marcavehic { get; set; }
        //[DataMember]
        //public string drdestino { get; set; }
        //[DataMember]
        //public string cdusuario { get; set; }
        //[DataMember]
        //public string cdvendedor { get; set; }
        //[DataMember]
        //public string cdusuanula { get; set; }
        //[DataMember]
        //public DateTime? fecanula { get; set; }
        //[DataMember]
        //public DateTime? fecanulasis { get; set; }
        //[DataMember]
        //public string tipofactura { get; set; }
        //[DataMember]
        //public bool flgmanual { get; set; }
        //[DataMember]
        //public decimal tcambio { get; set; }
        //[DataMember]
        //public string nroocompra { get; set; }
        //[DataMember]
        //public bool flgcierrez { get; set; }
        //[DataMember]
        //public string observacion { get; set; }
        //[DataMember]
        //public bool flgmovimiento { get; set; }
        //[DataMember]
        //public string referencia { get; set; }
        //[DataMember]
        //public string nroserie1 { get; set; }
        //[DataMember]
        //public string nroserie2 { get; set; }
        //[DataMember]
        //public string turno { get; set; }
        //[DataMember]
        //public string NroBonus { get; set; }
        //[DataMember]
        //public string nrotarjeta { get; set; }
        //[DataMember]
        //public string odometro { get; set; }
        //[DataMember]
        //public string archturno { get; set; }
        //[DataMember]
        //public decimal mtorecaudo { get; set; }
        //[DataMember]
        //public string inscripcion { get; set; }
        //[DataMember]
        //public string chofer { get; set; }
        //[DataMember]
        //public string nrolicencia { get; set; }
        //[DataMember]
        //public bool chkespecial { get; set; }
        //[DataMember]
        //public string TipoVenta { get; set; }
        //[DataMember]
        //public string nrocelular { get; set; }
        //[DataMember]
        //public int PtosGanados { get; set; }
        //[DataMember]
        //public decimal precio_orig { get; set; }
        //[DataMember]
        //public bool rucinvalido { get; set; }
        //[DataMember]
        //public bool usadecimales { get; set; }
        //[DataMember]
        //public string TipoAcumula { get; set; }
        //[DataMember]
        //public decimal ValorAcumula { get; set; }
        //[DataMember]
        //public string c_centralizacion { get; set; }
        //[DataMember]
        //public decimal cantcupon { get; set; }
        //[DataMember]
        //public decimal mtocanje { get; set; }
        //[DataMember]
        //public decimal MtoPercepcion { get; set; }
        //[DataMember]
        //public string cdruta { get; set; }
        //[DataMember]
        //public string Codes { get; set; }
        //[DataMember]
        //public string codeID { get; set; }
        //[DataMember]
        //public string mensaje1 { get; set; }
        //[DataMember]
        //public string mensaje2 { get; set; }
        //[DataMember]
        //public string pdf417 { get; set; }//meno
        //[DataMember]
        //public string cdhash { get; set; }
        //[DataMember]
        //public string scop { get; set; }
        //[DataMember]
        //public string nroguia { get; set; }
        //[DataMember]
        //public decimal mtodetraccion { get; set; }
        //[DataMember]
        //public decimal porcdetraccion { get; set; }
        //[DataMember]
        //public string ctadetraccion { get; set; }
        //[DataMember]
        //public bool fact_elect { get; set; }
        //[DataMember]
        //public double redondea_indecopi { get; set; }
        //[DataMember]
        //public string cdMedio_pago { get; set; }

        [DataMember]
        public string cdtipodoc { get; set; }
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
        public string nroplaca { get; set; }
        [DataMember]
        public string cdusuario { get; set; }
        [DataMember]
        public string dsusuario { get; set; }
        [DataMember]
        public string cdvendedor { get; set; }
        [DataMember]
        public string observacion { get; set; }
        [DataMember]
        public string nrotarjeta { get; set; }
        [DataMember]
        public string odometro { get; set; }
        [DataMember]
        public string chofer { get; set; }
        [DataMember]
        public string TipoVenta { get; set; }
        [DataMember]
        public string cdmoneda { get; set; }
        [DataMember]
        public decimal redondea_indecopi { get; set; }
    }
}
