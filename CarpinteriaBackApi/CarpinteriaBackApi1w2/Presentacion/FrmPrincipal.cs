using CarpinteriaApp.Presentacion;
using CarpinteriaApp.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp
{
    public partial class FrmPrincipal : Form
    {
        FabricaServicio fabrica = null;
        public FrmPrincipal(FabricaServicio fabrica)
        {
            InitializeComponent();
            this.fabrica= fabrica;
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoPresupuesto nuevo = new FrmNuevoPresupuesto(fabrica);
            nuevo.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultarPresupuestos consulta=new FrmConsultarPresupuestos(fabrica);
            consulta.ShowDialog();
        }
    }
}
