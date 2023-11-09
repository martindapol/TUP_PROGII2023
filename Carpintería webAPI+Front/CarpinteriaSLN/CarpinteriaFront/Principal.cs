using CarpinteriaFront;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp.formularios
{
    public partial class Principal : Form
    {

        public Principal()
        {
            InitializeComponent();

        }

        private void acercaDeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Carpintería App", "Caso Testigo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void nuevoPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmAltaPresupuesto().ShowDialog();
        }

        private void consultarPresupuestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConsultarPresupuestos().ShowDialog();
        }

        private void reporteDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //new FrmReporteProducto(fabrica).ShowDialog();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
