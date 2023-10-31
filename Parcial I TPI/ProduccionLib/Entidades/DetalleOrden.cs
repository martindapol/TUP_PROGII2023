using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionLib.Entidades
{
    public class DetalleOrden
    {
        
        public int Id { get; set; }

        public Componente Componente { get; set; }

        public int Cantidad { get; set; }

        public DetalleOrden(int id, Componente componente, int cantidad)
        {
            Id = id;
            Componente = componente;
            Cantidad = cantidad;
        }

    }
}
