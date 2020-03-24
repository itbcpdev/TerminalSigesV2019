using ITBCP.ServiceSIGES.Domain.Entities.Articulo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cliente
{

   public class TS_BEClienteOutput
    {
        public TS_BEClienteOutput() { }
        public TS_BEClienteOutput(string Mensaje, bool Ok,bool flgsaldo)
        {
            this.Mensaje = Mensaje;
            this.Ok = Ok;
            if (flgsaldo)
            {
                this.Saldos = new TS_BESaldos() { Mensaje = Mensaje, Ok = Ok };
            } 
        }
        public TS_BEClienteOutput(TS_BEClienteCreditoOutput cSaldocli,TS_BEMensaje mensaje,string tipocli)
        {
            this.Mensaje = "";
            this.Ok = mensaje.Ok;
            this.Saldos = new TS_BESaldos(cSaldocli, mensaje);
            this.cdcliente = (cSaldocli.cdcliente ?? "").Trim();
            this.ruccliente = (cSaldocli.ruc ?? "").Trim();
            this.rscliente = (cSaldocli.razonsocial ?? "").Trim();
            this.drcliente = (cSaldocli.direccion ?? "").Trim();
            this.nroPlaca = (cSaldocli.nroplaca ?? "").Trim();
            this.NroBonus = (cSaldocli.nrobonus ?? "").Trim();
            this.nroTarjeta = (cSaldocli.nrotarjeta ?? "").Trim();
            this.tipocli = (tipocli ?? "").Trim();
        }

        [DataMember]
        public bool? flg_pideclave { get; set; }
        [DataMember]
        public string cdcliente { get; set; }
        [DataMember]
        public string ruccliente { get; set; }
        [DataMember]
        public string rscliente { get; set; }
        [DataMember]
        public string drcliente { get; set; }
        [DataMember]
        public string tipocli { get; set; }
        [DataMember]
        public string nroTarjeta { get; set; }
        [DataMember]
        public string nroPlaca { get; set; }
        [DataMember]
        public string NroBonus { get; set; }
        [DataMember]
        public TS_BESaldos Saldos { get; set; }
        [DataMember]
        public List<TS_BEArticulo> ArticulosTarjeta { get; set; }
        [DataMember]
        public List<TS_BEArticulo> ArticulosPrefijo { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }


        public bool cmdserafin { get; set; }
        public string lbl_documento { get; set; }
        public byte? sunat_actualiza { get; set; }
        public int? diascredito { get; set; }
        public int? diasmax_nd { get; set; }
        public DateTime? fecnacimiento { get; set; }
        public DateTime? fecha_creacion { get; set; }
        public bool? bloqcredito { get; set; }
        public bool? flgpreciond { get; set; }
        public bool? consulta_sunat { get; set; }
        public string cddistrito { get; set; }
        public string cddepartamento { get; set; }
        public string monlimite { get; set; }
        public string emcliente { get; set; }
        public string cdalmacen { get; set; }
        public string cdgrupocli { get; set; }
        public string gruporuta { get; set; }
        public string cdzona { get; set; }
        public string drcobranza { get; set; }
        public string drentrega { get; set; }
        public string tlfcliente { get; set; }
        public string tlfcliente1 { get; set; }
        public string faxcliente { get; set; }
        public decimal mtodisminuir { get; set; }
        public bool? flgtotalnd { get; set; }
        public decimal? mtolimite { get; set; }
        public decimal? mtodisponible { get; set; }
        public string cliente { get; set; }
        public string contacto { get; set; }
        public bool bloqueado { get; set; }
        public bool baja { get; set; }
        public bool isafiliacion { get; set; }
        public int puntos { get; set; }
        public decimal valoracumula { get; set; }
        public string tarjafiliacion { get; set; }
        public bool flgmostrarsaldo { get; set; }
    }
}
