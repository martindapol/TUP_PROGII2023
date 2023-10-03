using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CarpinteriaApp.Entidades;
using CarpinteriaApp.Datos;
using CarpinteriaApp.Servicios;

namespace CarpinteriaApp.Presentacion
{
    public partial class FrmNuevoPresupuesto : Form
    {
        GestorProductos gestorProductos = null;
        GestorPresupuestos gestorPresupuestos = null;
        Presupuesto nuevo = null;
        public FrmNuevoPresupuesto()
        {
            InitializeComponent();
            //No se elimina la creación del dao, pero si se elimina la
            //dependencia dentro del gestor
            gestorProductos = new GestorProductos(new ProductoDao());
            gestorPresupuestos = new GestorPresupuestos(new DaoFactory());
            nuevo = new Presupuesto();
        }

        private void FrmNuevoPresupuesto_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";
            lblPresupuestoNro.Text = lblPresupuestoNro.Text + " " + gestorPresupuestos.ProximoPresupuesto();

            CargarProductos();
        }

        private void CargarProductos()
        {
            List<Producto> lst = gestorProductos.ObtenerProductos();
            cboProducto.DataSource = lst;
            cboProducto.ValueMember = "ProductoNro";//properties del objeto Producto
            cboProducto.DisplayMember = "Nombre";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Validar campos del item:
            if (cboProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un producto...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //validar existencia del item en la grilla:
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["ColProducto"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("Este producto ya está presupuestado...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }


            Producto p = (Producto)cboProducto.SelectedItem;
            int cant = Convert.ToInt32(txtCantidad.Text);
            DetallePresupuesto detalle = new DetallePresupuesto(p, cant);

            //Agregar un item al nuevo presupuesto:
            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { p.ProductoNro, p.Nombre, p.Precio, cant, "(-)Quitar" });

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            //La pantalla es responsable de calcular el subtotal y el monto final con Descuento:
            txtSubTotal.Text = nuevo.CalcularTotal().ToString();
            if (!string.IsNullOrEmpty(txtDescuento.Text) && int.TryParse(txtDescuento.Text, out _))
            {
                double desc = nuevo.CalcularTotal() * Convert.ToDouble(txtDescuento.Text) / 100;
                txtTotal.Text = (nuevo.CalcularTotal() - desc).ToString();
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4) //boton Quitar de la grilla
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                dgvDetalles.Rows.RemoveAt(dgvDetalles.CurrentRow.Index);
                CalcularTotales();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Validar
            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                MessageBox.Show("Debe ingresar un cliente...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos un detalle...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //Confirmar o Grabar
            GrabarPresupuesto();
        }

        private void GrabarPresupuesto()
        {
            nuevo.Fecha = Convert.ToDateTime(txtFecha.Text);
            nuevo.Cliente = txtCliente.Text;
            nuevo.Descuento = Convert.ToDouble(txtDescuento.Text);
            if (gestorPresupuestos.ConfirmarPresupuesto(nuevo))
            {
                MessageBox.Show("Se registró con éxito el presupuesto...", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("NO se pudo registrar el presupuesto...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
