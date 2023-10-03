using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialApp.Acceso_a_datos
{
    interface IDao
    {

        List<Material> GetProductos();
        bool Save(OrdenRetiro oFactura);

    }
}
