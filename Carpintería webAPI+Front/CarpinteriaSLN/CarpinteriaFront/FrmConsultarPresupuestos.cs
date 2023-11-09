using CarpinteriaApp.dominio;
using CarpinteriaFront.Http;
using Newtonsoft.Json;

namespace CarpinteriaFront
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
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("Periodo incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Para enviar parámetros por URL de manera correcta, salvando (escapando)
            //caracteres especiales y blancos se utiliza el método **Uri.EscapeDataString**
            String fecDesde, fecHasta, cliente;
            fecDesde = Uri.EscapeDataString(dtpDesde.Value.ToString("yyyy/MM/dd"));
            fecHasta = Uri.EscapeDataString(dtpHasta.Value.ToString("yyyy/MM/dd"));
            cliente = Uri.EscapeDataString(txtCliente.Text);
            CargarPresupuestos(fecDesde, fecHasta, cliente);
        }

        private async void CargarPresupuestos(string desde, string hasta, string cliente)
        {
            string url = string.Format("http://localhost:5031/presupuestos?desde={0}&hasta={1}", desde, hasta);
            //Si se consulta por cliente, la URL incluye un parámetro adicional cliente= 
            if (!String.IsNullOrEmpty(cliente))
                url = String.Format(url + "&cliente={0}", cliente);

            var result = await ClientSingleton.GetInstance().GetAsync(url);
            var lst = JsonConvert.DeserializeObject<List<Presupuesto>>(result);
            dgvPresupuestos.Rows.Clear();
            if (lst != null)
            {
                foreach (Presupuesto presupuesto in lst)
                {
                    dgvPresupuestos.Rows.Add(new object[] {
                    presupuesto.PresupuestoNro,
                    presupuesto.Fecha.ToString("dd/MM/yyyy"),
                    presupuesto.Cliente,
                    });
                }
            }
            else
            {
                MessageBox.Show("Sin datos de presupuestos para los filtros ingresados", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            /*if (MessageBox.Show("Seguro que desea quitar el presupuesto seleccionado?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (dgvPresupuestos.CurrentRow != null)
                {
                    int nro = int.Parse(dgvPresupuestos.CurrentRow.Cells["colNro"].Value.ToString());
                    if (servicio.BorrarPresupuesto(nro))
                    {
                        MessageBox.Show("El presupuesto se quitó exitosamente!", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.btnConsultar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("El presupuesto NO se quitó exitosamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }*/
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvPresupuestos_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}
