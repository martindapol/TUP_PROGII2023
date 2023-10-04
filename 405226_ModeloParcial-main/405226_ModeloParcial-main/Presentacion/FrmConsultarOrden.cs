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
    public partial class FrmConsultarOrden : Form
    {
        IServicio servicioDatos;
        OrdenRetiro orden;
        public FrmConsultarOrden(FabricaServicio fabrica,int nro)
        {
            InitializeComponent();
            servicioDatos = fabrica.CrearServicio();
            orden = servicioDatos.TraerOrden(nro);
        }

        private void FrmConsultarOrden_Load(object sender, EventArgs e)
        {
            lblOrdenNro.Text += orden.nroOrden;
            dtpFecha.Value = orden.fechaOrden;
            dtpFecha.Enabled = false;
            txtResponsable.Text = orden.responsableOrden;
            txtResponsable.Enabled = false;
            foreach (DetalleOrden d in orden.listaDetalles)
            {
                dgvDetalles.Rows.Add(new object[] {d.idDetalle,d.materialDetalle.nombreMaterial,d.cantidadDetalle });
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
