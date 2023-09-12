using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.dominio
{
    public class Producto
    {
        public int ProductoNro { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public bool Activo { get; set; }

        public Producto(int nro, string nom, double pre)
        {
            ProductoNro = nro;
            Nombre = nom;
            Precio = pre;
            Activo = true;
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
