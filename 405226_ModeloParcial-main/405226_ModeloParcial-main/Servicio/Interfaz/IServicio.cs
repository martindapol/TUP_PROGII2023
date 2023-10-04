using ModeloParcial.Datos;
using ModeloParcial.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ModeloParcial.Servicio.Interfaz
{
    public interface IServicio
    {
        int ObtenerNroProxCarga();
        List<Material> TraerMateriales();
        OrdenRetiro TraerOrden(int nroOrden);
        List<OrdenRetiro> TraerOrdenes(List<Parametro> lParams, string comandoSP);
        bool ConfirmarOrden(OrdenRetiro ordenRetiro);
        bool ActualizarOrden(OrdenRetiro ordenRetiro);
        bool BorrarOrden(int nroOrden);
    }
}
