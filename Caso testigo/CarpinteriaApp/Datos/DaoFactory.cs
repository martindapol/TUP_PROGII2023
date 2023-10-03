using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Datos
{
    public class DaoFactory : AbstractDaoFactory
    {
        public override IDaoPresupuesto CrearPresupuestoDao()
        {
            return new PresupuestoDao();
        }
    }
}
