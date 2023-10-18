using APIFechas.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFechas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FechasController : ControllerBase
    {
        [HttpGet]
        public Fecha Get()
        {
            return new Fecha();
        }

        [HttpGet("dia")]
        public string GetNumeroDia()
        {
            return new Fecha().DiaSemana;
        }

    }
}
