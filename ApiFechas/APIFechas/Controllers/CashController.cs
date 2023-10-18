using APIFechas.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFechas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashController : ControllerBase
    {
        //variable compartida entre todas las instancias de CashController
        private static List<Moneda> lst = new List<Moneda>();

       
        // GET: api/Cash
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(lst);//Devuelvo un código 200 OK con un body que tiene una lista de monedas
        }

        // GET api/Cash/dolar
        [HttpGet("{nombre}")]
        public IActionResult Get(string nombre)
        {
           foreach(Moneda x in lst)
            {
                if (x.Nombre.Equals(nombre))
                    return Ok(x);
            }

            return NotFound($"{nombre} No registrada!");
        }

        // POST api/<CashController>
        [HttpPost]
        public IActionResult Post([FromBody] Moneda moneda)
        {
            if(moneda == null || !(moneda is Moneda))
            {
                return BadRequest();
            }

            lst.Add(moneda);
            return Ok("Moneda registrada exitosamente!");
        }

     
    }
}
