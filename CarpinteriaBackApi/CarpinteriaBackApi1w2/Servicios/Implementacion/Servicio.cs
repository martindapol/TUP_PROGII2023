using CarpinteriaApp.Datos;
using CarpinteriaApp.Datos.Implementacion;
using CarpinteriaApp.Datos.Interfaz;
using CarpinteriaApp.Entidades;
using CarpinteriaApp.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private IPresupuestoDao dao;
        public Servicio()
        {
            dao = new PresupuestoDao();
        }
        public bool CrearPresupuesto(Presupuesto oPresupuesto)
        {
           return dao.Crear(oPresupuesto);
        }

        public List<Producto> TraerProductos()
        {
            return dao.ObtenerProductos();
        }

        public int TraerProximoPresupuesto()
        {
            return dao.ObtenerProximoPresupuesto(); 
        }

        public List<Presupuesto> TraerPresupuestosFiltrados(List<Parametro> lFiltros)
        {
            return dao.ObtenerPresupuestosPorFiltros(lFiltros);
        }
    }
}
