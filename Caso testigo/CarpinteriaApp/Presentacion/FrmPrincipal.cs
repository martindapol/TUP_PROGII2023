using CarpinteriaApp.Datos;
using CarpinteriaApp.Presentacion;
using CarpinteriaApp.Presentacion.Reportes;
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
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNuevoPresupuesto nuevo = new FrmNuevoPresupuesto();
            nuevo.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmConsultarPresupuestos consulta=new FrmConsultarPresupuestos(new DaoFactory());
            consulta.ShowDialog();
        }

        private void productosVendidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReporteProductos().ShowDialog();
        }

        private void listadoDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmListadoProductos().ShowDialog();
        }
    }
}
