using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Reimpresion
{
    [DataContract]
    public class TS_BEReimpresionLOutput
    {
        public TS_BEReimpresionLOutput(){}
        public TS_BEReimpresionLOutput(TS_BEMensaje Mensaje)
        {
            this.Mensaje = Mensaje;
        }
        public TS_BEReimpresionLOutput(TS_BEMensaje Mensaje, List<TS_BEReimpresionL> Documentos)
        {
            this.Mensaje = Mensaje;
            this.Documentos = Documentos;
        }

        [DataMember]
        public List<TS_BEReimpresionL> Documentos { get; set; }
        [DataMember]
        public TS_BEMensaje Mensaje { get; set; }
    }
}
