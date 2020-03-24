using ITBCP.ServiceSIGES.Domain.Entities.Campos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Cliente
{
    [DataContract]
    public class TS_BESaldos
    {
        public TS_BESaldos() { }

        public TS_BESaldos(TS_BEClienteCreditoOutput Saldos, TS_BEMensaje mensaje)
        {
            this.cdcliente = Saldos.cdcliente;
            this.nrotarjeta = Saldos.nrotarjeta;
            this.cdgrupo02 = Saldos.cdgrupo02;
            this.cdarticulo = Saldos.cdarticulo;
            this.limitemto = Saldos.limitemto;
            this.consumto = Saldos.consumto;
            this.nrobonus = Saldos.nrobonus;
            this.nroplaca = Saldos.nroplaca;
            this.flgilimit = Saldos.flgilimit;
            this.flgbloquea = Saldos.flgbloquea;
            this.nrocontrato = Saldos.nrocontrato;
            this.tpsaldo = Saldos.tpsaldo;
            this.consumtoC = Saldos.consumtoC;
            this.flgbloqueaC = Saldos.flgbloqueaC;
            this.limitemtoC = Saldos.limitemtoC;
            this.flgilimitC = Saldos.flgilimitC;
            this.ruc = Saldos.ruc;
            this.razonsocial = Saldos.razonsocial;
            this.direccion = Saldos.direccion;
            this.nrocontrato1 = Saldos.nrocontrato1;
            this.tipodespacho = Saldos.tipodespacho;
            this.cdcliente = Saldos.cdcliente;
            this.nrotarjeta = Saldos.nrotarjeta;
            this.cdgrupo02 = Saldos.cdgrupo02;
            this.cdarticulo = Saldos.cdarticulo;
            this.limitemto = Saldos.limitemto;
            this.consumto = Saldos.consumto;
            this.nrobonus = Saldos.nrobonus;
            this.nroplaca = Saldos.nroplaca;
            this.flgilimit = Saldos.flgilimit;
            this.flgbloquea = Saldos.flgbloquea;
            this.nrocontrato = Saldos.nrocontrato;
            this.tpsaldo = Saldos.tpsaldo;
            this.consumtoC = Saldos.consumtoC;
            this.flgbloqueaC = Saldos.flgbloqueaC;
            this.limitemtoC = Saldos.limitemtoC;
            this.flgilimitC = Saldos.flgilimitC;
            this.ruc = Saldos.ruc;
            this.direccion = Saldos.direccion;
            this.nrocontrato1 = Saldos.nrocontrato1;
            this.tipodespacho = Saldos.tipodespacho;
            this.campos = new TS_BECreditosValidacion(Saldos);
            if (Saldos.tpsaldo.Equals("C"))
            {
                this.limitemto = Saldos.limitemtoC;
                this.consumto = Saldos.consumtoC;
            }
        }
        [DataMember]
        public string cdcliente { get; set; }
        [DataMember]
        public string nrotarjeta { get; set; }
        [DataMember]
        public string cdgrupo02 { get; set; }
        [DataMember]
        public string cdarticulo { get; set; }
        [DataMember]
        public decimal limitemto { get; set; }
        [DataMember]
        public decimal consumto { get; set; }
        [DataMember]
        public string nrobonus { get; set; }
        [DataMember]
        public string nroplaca { get; set; }
        [DataMember]
        public bool flgilimit { get; set; }
        [DataMember]
        public bool flgbloquea { get; set; }
        [DataMember]
        public string nrocontrato { get; set; }
        [DataMember]
        public string tpsaldo { get; set; }
        [DataMember]
        public decimal consumtoC { get; set; }
        [DataMember]
        public bool flgbloqueaC { get; set; }
        [DataMember]
        public decimal limitemtoC { get; set; }
        [DataMember]
        public bool flgilimitC { get; set; }
        [DataMember]
        public string ruc { get; set; }
        [DataMember]
        public string razonsocial { get; set; }
        [DataMember]
        public string direccion { get; set; }
        [DataMember]
        public string nrocontrato1 { get; set; }
        [DataMember]
        public string tipodespacho { get; set; }

        [DataMember]
        public TS_BECreditosValidacion campos { get; set; }
        [DataMember]
        public bool Ok { get; set; }
        [DataMember]
        public string Mensaje { get; set; }

    }
}
