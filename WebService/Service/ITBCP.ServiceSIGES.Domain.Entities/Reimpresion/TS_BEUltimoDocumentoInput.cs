using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Reimpresion
{
    [DataContract]
    public class TS_BEUltimoDocumentoInput
    {

        [DataMember(IsRequired = true)]
        public string nropos { get; set; }
        [DataMember(IsRequired = true)]
        public bool imprimir { get; set; }


        public string nroseriemaq { get; set; }
        public string cdtipodoc { get; set; }
        public string nrodocumento { get; set; }


        public string Mensaje {get;set;}
        public bool Ok { get; set; }


    }
}
