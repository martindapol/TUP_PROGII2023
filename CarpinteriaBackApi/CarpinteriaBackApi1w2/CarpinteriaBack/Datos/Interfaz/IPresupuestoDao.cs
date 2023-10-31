using CarpinteriaBack.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaBack.Datos.Interfaz
{
    public interface IPresupuestoDao
    {
        int ObtenerProximoPresupuesto();
        List<Producto> ObtenerProductos();
        bool Crear(Presupuesto oPresupuesto);
        bool Actualizar(Presupuesto oPresupuesto);
        bool Borrar(int numero);
        List<Presupuesto> ObtenerPresupuestosPorFiltros(List<Parametro> lFiltros);
        Presupuesto ObtenerPresupuestoPorNro(int numero);
    }
}
