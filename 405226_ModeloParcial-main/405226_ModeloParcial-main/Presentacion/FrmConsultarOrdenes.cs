using ModeloParcial.Datos;
using ModeloParcial.Dominio;
using ModeloParcial.Servicio;
using ModeloParcial.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModeloParcial.Presentacion
{
    public partial class FrmConsultarOrdenes : Form
    {
        List<OrdenRetiro> lOrdenes;
        IServicio servicioDatos;
        FabricaServicio fabrica;
        public FrmConsultarOrdenes(FabricaServicio fabrica)
        {
            InitializeComponent();
            lOrdenes = new List<OrdenRetiro>();
            this.fabrica = fabrica;
            servicioDatos = fabrica.CrearServicio();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (dtpFecha.Value>DateTime.Now)
            {
                MessageBox.Show("Debe ingresar una fecha valida!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (!rbtMayor.Checked && !rbtMenor.Checked)
            {
                MessageBox.Show("Debe elegir el parametro de comparacion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lOrdenes.Clear();
            dgvOrdenes.Rows.Clear();
            List<Parametro> lParametros = new List<Parametro>();
            lParametros.Add(new Parametro("@responsable",txtResponsable.Text));
            lParametros.Add(new Parametro("@fecha_orden",dtpFecha.Value));
            CargarLista(lParametros);
            AgregarOrdenes();
        }

        private void CargarLista(List<Parametro> lParametros)
        {
            if (rbtMayor.Checked)
                lOrdenes.AddRange(servicioDatos.TraerOrdenes(lParametros, "SP_CONSULTAR_ORDENES_MENOR"));
            if (rbtMenor.Checked)
                lOrdenes.AddRange(servicioDatos.TraerOrdenes(lParametros, "SP_CONSULTAR_ORDENES_MAYOR"));
        }

        public void AgregarOrdenes()
        {
            foreach(OrdenRetiro o in lOrdenes)
            {
                dgvOrdenes.Rows.Add(new object[] {o.nroOrden,o.responsableOrden,o.fechaOrden,"Ver Detalle" });
            }
        }

        private void dgvOrdenes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrdenes.CurrentRow == null)
            {
                MessageBox.Show("Debe Consultar los camiones previamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvOrdenes.CurrentCell.ColumnIndex == 3)
            {
                int nro = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells["ColumnaId"].Value.ToString());
                new FrmConsultarOrden(fabrica, nro).ShowDialog();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea cancelar la consulta?","Cancelar?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea borrar la orden? Esta accion no se puede deshacer", "Borrar?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                int nro = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells["ColumnaId"].Value.ToString());
                servicioDatos.BorrarOrden(nro);
                dgvOrdenes.Rows.Clear();
            }
            else
            {
                this.Dispose();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int nro = Convert.ToInt32(dgvOrdenes.CurrentRow.Cells["ColumnaId"].Value.ToString());
            new FrmEditarOrden(fabrica,nro).ShowDialog();
        }

        private void FrmConsultarOrdenes_Load(object sender, EventArgs e)
        {
            rbtMayor.Checked=true;
        }
    }
}
