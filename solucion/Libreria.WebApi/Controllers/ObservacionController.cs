using Libreria.DTOs.DataTransferObjects.DTOsObservacionAstro;
using Libreria.LogicaAplicacion.CasosUso.CUPrestamo;
using Libreria.LogicaAplicacion.ICasosUso.ICUObservacionAstro;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.CustomExceptions.ObjetoCelesteExceptions;
using Libreria.LogicaNegocio.CustomExceptions.PestamosExceptions;
using Libreria.LogicaNegocio.CustomExceptions.PrestamoExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Socio")]
    [Route("api/[controller]")]
    [ApiController]
    public class ObservacionController : ControllerBase
    {
        private ICUAltaObservacion _cuAltaObservacion;
        private ICUEvaluarObservacion _cuEvaluarObservacion;
        private ICUPrestamosVigentes _cuPrestamosVigentes;

        public ObservacionController(ICUAltaObservacion cuAltaObservacion, ICUEvaluarObservacion cuEvaluarObservacion, ICUPrestamosVigentes cuPrestamosVigentes)
        {
            _cuAltaObservacion = cuAltaObservacion;
            _cuEvaluarObservacion = cuEvaluarObservacion;
            _cuPrestamosVigentes = cuPrestamosVigentes;
        }

        [HttpPost("evaluar")]
        public async Task<IActionResult> EvaluarObservacion([FromBody] DTOAltaObservacion dto)
        {
            try
            {
                int usuarioId = int.Parse(
                    User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);

                DTOResultadoAltaObservacion resultado =
                    await _cuEvaluarObservacion.Evaluar(dto, usuarioId);

                return StatusCode(200, resultado);
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
            catch (FechaNoEsValidaExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (ObjetoCelesteNoExisteExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch
            {
                return StatusCode(500, "Problema de servidor");
            }
        }

        [HttpGet("prestamos-vigentes")]
        public IActionResult GetPrestamosVigentes()
        {
            try
            {
                int usuarioId = int.Parse(
                    User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)!.Value);

                var prestamos = _cuPrestamosVigentes.ListarPrestamosVigentes(usuarioId);

                return Ok(prestamos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Problema de servidor");
            }
        }

        [HttpPost("confirmar")]
        public IActionResult ConfirmarObservacion([FromBody] DTOConfirmarObservacionRequest request)
        {
            try
            {
                if (request == null)
                    return BadRequest("Request inválido");

                if (request.AltaObservacion == null)
                    return BadRequest("Debe ingresar los datos de la observación");

                if (request.Resultado == null)
                    return BadRequest("Primero debes evaluar la observación antes de confirmar");

                _cuAltaObservacion.Alta(request.AltaObservacion, request.Resultado);

                return Ok("Observación guardada correctamente");
            }
            catch (PrestamoNoExisteExceptions e)
            {
                return BadRequest(e.Message);
            }
            catch (PrestamoNoPerteneceAUsuarioExceptions e)
            {
                return BadRequest(e.Message);
            }
            catch (PrestamoNoEsActivoExceptions e)
            {
                return BadRequest(e.Message);
            }
            catch (FechaNoEsValidaExceptions e)
            {
                return BadRequest(e.Message);
            }
            catch (ObjetoCelesteNoExisteExceptions e)
            {
                return BadRequest(e.Message);
            }
            catch
            {
                return StatusCode(500, "Problema de servidor");
            }
        }
    }
}
