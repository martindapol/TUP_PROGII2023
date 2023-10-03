using CarpinteriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Datos
{
    public interface IDaoPresupuesto
    {
        int ProximoPresupuesto();
        bool Crear(Presupuesto oPresupuesto);

        Presupuesto ObtenerPresupuestoPorNumero(int numero);
        List<Presupuesto> ObtenerTodos();

        List<Presupuesto> ObtenerConFiltros(DateTime fecDesde, DateTime fecHasta, string cliente);

        int Actualizar(Presupuesto oPresupuesto);

        int Eliminar(int nroPresupuesto);

    }
}
