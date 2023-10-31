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
using CarpinteriaApp.Datos.Interfaz;
using CarpinteriaApp.Datos.Implementacion;
using CarpinteriaApp.Servicios.Interfaz;
using CarpinteriaApp.Servicios.Implementacion;
using CarpinteriaApp.Servicios;

namespace CarpinteriaApp.Presentacion
{
    public partial class FrmNuevoPresupuesto : Form
    {
        IServicio servicio = null;
        Presupuesto nuevo = null;
        public FrmNuevoPresupuesto(FabricaServicio fabrica)
        {
            InitializeComponent();
            servicio = fabrica.CrearServicio();
            nuevo= new Presupuesto();
        }

        private void FrmNuevoPresupuesto_Load(object sender, EventArgs e)
        {
            txtFecha.Text = DateTime.Today.ToShortDateString();
            txtCliente.Text = "Consumidor Final";
            txtDescuento.Text = "0";
            txtCantidad.Text = "1";
            lblPresupuestoNro.Text = lblPresupuestoNro.Text + " " + servicio.TraerProximoPresupuesto().ToString();
            
            CargarProductos();
        }

        private void CargarProductos()
        {
            cboProducto.DataSource = servicio.TraerProductos();
            cboProducto.ValueMember = "ProductoNro";
            cboProducto.DisplayMember = "Nombre";  
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedIndex== -1)
            {
                MessageBox.Show("Seleccione un producto...","Control",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out _)) 
            {
                MessageBox.Show("Debe ingresar una cantidad válida...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["ColProducto"].Value.ToString().Equals(cboProducto.Text))
                {
                    MessageBox.Show("Este producto ya está presupuestado...", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            //DataRowView item = (DataRowView)cboProducto.SelectedItem;
            //int nro = Convert.ToInt32(item.Row.ItemArray[0]);
            //string nom = item.Row.ItemArray[1].ToString();
            //double pre = Convert.ToDouble(item.Row.ItemArray[2]);
            //Producto p = new Producto(nro, nom, pre);

            Producto p= (Producto)cboProducto.SelectedItem;

            int cant = Convert.ToInt32(txtCantidad.Text);
            DetallePresupuesto detalle= new DetallePresupuesto(p, cant);

            nuevo.AgregarDetalle(detalle);
            //dgvDetalles.Rows.Add(new object[] { detalle.Producto.ProductoNro,
            //                                    detalle.Producto.Nombre,
            //                                    detalle.Producto.Precio,
            //                                    detalle.Cantidad});
            dgvDetalles.Rows.Add(new object[] { p.ProductoNro,p.Nombre,p.Precio,cant,"Quitar"});

            CalcularTotales();
        }

        private void CalcularTotales()
        {
            txtSubTotal.Text = nuevo.CalcularTotal().ToString();
            if (!string.IsNullOrEmpty(txtDescuento.Text) && int.TryParse(txtDescuento.Text, out _))
            {
                double desc = nuevo.CalcularTotal() * Convert.ToDouble(txtDescuento.Text) / 100;
                txtTotal.Text = (nuevo.CalcularTotal() - desc).ToString();
            }
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex==4) //boton Quitar de la grilla
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
            if (dgvDetalles.Rows.Count== 0)
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
            nuevo.Descuento=Convert.ToDouble(txtDescuento.Text);
            if (servicio.CrearPresupuesto(nuevo))
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
