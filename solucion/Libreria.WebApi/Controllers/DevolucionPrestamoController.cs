using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions;
using Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Coordinador")]
    [Route("api/[controller]")]
    [ApiController]
    public class DevolucionPrestamoController : ControllerBase
    {
        private  ICUPrestamoListado _icuListadoPrestamo;
        private  ICUDevolucionPrestamo _icuDevolucionPrestamo;

        public DevolucionPrestamoController(ICUPrestamoListado icuListadoPrestamo, ICUDevolucionPrestamo icuDevolucionPrestamo)
        {
            _icuListadoPrestamo = icuListadoPrestamo;
            _icuDevolucionPrestamo = icuDevolucionPrestamo;
        }

        [HttpGet("usuario/{usuarioId}/prestamo-activo")]
        public IActionResult GetPrestamosEnPrestamo(int usuarioId)
        {
            try
            {
                var prestamos = _icuListadoPrestamo.ListarPrestamo(usuarioId);
                return StatusCode(200, prestamos);
            }
            catch (PrestamoNoExisteExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Problema de servidor");
            }
        }

        [HttpPut("devolver")]
        public IActionResult DevolverPrestamo([FromBody] DTODevolucionPrestamo dto)
        {
            try
            {
                _icuDevolucionPrestamo.DevolverPrestamo(dto);
                return StatusCode(200, "Préstamo devuelto correctamente");
            }
            catch (PrestamoNoExisteExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (PrestamoNoPerteneceAUsuarioExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (PrestamoNoEsActivoExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Problema de servidor");
            }
        }
    }
}
