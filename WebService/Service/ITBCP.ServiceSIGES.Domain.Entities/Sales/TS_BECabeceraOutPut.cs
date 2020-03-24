using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Sales
{
    [DataContract]
    public class TS_BECabeceraOutPut
    {
        /** 
         * 1 ERROR GENERAL
         * 2 ERROR DESCUENTOS 
         * 3 ERROR TABLAS DBF
         * 4 SIN TRANSACCIONES
         * 5 SIN CONEXION DISPENSADO
         * 6 TERMINAL SIN CONEXION DISPENSADOR
        **/
        [DataMember]
        public int Estado { get; set; }
        public TS_BECabeceraOutPut()
        {
            this.Ok = false;
            this.Mensaje = "";
            this.cDetalleOutPut = new List<TS_BEArticulo>();
        }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
        [DataMember]
        public List<TS_BEArticulo> cDetalleOutPut { get; set; }

    }
}
