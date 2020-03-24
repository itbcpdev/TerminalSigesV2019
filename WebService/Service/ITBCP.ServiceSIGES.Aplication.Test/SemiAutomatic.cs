using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITBCP.ServiceSIGES.Aplication.Test
{
    public partial class SemiAutomatic : Form
    {
        ProxyFacturacion.TS_SIBackOfficeClient clientBackOffice = null;
        public SemiAutomatic()
        {
            InitializeComponent();
        }

        private void SemiAutomatic_Load(object sender, EventArgs e)
        {
            clientBackOffice = new ProxyFacturacion.TS_SIBackOfficeClient();
        }

        private void btnSerafin_Click(object sender, EventArgs e)
        {

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

        }

        private void btnDescuento_Click(object sender, EventArgs e)
        {

        }

        private void btnEfectivo_Click(object sender, EventArgs e)
        {

        }

        private void btnReimprimir_Click(object sender, EventArgs e)
        {

        }

        private void btntranfgrat_Click(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var lista = clientBackOffice.SP_ITBCP_LISTAR_CLIENTE_POR_CODIGO(new ProxyFacturacion.TS_BECliente()
                {
                    cdcliente = txtCodigo.Text.Trim()
                });

                if (lista.Count() != 0)
                {
                    var infoCliente = lista[0];
                    txtRuc.Text = infoCliente.ruccliente;
                    txtRazonSocial.Text = infoCliente.rscliente;
                    txtDireccion.Text = infoCliente.drcliente;

                }
            }
        }

        private void txtLado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var lista = clientBackOffice.SP_ITBCP_LISTAR_TRANSACCION_ARTICULO(new ProxyFacturacion.TS_BEOp_Tran()
                {
                    cara = txtLado.Text.Trim()
                });

                if (lista.Count() != 0)
                {
                    gvDetalle.AutoGenerateColumns = false;
                    gvDetalle.DataSource = lista;
                    txtTotal.Text = lista[0].soles.ToString();
                    var listaIgv = clientBackOffice.SP_ITBCP_OBTENER_IGV(new ProxyFacturacion.TS_BETipo_Igv() {
                    });
                    var Igv = (lista[0].soles * Convert.ToDecimal(listaIgv[listaIgv.Count() - 1].igv)) / 100;
                    txtIGV.Text = Igv.ToString();
                    txtSubTotal.Text = (lista[0].soles - Igv).ToString();
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
