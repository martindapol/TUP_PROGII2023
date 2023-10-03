using CarpinteriaApp.Datos;
using CarpinteriaApp.Servicios;
using CarpinteriaApp.Servicios.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp.Presentacion
{
    public partial class FrmConsultarPresupuestos : Form
    {
        private GestorPresupuestos gestor;
        public FrmConsultarPresupuestos(AbstractDaoFactory factory)
        {
            InitializeComponent();
            gestor = new GestorPresupuestos(factory);
        }

        private void FrmConsultarPresupuestos_Load(object sender, EventArgs e)
        {
            dtpFecDesde.Value = DateTime.Now.AddDays(-7);
            dtpFecHasta.Value = DateTime.Now;
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            //validar campos de carga!!!
            /*List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", dtpFecDesde.Value.ToString("yyyyMMdd")));
            lst.Add(new Parametro("@fecha_hasta", dtpFecHasta.Value.ToString("yyyyMMdd")));
            lst.Add(new Parametro("@cliente", txtCliente.Text));

            DataTable tabla = DBHelper.GetInstancia().Consultar("SP_CONSULTAR_PRESUPUESTOS", lst);
            */
            dgvPresupuestos.Rows.Clear();
            List<PresupuestoDTO> lst = gestor.ObtenerPresupuestosConFiltros(dtpFecDesde.Value, dtpFecHasta.Value, txtCliente.Text);
            foreach (PresupuestoDTO dto in lst)
            {
                dgvPresupuestos.Rows.Add(new object[] { dto.PresupuestoNro,
                                                        dto.Fecha,
                                                        dto.Cliente,
                                                        dto.Total});
            }
        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPresupuestos.CurrentCell.ColumnIndex== 4) 
            {
                //int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["ColNro"].Value.ToString());
                int nro = Convert.ToInt32(dgvPresupuestos.CurrentRow.Cells["ColNro"].Value);
                FrmDetallesPresupuesto detalle = new FrmDetallesPresupuesto(nro); //llamada con constructor con parámetro.
                detalle.presupuestoNro= nro; //llamada con propiedad.   
                detalle.ShowDialog();
            }
        }
    }
}
