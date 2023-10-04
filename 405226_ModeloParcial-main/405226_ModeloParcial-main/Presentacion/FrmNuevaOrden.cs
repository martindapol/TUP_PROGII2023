using ModeloParcial.Dominio;
using ModeloParcial.Servicio;
using ModeloParcial.Servicio.Implementacion;
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
    public partial class FrmNuevaOrden : Form
    {
        IServicio servicioDatos = null;
        OrdenRetiro ordenRetiro = null;
        int auxDetalle;
        public FrmNuevaOrden(FabricaServicio fabrica)
        {
            InitializeComponent();
            servicioDatos = fabrica.CrearServicio();
            ordenRetiro = new OrdenRetiro();
            auxDetalle = 1;
            lblOrdenNro.Text += servicioDatos.ObtenerNroProxCarga();
        }

        private void FrmNuevaOrden_Load(object sender, EventArgs e)
        {
            cboMateriales.DataSource = servicioDatos.TraerMateriales();
            cboMateriales.DropDownStyle = ComboBoxStyle.DropDownList;
            dtpFecha.Value = DateTime.Now;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea cancelar la orden?","Cancelar?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResponsable.Text))
            {
                MessageBox.Show("Debe ingresar un responsable!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpFecha.Value > DateTime.Now)
            {
                MessageBox.Show("Debe ingresar una fecha valida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show("Debe ingresar una carga para confirmar la orden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ordenRetiro.responsableOrden = txtResponsable.Text;
            ordenRetiro.fechaOrden = dtpFecha.Value;
            if (servicioDatos.ConfirmarOrden(ordenRetiro))
            {
                MessageBox.Show("Orden confirmada exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("no pudo confirmarse la orden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar una cantidad valida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach(DataGridViewRow r in dgvDetalles.Rows)
            {
                Material mat = (Material)cboMateriales.SelectedItem;
                if (r.Cells["ColumnaMaterial"].Value.ToString()==mat.nombreMaterial)
                {
                    MessageBox.Show("Ese Material ya esta utilizado!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            try
            {
                int.Parse(txtCantidad.Text);
            }
            catch
            {
                MessageBox.Show("Debe ingresar una cantidad valida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Material oMaterial = (Material)cboMateriales.SelectedItem;
            if (oMaterial.stockMaterial < int.Parse(txtCantidad.Text))
            {
                MessageBox.Show("La cantidad ingresada es mayor al stock disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Material item = (Material)cboMateriales.SelectedItem;
            int cantidad = int.Parse(txtCantidad.Text);
            DetalleOrden det = new DetalleOrden(auxDetalle, item, cantidad);
            ordenRetiro.AgregarDetalle(det);
            dgvDetalles.Rows.Add(new object[] { det.idDetalle, det.materialDetalle.nombreMaterial, det.materialDetalle.stockMaterial, det.cantidadDetalle, "Quitar" });
            auxDetalle++;
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex ==4)
            {
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                ordenRetiro.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                auxDetalle--;
            }
        }
    }
}
