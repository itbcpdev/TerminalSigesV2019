using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    //Creado por     : Teòfilo Chambilla Aquino (02/02/2019)
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    /// <summary> Entidad = Retorno </summary>
    [DataContract]
    public class Retorno
    {
        [DataMember]
        public object RetVal { get; set; }
        [DataMember]
        public object AuxVal { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Valido { get; set; }
        [DataMember]
        public Nullable<bool> Ok { get; set; }
        [DataMember]
        public Nullable<int> NoMensaje { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}
