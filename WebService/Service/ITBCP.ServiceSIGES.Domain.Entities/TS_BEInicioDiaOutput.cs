﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
    [DataContract]
    public class TS_BEInicioDiaOutput
    {
        [DataMember]
        public TS_BEMensaje Mensaje { get; set; }
        [DataMember]
        public TS_BETerminal vTerminal { get; set; }
    }
}
