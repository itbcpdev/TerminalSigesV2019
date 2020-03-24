using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities.Campos
{
    [DataContract]
    public class TS_BECreditosValidacion
    {
        public TS_BECreditosValidacion() { }
        public TS_BECreditosValidacion(TS_BEClienteCreditoOutput Saldos)
        {
            this.rscliente = new TS_BEField();
            this.chofer = new TS_BEField();
            this.placa = new TS_BEField();
            this.odometro = new TS_BEField();
            this.nrovale = new TS_BEField();

            this.rscliente.visible = true;
            this.rscliente.disabled = true;
            this.chofer.visible = true;
            this.chofer.disabled = true;
            this.placa.visible = true;
            this.placa.disabled = !((Saldos.nroplaca ?? "").Trim().Length > 0);
            this.odometro.visible = true;
            this.odometro.disabled = true;
            this.nrovale.visible = false;
            this.nrovale.disabled = true;
        }
        [DataMember]
        public TS_BEField rscliente { get; set; }
        [DataMember]
        public TS_BEField chofer { get; set; }
        [DataMember]
        public TS_BEField placa { get; set; }
        [DataMember]
        public TS_BEField odometro { get; set; }
        [DataMember]
        public TS_BEField nrovale { get; set; }
    }
}
