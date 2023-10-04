using ModeloParcial.Presentacion;
using ModeloParcial.Servicio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloParcial
{
    public partial class FrmPrincipal : Form
    {
        FabricaServicio fabrica = null;
        public FrmPrincipal(FabricaServicio fabrica)
        {
            InitializeComponent();
            this.fabrica = fabrica;
        }

        private void nuevaOrdenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmNuevaOrden(fabrica).ShowDialog();
        }

        private void consultarOrdenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConsultarOrdenes(fabrica).ShowDialog();
        }

        private void reporteStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReporteStock().ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
