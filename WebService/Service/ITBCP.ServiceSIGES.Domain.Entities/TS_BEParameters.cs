using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    //Creado por     : Teòfilo Chambilla Aquino (26/01/2019)
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    /// <summary> Entidad = [tab0s00] </summary>
    /// 
    public class TS_BEParameters
    {
        [DataMember]
        public string monpais { get; set; }
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string path_repo { get; set; }
        [DataMember]
        public string path_formato { get; set; }
        [DataMember]
        public string path_gasboy { get; set; }
        [DataMember]
        public string path_loteria { get; set; }
        [DataMember]
        public double numempresa { get; set; }
        [DataMember]
        public string tpfactura { get; set; }
        [DataMember]
        public string tpboleta { get; set; }
        [DataMember]
        public string tpticket { get; set; }
        [DataMember]
        public string tppromocion { get; set; }
        [DataMember]
        public string tpntavta { get; set; }
        [DataMember]
        public string tpncredito { get; set; }
        [DataMember]
        public string tpndebito { get; set; }
        [DataMember]
        public string tpletra { get; set; }
        [DataMember]
        public string tpletraprot { get; set; }
        [DataMember]
        public string tpguia { get; set; }
        [DataMember]
        public string tpvale { get; set; }
        [DataMember]
        public string tpanticipo { get; set; }
        [DataMember]
        public string tpcheque { get; set; }
        [DataMember]
        public string tpproforma { get; set; }
        [DataMember]
        public string tpseparacion { get; set; }
        [DataMember]
        public string tpcomanda { get; set; }
        [DataMember]
        public string tppedido { get; set; }
        [DataMember]
        public string tppgoefectivo { get; set; }
        [DataMember]
        public string tppgotarjeta { get; set; }
        [DataMember]
        public string tppgocheque { get; set; }
        [DataMember]
        public string tppgocredito { get; set; }
        [DataMember]
        public string tpaplicncred { get; set; }
        [DataMember]
        public string tpaplicantic { get; set; }
        [DataMember]
        public string tppgocanje { get; set; }
        [DataMember]
        public string cdarticulocontable { get; set; }
        [DataMember]
        public string calculoigv { get; set; }
        [DataMember]
        public  bool flgdesgtkfact { get; set; }
        [DataMember]
        public bool flgmolotov { get; set; }
        [DataMember]
        public string path_clicorp { get; set; }
        [DataMember]
        public string path_bonus { get; set; }
        [DataMember]
        public string central { get; set; }
        [DataMember]
        public string path_transfer { get; set; }
        [DataMember]
        public bool cambioturno { get; set; }
        [DataMember]
        public string tppgotransferencia { get; set; }
        [DataMember]
        public string tpticketfac { get; set; }
        [DataMember]
        public string nom_ventaplaya { get; set; }
        [DataMember]
        public string tpcliente_corporativo { get; set; }
        [DataMember]
        public string fe_ipremoto { get; set; }
        [DataMember]
        public string fe_puertoremoto { get; set; }
        [DataMember]
        public string fe_proveedor { get; set; }
        [DataMember]
        public string fe_dbz_rutasuitepos { get; set; }
        [DataMember]
        public string fe_dbz_rutasuitesuc { get; set; }
        [DataMember]
        public string fe_snt_rutaprocesamiento { get; set; }
        [DataMember]
        public string fe_snt_rutafacturador { get; set; }
        [DataMember]
        public string fe_snt_rutagenerador { get; set; }
        [DataMember]
        public string fe_mst_rutawebservice { get; set; }
        [DataMember]
        public string fe_sge_rutawebservice { get; set; }
        [DataMember]
        public string fe_sge_clavecertificado { get; set; }
        [DataMember]
        public string fe_asp_rutaprocesamiento { get; set; }
        [DataMember]
        public string fe_inc_rutaprocesamiento { get; set; }
        [DataMember]
        public Nullable<int> fe_bzl_tiempoespera { get; set; }
        [DataMember]
        public string fe_act_rutaprocesamiento { get; set; }
        [DataMember]
        public string fe_tci_rutaprocesamiento { get; set; }
        [DataMember]
        public string fe_act_ruta_ws { get; set; }
        [DataMember]
        public string fe_act_clave_ws { get; set; }
        [DataMember]
        public string fe_act_ruta_ws_CDR { get; set; }
    }
}
