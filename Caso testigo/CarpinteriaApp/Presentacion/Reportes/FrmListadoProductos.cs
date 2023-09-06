using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp.Presentacion.Reportes
{
    public partial class FrmListadoProductos : Form
    {
        public FrmListadoProductos()
        {
            InitializeComponent();
        }

        private void FrmListadoProductos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dSReporte.T_PRODUCTOS' Puede moverla o quitarla según sea necesario.
            this.t_PRODUCTOSTableAdapter.Fill(this.dSReporte.T_PRODUCTOS);

            this.reportViewer1.RefreshReport();
        }
    }
}
