using CarpinteriaApp.dominio;
using CarpinteriaFront.Http;
using Newtonsoft.Json;

namespace CarpinteriaFront
{
    public partial class FrmDetallesPresupuesto : Form
    {
        private int presupuestoNro;
        public FrmDetallesPresupuesto(int presupuestoNro)
        {
            InitializeComponent();
            this.presupuestoNro = presupuestoNro;
        }

        private void FrmDetallesPresupuesto_Load(object sender, EventArgs e)
        {
            this.Text = this.Text + presupuestoNro.ToString();
            CargarPresupuesto();
        }

        private async void CargarPresupuesto()
        {
            string url = string.Format("http://localhost:5031/presupuestos/{0}", presupuestoNro);
            var result = await ClientSingleton.GetInstance().GetAsync(url);

            var presupuesto = JsonConvert.DeserializeObject<Presupuesto>(result);
            if(presupuesto != null)
            {
                txtCliente.Text = presupuesto.Cliente;
                txtDto.Text = presupuesto.Descuento.ToString();
                txtFecha.Text = presupuesto.Fecha.ToString("dd/MM/yyyy");
                txtTotal.Text = presupuesto.CalcularTotal().ToString();

                foreach (DetallePresupuesto detalle in presupuesto.Detalles)
                {
                    dgvDetalles.Rows.Add(new object[] { detalle.Producto.Nombre, detalle.Producto.Precio, detalle.Cantidad });
                }
            }
            else
            {
                MessageBox.Show("No se pudo recuperar información del presupuesto", "Presupuestos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}