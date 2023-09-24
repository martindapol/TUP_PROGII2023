using CarpinteriaApp.Datos;
using CarpinteriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Servicios
{
    public class GestorProductos
    {
        private IProductoDao dao;

        public GestorProductos(IProductoDao dao)
        {
            this.dao = dao;
        }

        public List<Producto> ObtenerProductos()
        {
            return dao.GetAll();
        }
    }
}
