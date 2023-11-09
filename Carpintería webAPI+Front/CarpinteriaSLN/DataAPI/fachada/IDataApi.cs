using CarpinteriaApp.datos;
using CarpinteriaApp.dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAPI.fachada
{
    public interface IDataApi
    {
        public List<Producto> GetProductos();
        public List<Presupuesto> GetPresupuestos(DateTime desde, DateTime hasta, string cliente);

        public Presupuesto GetPresupuestoById(int id);
        public bool SavePresupuesto(Presupuesto presupuesto);
    }
}
