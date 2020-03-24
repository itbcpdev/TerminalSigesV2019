using ITBCP.ServiceSIGES.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DE = ITBCP.ServiceSIGES.Domain.Entities;
using AG = ITBCP.ServiceSIGES.Presentation.AgentServices;
namespace ITBCP.ServiceSIGES.Aplication.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DE.TS_BEParameters entParameter = new DE.TS_BEParameters();
            entParameter = new AG.TS_Parameters().SelTodoDetalle();

            string istrMensaje = "";

            istrMensaje += "id: " + entParameter.id + Environment.NewLine;
            istrMensaje += "monpais" + entParameter.monpais + Environment.NewLine;
            istrMensaje += "path_repo: " + entParameter.path_repo + Environment.NewLine;
            istrMensaje += "path_formato: " + entParameter.path_formato + Environment.NewLine;
            istrMensaje += "path_gasboy: " + entParameter.path_gasboy + Environment.NewLine;
            istrMensaje += "path_loteria: " + entParameter.path_loteria + Environment.NewLine;
            istrMensaje += "numempresa: " + entParameter.numempresa + Environment.NewLine;
            istrMensaje += "tpfactura: " + entParameter.tpfactura + Environment.NewLine;
            istrMensaje += "tpboleta: " + entParameter.tpboleta + Environment.NewLine;
            istrMensaje += "tpticket: " + entParameter.tpticket + Environment.NewLine;
            istrMensaje += "tppromocion: " + entParameter.tppromocion + Environment.NewLine;
            istrMensaje += "tpntavta: " + entParameter.tpntavta + Environment.NewLine;
            istrMensaje += "tpncredito: " + entParameter.tpncredito + Environment.NewLine;
            istrMensaje += "tpndebito: " + entParameter.tpndebito + Environment.NewLine;
            istrMensaje += "tpletra: " + entParameter.tpletra + Environment.NewLine;
            istrMensaje += "tpletraprot: " + entParameter.tpletraprot + Environment.NewLine;
            istrMensaje += "tpguia: " + entParameter.tpguia + Environment.NewLine;
            istrMensaje += "tpvale: " + entParameter.tpvale + Environment.NewLine;
            istrMensaje += "tpanticipo: " + entParameter.tpanticipo + Environment.NewLine;
            istrMensaje += "tpcheque: " + entParameter.tpcheque + Environment.NewLine;
            istrMensaje += "tpproforma: " + entParameter.tpproforma + Environment.NewLine;
            istrMensaje += "tpseparacion: " + entParameter.tpseparacion + Environment.NewLine;
            istrMensaje += "tpcomanda: " + entParameter.tpcomanda + Environment.NewLine;
            istrMensaje += "tppedido: " + entParameter.tppedido + Environment.NewLine;
            istrMensaje += "tppgoefectivo: " + entParameter.tppgoefectivo + Environment.NewLine;
            istrMensaje += "tppgotarjeta: " + entParameter.tppgotarjeta + Environment.NewLine;
            istrMensaje += "tppgocheque: " + entParameter.tppgocheque + Environment.NewLine;
            istrMensaje += "tppgocredito: " + entParameter.tppgocredito + Environment.NewLine;
            istrMensaje += "tpaplicncred: " + entParameter.tpaplicncred + Environment.NewLine;
            istrMensaje += "tpaplicantic: " + entParameter.tpaplicantic + Environment.NewLine;
            istrMensaje += " tppgocanje" + entParameter.tppgocanje + Environment.NewLine;
            istrMensaje += "cdarticulocontable: " + entParameter.cdarticulocontable + Environment.NewLine;
            istrMensaje += "calculoigv: " + entParameter.calculoigv + Environment.NewLine;
            istrMensaje += "flgdesgtkfact: " + entParameter.flgdesgtkfact + Environment.NewLine;
            istrMensaje += "flgmolotov: " + entParameter.flgmolotov + Environment.NewLine;
            istrMensaje += "path_clicorp: " + entParameter.path_clicorp + Environment.NewLine;
            istrMensaje += "path_bonus: " + entParameter.path_bonus + Environment.NewLine;
            istrMensaje += "central: " + entParameter.central + Environment.NewLine;
            istrMensaje += "path_transfer: " + entParameter.path_transfer + Environment.NewLine;
            istrMensaje += "cambioturno: " + entParameter.cambioturno + Environment.NewLine;
            istrMensaje += "tppgotransferencia: " + entParameter.tppgotransferencia + Environment.NewLine;
            istrMensaje += "tpticketfac: " + entParameter.tpticketfac + Environment.NewLine;
            istrMensaje += "nom_ventaplaya: " + entParameter.nom_ventaplaya + Environment.NewLine;
            istrMensaje += "tpcliente_corporativo: " + entParameter.tpcliente_corporativo + Environment.NewLine;
            istrMensaje += "fe_ipremoto: " + entParameter.fe_ipremoto + Environment.NewLine;
            istrMensaje += "fe_puertoremoto: " + entParameter.fe_puertoremoto + Environment.NewLine;
            istrMensaje += "fe_proveedor: " + entParameter.fe_proveedor + Environment.NewLine;
            istrMensaje += "fe_dbz_rutasuitepos" + entParameter.fe_dbz_rutasuitepos + Environment.NewLine;
            istrMensaje += "fe_dbz_rutasuitesuc: " + entParameter.fe_dbz_rutasuitesuc + Environment.NewLine;
            istrMensaje += "fe_snt_rutaprocesamiento: " + entParameter.fe_snt_rutaprocesamiento + Environment.NewLine;
            istrMensaje += "fe_snt_rutafacturador: " + entParameter.fe_snt_rutafacturador + Environment.NewLine;
            istrMensaje += "fe_snt_rutagenerador: " + entParameter.fe_snt_rutagenerador + Environment.NewLine;
            istrMensaje += "fe_mst_rutawebservice: " + entParameter.fe_mst_rutawebservice + Environment.NewLine;
            istrMensaje += "fe_sge_rutawebservice: " + entParameter.fe_sge_rutawebservice + Environment.NewLine;
            istrMensaje += "fe_sge_clavecertificado: " + entParameter.fe_sge_clavecertificado + Environment.NewLine;
            istrMensaje += "fe_asp_rutaprocesamiento: " + entParameter.fe_asp_rutaprocesamiento + Environment.NewLine;
            istrMensaje += "fe_inc_rutaprocesamiento: " + entParameter.fe_inc_rutaprocesamiento + Environment.NewLine;
            istrMensaje += "fe_bzl_tiempoespera: " + entParameter.fe_bzl_tiempoespera + Environment.NewLine;
            istrMensaje += "fe_act_rutaprocesamiento: " + entParameter.fe_act_rutaprocesamiento + Environment.NewLine;
            istrMensaje += "fe_tci_rutaprocesamiento: " + entParameter.fe_tci_rutaprocesamiento + Environment.NewLine;
            istrMensaje += "fe_act_ruta_ws: " + entParameter.fe_act_ruta_ws + Environment.NewLine;
            istrMensaje += "fe_act_clave_ws: " + entParameter.fe_act_clave_ws + Environment.NewLine;
            istrMensaje += "fe_act_ruta_ws_CDR: " + entParameter.fe_act_ruta_ws_CDR + Environment.NewLine;


            this.txtParameters.Text = istrMensaje;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
