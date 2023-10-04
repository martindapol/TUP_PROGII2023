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
    public partial class FrmEditarOrden : Form
    {
        IServicio servicioDatos = null;
        OrdenRetiro ordenEditar = null;
        int auxDetalle;
        public FrmEditarOrden(FabricaServicio fabrica ,int nro)
        {
            InitializeComponent();
            servicioDatos = fabrica.CrearServicio();
            ordenEditar = servicioDatos.TraerOrden(nro);
            auxDetalle = 1;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea cancelar la edicion?","Cancelar?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void FrmEditarOrden_Load(object sender, EventArgs e)
        {
            cboMateriales.DataSource = servicioDatos.TraerMateriales();
            cboMateriales.DropDownStyle = ComboBoxStyle.DropDownList;
            lblOrdenNro.Text += ordenEditar.nroOrden;
            txtResponsable.Text = ordenEditar.responsableOrden;
            dtpFechaOrden.Value = ordenEditar.fechaOrden;
            foreach (DetalleOrden d in ordenEditar.listaDetalles)
            {
                cboMateriales.SelectedIndex = d.materialDetalle.codigoMaterial -1;
                Material auxMat = (Material)cboMateriales.SelectedItem;
                dgvDetalles.Rows.Add(new object[] { d.idDetalle, d.materialDetalle.nombreMaterial,auxMat.stockMaterial, d.cantidadDetalle,"Quitar" });
                auxDetalle++;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResponsable.Text))
            {
                MessageBox.Show("Debe ingresar un responsable!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dtpFechaOrden.Value > DateTime.Now)
            {
                MessageBox.Show("Debe ingresar una fecha valida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dgvDetalles.CurrentRow == null)
            {
                MessageBox.Show("Debe ingresar una carga para confirmar la edicion!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ordenEditar.responsableOrden = txtResponsable.Text;
            ordenEditar.fechaOrden = dtpFechaOrden.Value;
            if (servicioDatos.ActualizarOrden(ordenEditar))
            {
                MessageBox.Show("Orden actualizada exitosamente!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("no pudo actualizarse la orden!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCantidad.Text))
            {
                MessageBox.Show("Debe ingresar una cantidad valida!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            foreach (DataGridViewRow r in dgvDetalles.Rows)
            {
                Material mat = (Material)cboMateriales.SelectedItem;
                if (r.Cells["ColumnaMaterial"].Value.ToString() == mat.nombreMaterial)
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
            ordenEditar.AgregarDetalle(det);
            dgvDetalles.Rows.Add(new object[] { det.idDetalle, det.materialDetalle.nombreMaterial, det.materialDetalle.stockMaterial, det.cantidadDetalle, "Quitar" });
            auxDetalle++;
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                ordenEditar.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                auxDetalle--;
            }
        }
    }
}
