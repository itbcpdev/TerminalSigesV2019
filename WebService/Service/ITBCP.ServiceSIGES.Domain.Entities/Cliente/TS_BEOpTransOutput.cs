using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cliente
{
   public  class TS_BEOpTransOutput
    {
        [DataMember]
        public string manguera { get; set; }

        [DataMember]
        public DateTime? fecha { get; set; }

        [DataMember]
        public DateTime? orden { get; set; }

        [DataMember]
        public string hora { get; set; }

        [DataMember]
        public DateTime? dateproce { get; set; }

        [DataMember]
        public DateTime? fecsistema { get; set; }

        [DataMember]
        public decimal soles { get; set; }

        [DataMember]
        public decimal precio { get; set; }

        [DataMember]
        public decimal galones { get; set; }

        [DataMember]
        public decimal? documento { get; set; }

        [DataMember]
        public long? c_interno { get; set; }

        [DataMember]
        public string controlador { get; set; }

        [DataMember]
        public string numero { get; set; }

        [DataMember]
        public string producto { get; set; }

        [DataMember]
        public string cara { get; set; }

        [DataMember]
        public string turno { get; set; }

        [DataMember]
        public string estado { get; set; }

        [DataMember]
        public string cdtipodoc { get; set; }

        [DataMember]
        public bool conexiondispensador { get; set; }

        [DataMember]
        public decimal ArtImpuesto { get; set; }

        [DataMember]
        public string ArtDsarticulo { get; set; }

        [DataMember]
        public bool ArtMoverstock { get; set; }

        [DataMember]
        public string ArtDsarticulo1 { get; set; }

        [DataMember]
        public decimal ArtPorcpercepcion { get; set; }

        [DataMember]
        public string ArtCdgrupo01 { get; set; }

        [DataMember]
        public string ArtMonctorepo { get; set; }

        [DataMember]
        public decimal ArtCtoreposicion { get; set; }

        [DataMember]
        public string ArtTpconversion { get; set; }

        [DataMember]
        public decimal ArtValorconversion { get; set; }

        [DataMember]
        public bool ArtTrfgratuita { get; set; }

        [DataMember]
        public string ArtCdunimed { get; set; }

        [DataMember]
        public string ArtCdarticulosunat { get; set; }

        [DataMember]
        public bool Ok { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
}
