using System.Runtime.Serialization;

namespace ITBCP.ServiceSIGES.Domain.Entities.Users
{
    [DataContract]
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    //Creado por     : Teòfilo Chambilla Aquino (26/01/2019)
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    /// <summary> Entidad = [[tab0s02]] </summary>
    /// 
    public class TS_BEUsers
    {
        [DataMember]
        public string cdusuario { get; set; }
        [DataMember]
        public string dsusuario { get; set; }
        [DataMember]
        public string drusuario { get; set; }
        [DataMember]
        public string rucusuario { get; set; }
        [DataMember]
        public string tlfusuario { get; set; }
        [DataMember]
        public string tlfusuario1 { get; set; }
        [DataMember]
        public double password    { get; set; }
        [DataMember]
        public bool flgdscto   { get; set; }
        [DataMember]
        public bool flgborraritem { get; set; }
        [DataMember]
        public bool flganular { get; set; }
        [DataMember]
        public string cdnivel { get; set; }
        [DataMember]
        public bool flgTurno { get; set; }
        [DataMember]
        public bool flgCierreX { get; set; }
        [DataMember]
        public bool flgCierreZ { get; set; }
    }
}
