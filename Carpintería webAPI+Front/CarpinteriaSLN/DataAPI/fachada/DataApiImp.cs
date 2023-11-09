using CarpinteriaApp.datos.Implementacion;
using CarpinteriaApp.datos.Interfaz;
using CarpinteriaApp.dominio;

namespace DataAPI.fachada
{
    public class DataApiImp : IDataApi
    {
        private IDaoPresupuesto dao;

        public DataApiImp()
        {
            dao = new PresupuestoDao();
        }

        public List<Producto> GetProductos()
        {
            return dao.ObtenerProductos();
        }

        public bool SavePresupuesto(Presupuesto presupuesto)
        {
            return dao.Crear(presupuesto);
        }

        public Presupuesto GetPresupuestoById(int id)
        {
            return dao.ObtenerPresupuestoPorNro(id);
        }

        public List<Presupuesto> GetPresupuestos(DateTime desde, DateTime hasta, string cliente)
        {
            return dao.ObtenerPresupuestosPorFiltros(desde, hasta, cliente);
        }
    }
}
