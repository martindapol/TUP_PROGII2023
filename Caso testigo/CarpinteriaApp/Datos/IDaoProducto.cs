using CarpinteriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Datos
{
    public interface IProductoDao
    {
        List<Producto> GetAll();
    }
}
