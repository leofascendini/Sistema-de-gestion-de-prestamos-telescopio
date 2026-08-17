using Libreria.LogicaAplicacion.ICasosUso.ICUTelescopio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Administrador,Coordinador")]
    [Route("api/[controller]")]
    [ApiController]
    public class TelescopioListadoController : ControllerBase
    {
        private ICUTelescopioListado _cuTelescopioListado;

        public TelescopioListadoController(
            ICUTelescopioListado cuTelescopioListado)
        {
            _cuTelescopioListado = cuTelescopioListado;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode (200, _cuTelescopioListado.Ejecutar());
            }
            catch
            {
                return StatusCode(500, "Problema de servidor");
            }
        }
    }
}
