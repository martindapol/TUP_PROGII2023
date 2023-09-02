using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Entidades
{
    internal class Producto
    {
        public int ProductoNro { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public bool Activo { get; set; }

        public Producto()
        {
            ProductoNro= 0;
            Nombre=string.Empty; 
            Precio=0;
            Activo= true;
        }
        public Producto(int productoNro, string nombre, double precio)
        {
            ProductoNro = productoNro;
            Nombre = nombre;
            Precio = precio;
            Activo = true;    
        }
        public override string ToString()
        {
            return Nombre;
        }
    }
}
