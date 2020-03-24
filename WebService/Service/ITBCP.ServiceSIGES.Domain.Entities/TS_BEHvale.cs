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
    /// <summary> Entidad = Hvale</summary>
    ///
    public class TS_BEHvale
    {

        [DataMember]
        public DateTime? fecvale { get; set; }

        [DataMember]
        public DateTime? fecdocumento { get; set; }

        [DataMember]
        public DateTime? fecproceso { get; set; }

        [DataMember]
        public DateTime? fecdocumentofac { get; set; }

        [DataMember]
        public DateTime? fecprocesofac { get; set; }

        [DataMember]
        public bool? archturno { get; set; }

        [DataMember]
        public decimal? mtovale { get; set; }

        [DataMember]
        public decimal? turno { get; set; }

        [DataMember]
        public string nrovale { get; set; }

        [DataMember]
        public string cdmoneda { get; set; }

        [DataMember]
        public string cdcliente { get; set; }

        [DataMember]
        public string nroplaca { get; set; }

        [DataMember]
        public string nroseriemaq { get; set; }

        [DataMember]
        public string cdtipodoc { get; set; }

        [DataMember]
        public string nrodocumento { get; set; }

        [DataMember]
        public string nroseriemaqfac { get; set; }

        [DataMember]
        public string cdtipodocfac { get; set; }

        [DataMember]
        public string nrodocumentofac { get; set; }

        [DataMember]
        public string placa { get; set; }

        [DataMember]
        public string docvale { get; set; }

    }
}
