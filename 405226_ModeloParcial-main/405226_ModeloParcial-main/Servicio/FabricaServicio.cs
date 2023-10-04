using ModeloParcial.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Servicio
{
    public abstract class FabricaServicio
    {
        public abstract IServicio CrearServicio();
    }
}
