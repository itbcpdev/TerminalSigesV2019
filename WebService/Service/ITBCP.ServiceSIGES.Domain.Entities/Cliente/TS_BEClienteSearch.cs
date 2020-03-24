using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cliente
{
    [DataContract]
    public class TS_BEClienteSearch
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public bool flagBusquedaSunat { get; set; }
        [DataMember]
        public string NroTarjeta { get; set; }
        [DataMember]
        public bool IsArticulo { get; set; }
        [DataMember]
        public string PrefijoAfiliacion { get; set; }
        public string Ruc { get; set; }
        

    }
}
