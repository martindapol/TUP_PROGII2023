using ProduccionLib.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionLib.Data
{
    public interface IOrdenDao
    {
        List<Componente> ObtenerComponentes();
        bool CrearOrden(OrdenProduccion orden);

        
    }
}
