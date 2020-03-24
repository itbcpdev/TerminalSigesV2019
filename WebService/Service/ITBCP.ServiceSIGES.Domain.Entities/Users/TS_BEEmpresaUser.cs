using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Users
{
    [DataContract]
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    //Creado por     : Teòfilo Chambilla Aquino (26/01/2019)
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    /// <summary> Entidad = [tab0s01  INNER JOIN tab1s99] </summary>
    /// 
    public class TS_BEEmpresaUser
    {
        [DataMember]
        public string cdempresa { get; set; }
        [DataMember]
        public string dsempresa { get; set; }
        [DataMember]
        public string drempresa { get; set; }
        [DataMember]
        public string conexion { get; set; }
        [DataMember]
        public string rucempresa { get; set; }
        [DataMember]
        public string cdnivel { get; set; }
        [DataMember]
        public string facturacion_electronica { get; set; }
    }
}
