using CarpinteriaApp.datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpinteriaApp.formularios
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
            //En el título de la ventana agregamos el número de presupuesto
            this.Text = this.Text + presupuestoNro.ToString();
            string sp = "SP_CONSULTAR_DETALLES_PRESUPUESTO";
            List<Parametro> lst = new List<Parametro>();
            lst.Add(new Parametro("@presupuesto_nro", presupuestoNro));

            DataTable dt =  HelperDB.ObtenerInstancia().ConsultaSQL(sp, lst);
            bool primero = true;

            foreach (DataRow fila in dt.Rows){
                //Solo para la primer fila recuperamos los datos del maestro:
                if (primero) {
                    txtCliente.Text = fila["cliente"].ToString();
                    txtFecha.Text = fila["fecha"].ToString();
                    txtTotal.Text = fila["total"].ToString();
                    txtDto.Text = fila["descuento"].ToString();
                    primero = false;
                }
                dgvDetalles.Rows.Add(new object[] { fila["n_producto"].ToString(),
                    fila["precio"].ToString(),
                    fila["cantidad"]
                });
            }
        
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
