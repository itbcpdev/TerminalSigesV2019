using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cierrres.ZObjetos
{
    [DataContract]
    public class TS_BEZCara
    {
        [DataMember]
        public string cara;
        [DataMember]
        public decimal descuentos;
        [DataMember]
        public decimal gratuito;
        [DataMember]
        public decimal total;
    }
}
