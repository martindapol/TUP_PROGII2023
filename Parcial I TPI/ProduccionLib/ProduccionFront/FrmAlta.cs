using Newtonsoft.Json;
using ProduccionFront.Http;
using ProduccionLib.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Produccion.Presentacion
{
    public partial class FrmAlta : Form
    {
        private OrdenProduccion nuevaOrden;
        private int auxDetalle;
        public FrmAlta()
        {
            InitializeComponent();
            nuevaOrden = new OrdenProduccion();
            auxDetalle = 0;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private async void FrmAlta_Load(object sender, EventArgs e)
        {
           await CargarComboAsync();
        }
        private async Task CargarComboAsync()
        {
            string url = "https://localhost:7194/api/OrdenProduccion/componentes";
            var response = await HttpHelper.GetInstance().GetAsync(url);
            List<Componente> list = JsonConvert.DeserializeObject<List<Componente>>(response.Data);

            cboComponente.DataSource = list;
        }


        private void cboComponente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool existeEnGrilla(string nombre)
        {
            foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                if (fila.Cells["colComponente"].Value.ToString().Equals(nombre))
                {
                    return true;
                }
            }

            return false;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Componente selectedItem = (Componente)cboComponente.SelectedItem;

            if (existeEnGrilla(selectedItem.Nombre))
            {
                MessageBox.Show("Ese componente ya esta cargado");
                return;
            }
            if (string.IsNullOrEmpty(txtDT.Text))
            {
                MessageBox.Show("Debe ingresar un Modelo");
                return;
            }
            if (nudCantidad.Value < 1)
            {
                MessageBox.Show("Debe agregar la cantidad de componentes");
                return;
            }
            int cantidad = int.Parse(nudCantidad.Value.ToString());

            DetalleOrden det = new DetalleOrden(auxDetalle, selectedItem, cantidad);
            int total = Convert.ToInt32(nudCantidad.Value * numericUpDown1.Value);
            nuevaOrden.AgregarDetalle(det);
            dgvDetalles.Rows.Add(new object[] { det.Componente, det.Cantidad, total });
            auxDetalle++;

        }



        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            if (dtpFecha.Value < DateTime.Today)
            {
                MessageBox.Show("Debe ingresar una fecha valida");
                return;
            }

            if (dgvDetalles.Rows.Count == 0 || dgvDetalles.Rows.Count == 1)
            {
                MessageBox.Show("Debe ingresar al menos 2 componentes");
                return;
            }
            nuevaOrden.Modelo = txtDT.Text;
            nuevaOrden.Fecha = dtpFecha.Value;
            nuevaOrden.Cantidad = Convert.ToInt32(nudCantidad.Value);
            nuevaOrden.Estado = "Creada";

            string json = JsonConvert.SerializeObject(nuevaOrden);
            string url = "https://localhost:7194/api/OrdenProduccion";
            var resp = await HttpHelper.GetInstance().PostAsync(url, json);
            if(resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("¡La orden se cargo exitosamente!");
            }
            else
            {
                MessageBox.Show("Código: " + resp.StatusCode + "|" + resp.Data);
            }



            
            


        }
    }
}

