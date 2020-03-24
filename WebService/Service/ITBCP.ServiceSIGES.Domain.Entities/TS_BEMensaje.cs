using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEMensaje
    {
        [DataMember]
        public string mensaje { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        public TS_BEMensaje() { this.mensaje = "";this.Ok = false; }
        public TS_BEMensaje(string mensaje, bool Ok)
        {
            this.mensaje = mensaje;
            this.Ok = Ok;
        }


    }
}
