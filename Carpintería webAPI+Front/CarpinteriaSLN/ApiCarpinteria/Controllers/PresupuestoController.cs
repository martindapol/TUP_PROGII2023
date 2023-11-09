using CarpinteriaApp.dominio;
using DataAPI.fachada;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCarpinteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {
        private IDataApi dataApi; //punto de acceso a la API

        public PresupuestoController()
        {
            dataApi = new DataApiImp();
        }

        [HttpGet("/productos")]
        public IActionResult GetProductos()
        {
            List<Producto> lst = null;
            try
            {
                lst = dataApi.GetProductos();
                return Ok(lst);

            }
            catch (Exception ex) {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }


        [HttpGet("/presupuestos")]
        public IActionResult GetPresupuestos(DateTime desde, DateTime hasta, string? cliente = null)
        {
            List<Presupuesto> lst = null;
            try
            {
                //Si el parámetro cliente no se envía entonces cliente es igual a null
                //Para evitar un error de parámetro requerido se inicializa con una cadena vacía
                cliente = cliente != null ? cliente: String.Empty;
                lst = dataApi.GetPresupuestos(desde, hasta, cliente);
                return Ok(lst);

            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpGet("/presupuestos/{id}")]
        public IActionResult GetPresupuestoPorId(int id)
        {
            try
            {
                Presupuesto presupuesto = dataApi.GetPresupuestoById(id);
                if (presupuesto != null)
                    return Ok(presupuesto);
                else
                    return NotFound("Presupuesto Nro: " + id + " NO encontrado!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPost("/presupuesto")]
        public IActionResult PostPresupuesto(Presupuesto presupuesto)
        {
            try
            {
                if(presupuesto == null)
                {
                    return BadRequest("Datos de presupuesto incorrectos!");
                }

                return Ok(dataApi.SavePresupuesto(presupuesto));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }


    }
}
