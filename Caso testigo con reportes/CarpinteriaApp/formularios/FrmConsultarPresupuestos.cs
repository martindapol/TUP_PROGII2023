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
    public partial class FrmConsultarPresupuestos : Form
    {
        public FrmConsultarPresupuestos()
        {
            InitializeComponent();
        }

        private void Frm_Consultar_Presupuestos_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now.AddDays(7);
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string sp = "SP_CONSULTAR_PRESUPUESTOS";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@fecha_desde", dtpDesde.Value));
            lst.Add(new Parametro("@fecha_hasta", dtpHasta.Value));
            lst.Add(new Parametro("@cliente", txtCliente.Text));

            dgvPresupuestos.Rows.Clear();
            DataTable dt = HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            foreach (DataRow fila in dt.Rows)
            {
                dgvPresupuestos.Rows.Add(new object[] {
                    fila["presupuesto_nro"].ToString(),
                    fila["fecha"].ToString(),
                    fila["cliente"].ToString(),
                    fila["Total"].ToString()});
            }
        }

        private void dgvPresupuestos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPresupuestos.CurrentCell.ColumnIndex == 4)
            {
                int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
                new FrmDetallesPresupuesto(nro).ShowDialog();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea quitar el presupuesto seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvPresupuestos.CurrentRow != null)
                {
                    int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
                    List<Parametro> lst = new List<Parametro>();
                    lst.Add(new Parametro("@presupuesto_nro", nro));

                    int afectadas = HelperDB.ObtenerInstancia().EjecutarSQL("SP_ELIMINAR_PRESUPUESTO", lst);
                    if (afectadas == 1)
                    {
                        MessageBox.Show("El presupuesto se quitó exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("El presupuesto NO se quitó exitosamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvPresupuestos_Click(object sender, EventArgs e)
        {
            DataGridViewRow actual = dgvPresupuestos.CurrentRow;
            if (actual != null)
            {
                btnBorrar.Enabled = BtnEditar.Enabled = true;

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
            new FrmModificarPresupuesto(nro).ShowDialog();
            this.btnConsultar_Click(null, null);
        }
    }
}
