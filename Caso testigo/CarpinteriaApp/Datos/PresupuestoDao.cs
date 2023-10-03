using CarpinteriaApp.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Datos
{
    public class PresupuestoDao : IDaoPresupuesto
    {
        public int Actualizar(Presupuesto oPresupuesto)
        {
            throw new NotImplementedException();
        }

        public bool Crear(Presupuesto oPresupuesto)
        {
            return DBHelper.GetInstancia().ConfirmarPresupuesto(oPresupuesto);
        }

        public int Eliminar(int nroPresupuesto)
        {
            throw new NotImplementedException();
        }

        public List<Presupuesto> ObtenerConFiltros(DateTime fecDesde, DateTime fecHasta, string cliente)
        {
            throw new NotImplementedException();
        }

        public Presupuesto ObtenerPresupuestoPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Presupuesto> ObtenerTodos()
        {
            throw new NotImplementedException();
        }

        public int ProximoPresupuesto()
        {
            return DBHelper.GetInstancia().ProximoPresupuesto();
        }
    }
}
