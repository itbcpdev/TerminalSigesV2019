using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEEmisor
    {
        [DataMember]
        public string cdempresa { get; set; }
        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Departamento { get; set; }
        [DataMember]
        public string Provincia { get; set; }
        [DataMember]
        public string Distrito { get; set; }
        [DataMember]
        public string Urbanizacion { get; set; }
        [DataMember]
        public string Ubigeo { get; set; }

        /*Datos de la sucursal*/

        [DataMember]
        public string nombre_sucursal { get; set; }

        [DataMember]
        public string direccion_sucursal { get; set; }

        [DataMember]
        public string provincia_sucursal { get; set; }

        [DataMember]
        public string nroautorizacion { get; set; }

        [DataMember]
        public bool isSucursal { get; set; }
        [DataMember]
        public string detallesempresa { get; set; }

    }
}
