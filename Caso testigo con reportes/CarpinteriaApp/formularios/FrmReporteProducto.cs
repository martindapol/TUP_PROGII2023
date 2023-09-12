using CarpinteriaApp.datos;
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
    public partial class FrmReporteProducto : Form
    {
        public FrmReporteProducto()
        {
            InitializeComponent();
        }

        private void FrmReporteProducto_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddDays(-30);
            dtpHasta.Value = DateTime.Now;

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            HelperDB helper = HelperDB.ObtenerInstancia();
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", dtpDesde.Value));
            lst.Add(new Parametro("@fecha_hasta", dtpHasta.Value));
            DataTable dt = helper.ConsultaSQL("SP_REPORTE_PRODUCTOS", lst);
            rvReporte.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            rvReporte.RefreshReport();

        }
    }
}
