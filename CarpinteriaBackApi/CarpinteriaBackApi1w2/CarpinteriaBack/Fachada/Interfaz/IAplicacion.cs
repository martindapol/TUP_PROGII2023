using CarpinteriaBack.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaBack.Fachada.Interfaz
{
    public interface IAplicacion
    {
        List<Producto> GetProductos();
        bool SavePresupuesto(Presupuesto oPresupuesto);
    }
}
