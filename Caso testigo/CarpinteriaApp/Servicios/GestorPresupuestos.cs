using CarpinteriaApp.Datos;
using CarpinteriaApp.Entidades;
using CarpinteriaApp.Servicios.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpinteriaApp.Servicios
{
    public class GestorPresupuestos
    {
        private IDaoPresupuesto dao;

        public GestorPresupuestos(AbstractDaoFactory factory)
        {
            this.dao = factory.CrearPresupuestoDao();
        }

        public string ProximoPresupuesto()
        {
            return dao.ProximoPresupuesto().ToString();
        }

        public bool ConfirmarPresupuesto(Presupuesto nuevo)
        {
            return dao.Crear(nuevo);
        }

        //Recuperar Presupuestos con filtros y devolver DTOs para la pantalla:
        public List<PresupuestoDTO> ObtenerPresupuestosConFiltros(DateTime desde, DateTime hasta, string cliente)
        {
            List<PresupuestoDTO> result = new List<PresupuestoDTO>();
            List<Presupuesto> lst = dao.ObtenerConFiltros(desde, hasta, cliente);
            foreach(Presupuesto x in lst)
            {
                PresupuestoDTO dto = new PresupuestoDTO();
                dto.PresupuestoNro = x.PresupuestoNro;
                dto.Fecha = x.Fecha;
                dto.Cliente = x.Cliente;
                dto.Total = (float) x.CalcularTotal();

            }
            return result;
        }

    }
}
