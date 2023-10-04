using ModeloParcial.Datos;
using ModeloParcial.Datos.Implementacion;
using ModeloParcial.Datos.Interfaz;
using ModeloParcial.Dominio;
using ModeloParcial.Servicio.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModeloParcial.Servicio.Implementacion
{
    internal class Servicio:IServicio
    {
        IOrdenesDAO ordenesDAO;

        public Servicio()
        {
            ordenesDAO = new OrdenesDAO();
        }

        public bool ActualizarOrden(OrdenRetiro ordenRetiro)
        {
            return ordenesDAO.ActualizarOrden(ordenRetiro);
        }

        public bool BorrarOrden(int nroOrden)
        {
            return ordenesDAO.BorrarOrden(nroOrden);
        }

        public bool ConfirmarOrden(OrdenRetiro ordenRetiro)
        {
            return ordenesDAO.ConfirmarOrden(ordenRetiro);
        }

        public int ObtenerNroProxCarga()
        {
            return ordenesDAO.ObtenerProximaOrden();
        }

        public List<Material> TraerMateriales()
        {
            return ordenesDAO.TraerMateriales();
        }

        public OrdenRetiro TraerOrden(int nroOrden)
        {
            return ordenesDAO.TraerOrdenNro(nroOrden);
        }

        public List<OrdenRetiro> TraerOrdenes(List<Parametro> lParams, string comandoSP)
        {
            return ordenesDAO.TraerOrdenes(lParams,comandoSP);
        }
    }
}
