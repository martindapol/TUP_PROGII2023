using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.dominio
{
    public class Presupuesto
    {
        public int PresupuestoNro { get; set; }
        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public double CostoMO { get; set; }
        public double Descuento { get; set; }
        public DateTime fechaBaja { get; set; }

        public List<DetallePresupuesto> Detalles { get; set; }

        public Presupuesto()
        {
            Detalles = new List<DetallePresupuesto>();
        }

        public void AgregarDetalle(DetallePresupuesto detalle) {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice) {
            Detalles.RemoveAt(indice);
        }


        public double CalcularTotal() {
            double total = 0;
            foreach (DetallePresupuesto item in Detalles)
                total += item.CalcularSubTotal();
            return total;
        }

        public double CalcularTotalConDescuento()
        {
            double final = this.CalcularTotal();
            if(Descuento > 0)
            {
                final -= final * Descuento/ 100;
            }
            return final;
        }

    }
}
