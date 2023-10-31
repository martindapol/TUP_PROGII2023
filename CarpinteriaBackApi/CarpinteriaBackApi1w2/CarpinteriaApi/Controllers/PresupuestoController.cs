using CarpinteriaBack.Entidades;
using CarpinteriaBack.Fachada.Implementacion;
using CarpinteriaBack.Fachada.Interfaz;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarpinteriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PresupuestoController : ControllerBase
    {
        private IAplicacion app;
        public PresupuestoController()
        {
            app= new Aplicacion();
        }

        // GET: api/<PresupuestoController>
        [HttpGet("/productos")]
        public IActionResult GetProductos()
        {
            List<Producto> lst = null;
            try
            {
                lst = app.GetProductos();
                return Ok(lst);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno!!! Intente luego...");
            }
            
        }


        // POST api/<PresupuestoController>
        [HttpPost("/presupuesto")]
        public IActionResult PostPresupuesto(Presupuesto oPresupuesto)
        {
            try
            {
                if (oPresupuesto == null)
                    return BadRequest("Presupuesto inválido!!!");
                if (app.SavePresupuesto(oPresupuesto))
                    return Ok(oPresupuesto);
                else
                    return NotFound("No se pudo guardar el presupuesto!!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno!!! Intente luego...");
            }
            
        }

        //// GET api/<PresupuestoController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
        //// PUT api/<PresupuestoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PresupuestoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
