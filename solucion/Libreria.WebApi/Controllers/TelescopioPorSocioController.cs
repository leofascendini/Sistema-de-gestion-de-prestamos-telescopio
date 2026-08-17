using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Administrador,Coordinador")]
    [Route("api/[controller]")]
    [ApiController]
    public class TelescopioPorSocioController : ControllerBase
    {
        private ICUListadoSociosPorTelescopio _cuListadoSociosPorTelescopio;

        public TelescopioPorSocioController(
            ICUListadoSociosPorTelescopio cuListadoSociosPorTelescopio)
        {
            _cuListadoSociosPorTelescopio = cuListadoSociosPorTelescopio;
        }

        [HttpGet("{telescopioId}")]
        public IActionResult Get(int telescopioId)
        {
            try
            {
                var socios =_cuListadoSociosPorTelescopio.ListarSociosPorTelescopio(telescopioId);

                return StatusCode(200, socios);
            }
            catch (PrestamoNoExisteExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Problema de servidor");
            }
        }
    }
}
