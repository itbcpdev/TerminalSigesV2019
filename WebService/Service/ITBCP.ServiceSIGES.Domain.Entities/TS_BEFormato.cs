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
    //Creado por     : Ronald Noé Saavedra Bances (28/01/2019)
    //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
    /// <summary> Entidad = Ticket</summary>
    ///
    public class TS_BEFormato
    {
        public TS_BEFormato(string header,string footer)
        {
            string[] headerlist = header.Split('|');
            header = "";
            foreach (string list in headerlist)
            {
                if(list != null)
                {
                    if (list.Length >0)
                    {
                        header = header + list + "\n";
                    }
                }
            }
            string[] footerlist = footer.Split('|');
            footer = "";

            foreach (string list in footerlist)
            {
                if (list != null)
                {
                    if (list.Length > 0)
                    {
                        footer = footer + list + "\n";
                    }
                }
            }
            this.header = header;
            this.footer = footer;
        }

        [DataMember]
        public string header { get; set; }

        [DataMember]
        public string footer { get; set; }

        [DataMember]
        public decimal puntos_canjeados { get; set; }
        [DataMember]
        public decimal valor_canjeados { get; set; }

    }
}
