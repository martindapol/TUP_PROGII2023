using ModeloParcial.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace ModeloParcial.Datos.Interfaz
{
    internal interface IOrdenesDAO
    {
        int ObtenerProximaOrden();
        bool ConfirmarOrden(OrdenRetiro ordenRetiro);
        OrdenRetiro TraerOrdenNro(int nroOrden);
        bool ActualizarOrden(OrdenRetiro ordenRetiro);
        bool BorrarOrden(int nroOrden);
        List<OrdenRetiro> TraerOrdenes(List<Parametro> lParams, string nombreSP);
        List<Material> TraerMateriales();
    }
}
