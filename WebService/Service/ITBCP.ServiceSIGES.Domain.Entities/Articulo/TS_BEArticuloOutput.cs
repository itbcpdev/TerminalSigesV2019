using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Articulo
{
 
    public class TS_BEArticuloOutput
    {

        [DataMember]
        public List<TS_BEArticulo> Articulos { get; set; }
        [DataMember]
        public  bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
