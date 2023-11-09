using CarpinteriaApp.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.datos.Interfaz
{
    public interface IDaoPresupuesto
    {
        List<Producto> ObtenerProductos();
        int ObtenerProximoNro();
        bool Crear(Presupuesto oPresupuesto);
        bool Actualizar(Presupuesto oPresupuesto);
        bool Borrar(int nro);
        List<Presupuesto> ObtenerPresupuestosPorFiltros(DateTime desde, DateTime hasta, string cliente);
        Presupuesto ObtenerPresupuestoPorNro(int nro);
        DataTable ObtenerReporte(DateTime desde, DateTime hasta);
    }
}
