using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Domain.Entities
{
        [DataContract, Serializable]
        public class Excepcion
        {
            [DataMember()]
            public string Codigo { get; set; }
            [DataMember()]
            public string Mensaje { get; set; }

            #region Constructor
            public Excepcion(Exception e)
            {
                this.Codigo = "Error";
                this.Mensaje = e.Message;
            }
            #endregion
        }
   
}
