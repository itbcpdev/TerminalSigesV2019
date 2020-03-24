using ITBCP.ServiceSIGES.Aplication.Interfaces;
using ITBCP.ServiceSIGES.Domain;
using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBCP.ServiceSIGES.Aplication
{
    public class TS_APParametro: ITS_AIParametro
    {
        private readonly ITS_DOParametro _ITS_DOParametro;

        public TS_APParametro(ITS_DOParametro ITS_DOParameters)
        {
            _ITS_DOParametro = ITS_DOParameters;
        }
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        //Metodo         : SelTodoDetalle
        //Creado por     : Teófilo Chambilla Aquino (26/01/2019)
        //ˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆˆ
        ///<summary>Permite recuperar datos de la Tabla =  [tab0s00] </summary>
        public TS_BEParameters SelTodoDetalle()
        {
            TS_BEParameters output = new TS_BEParameters();
            try
            {
                output = _ITS_DOParametro.ObtenerParameters();
            }
            catch (Exception e)
            {
                throw new Exception(Helpers.RaiseError(e));

            }
            return output;
        }
    }
}
