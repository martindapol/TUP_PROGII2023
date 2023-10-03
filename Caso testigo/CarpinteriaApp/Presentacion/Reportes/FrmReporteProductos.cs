using CarpinteriaApp.Datos;
using Microsoft.Reporting.WinForms;
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
    public partial class FrmReporteProductos : Form
    {
        public FrmReporteProductos()
        {
            InitializeComponent();
        }

        private void FrmReporteProductos_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now.AddMonths(-2);
            //this.reportViewer1.RefreshReport();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //obtener parámetros de la consulta
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", dtpDesde.Value));
            lst.Add(new Parametro("@fecha_hasta", dtpHasta.Value));
            //obtener datos en un Datatable
            DataTable dt = null; //new DBHelper().Consultar("SP_REPORTE_PRODUCTOS", lst);
            //enlazar el visualizador de reporte con el diseño + el dataset (source)

            ReportParameter[] parameters = new ReportParameter[] {
                new ReportParameter("rpFecDesde", dtpDesde.Value.ToShortDateString()),
                new ReportParameter("rpFecHasta", dtpHasta.Value.ToShortDateString())
            }; 
            rvProductos.LocalReport.SetParameters(parameters);
            
            rvProductos.LocalReport.DataSources.Clear();
            rvProductos.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt));
            rvProductos.RefreshReport();
        }
    }
}
