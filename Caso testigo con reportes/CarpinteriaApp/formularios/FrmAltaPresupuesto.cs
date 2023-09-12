using CarpinteriaApp.datos;
using CarpinteriaApp.dominio;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CarpinteriaApp.formularios
{
    public partial class FrmAltaPresupuesto : Form
    {
        private HelperDB helper;
        private Presupuesto nuevo;
        public FrmAltaPresupuesto()
        {
            InitializeComponent();
            helper = HelperDB.ObtenerInstancia();
            CargarProductos();
            //Crear nuevo presupuesto:
            nuevo = new Presupuesto();
            

        }

        private void Frm_Alta_Presupuesto_Load(object sender, EventArgs e)
        {
            ProximoPresupuesto();
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCliente.Text = "CONSUMIDOR FINAL";
            txtDto.Text = "0";
            this.ActiveControl = cboProductos; // Set foco al combo
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cboProductos.Text.Equals(String.Empty))
            {
                MessageBox.Show("Debe seleccionar un PRODUCTO!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtCantidad.Text == "" || !int.TryParse(txtCantidad.Text, out _))
            {
                MessageBox.Show("Debe ingresar una cantidad válida!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            foreach (DataGridViewRow row in dgvDetalles.Rows)
            {
                if (row.Cells["colProd"].Value.ToString().Equals(cboProductos.Text))
                {
                    MessageBox.Show("PRODUCTO: " + cboProductos.Text + " ya se encuentra como detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
            }

            DataRowView item = (DataRowView)cboProductos.SelectedItem;

            int prod = Convert.ToInt32(item.Row.ItemArray[0]);
            string nom = item.Row.ItemArray[1].ToString();
            double pre = Convert.ToDouble(item.Row.ItemArray[2]);
            Producto p = new Producto(prod, nom, pre);
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            DetallePresupuesto detalle = new DetallePresupuesto(p, cantidad);
            nuevo.AgregarDetalle(detalle);
            dgvDetalles.Rows.Add(new object[] { item.Row.ItemArray[0], item.Row.ItemArray[1], item.Row.ItemArray[2], txtCantidad.Text });

            CalcularTotal();
        }

        private void dgvDetalles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalles.CurrentCell.ColumnIndex == 4)
            {
                nuevo.QuitarDetalle(dgvDetalles.CurrentRow.Index);
                //click button:
                dgvDetalles.Rows.Remove(dgvDetalles.CurrentRow);
                //presupuesto.quitarDetalle();
                CalcularTotal();

            }
        }

        private void CalcularTotal()
        {
            double total = nuevo.CalcularTotal();
            txtTotal.Text = total.ToString();

            if (txtDto.Text != "")
            {
                double dto = (total * Convert.ToDouble(txtDto.Text)) / 100;
                txtFinal.Text = (total - dto).ToString();
            }
        }

        private void CargarProductos()
        {
            DataTable table = helper.ConsultaSQL("SP_CONSULTAR_PRODUCTOS", null);
            if (table != null)
            {
                cboProductos.DataSource = table;
                cboProductos.DisplayMember = "n_producto";
                cboProductos.ValueMember = "id_producto";
            }
        }
        private void ProximoPresupuesto()
        {
            int next = helper.ProximoPresupuesto();
            if (next > 0)
                lblNroPresupuesto.Text = "Presupuesto Nº: " + next.ToString();
            else
                MessageBox.Show("Error de datos. No se puede obtener Nº de presupuesto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void GuardarPresupuesto()
        {
            //datos del presupuesto:
            nuevo.Cliente = txtCliente.Text;
            nuevo.Descuento = Convert.ToDouble(txtDto.Text);
            nuevo.Fecha = Convert.ToDateTime(txtFecha.Text);

            if (helper.ConfirmarPresupuesto(nuevo))
            {
                MessageBox.Show("Presupuesto registrado", "Informe", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();
            }
            else
            {
                MessageBox.Show("ERROR. No se pudo registrar el presupuesto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtCliente.Text == "")
            {
                MessageBox.Show("Debe ingresar un cliente!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (dgvDetalles.Rows.Count == 0)
            {
                MessageBox.Show("Debe ingresar al menos detalle!", "Control", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            GuardarPresupuesto();
        }
    }
}
