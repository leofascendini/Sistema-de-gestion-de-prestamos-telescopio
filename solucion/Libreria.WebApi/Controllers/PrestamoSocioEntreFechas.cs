using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Socio")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoSocioController : ControllerBase
    {
        private ICUPrestamoListadoEntreFechas _cuPrestamoListadoEntreFechas;

        public PrestamoSocioController(ICUPrestamoListadoEntreFechas cuPrestamoListadoEntreFechas)
        {
            _cuPrestamoListadoEntreFechas = cuPrestamoListadoEntreFechas;
        }

        [HttpGet]
        public IActionResult Get(int mes, int anio)
        {
            try
            {
                int usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                return StatusCode(200, _cuPrestamoListadoEntreFechas.ListarPrestamoEntreFechas(usuarioId, mes, anio));
            }
            catch (PrestamoNoExisteExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error de servidor");
            }
        }
    }
}
