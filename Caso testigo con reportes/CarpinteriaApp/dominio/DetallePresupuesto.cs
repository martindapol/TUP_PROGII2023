using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.dominio
{
    public class DetallePresupuesto
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public DetallePresupuesto(Producto p, int cant) {
            Producto = p;
            Cantidad = cant;
        }

        public double CalcularSubTotal() {
            return Producto.Precio * Cantidad;
        }

    }
}
