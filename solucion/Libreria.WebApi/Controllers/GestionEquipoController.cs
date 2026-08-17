using Libreria.DTOs.DataTransferObjects.DTOsEquipo;
using Libreria.LogicaAplicacion.ICasosUso.ICUEquipo;
using Libreria.LogicaNegocio.CustomExceptions.EquipoExceptions;
using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class GestionEquipoController : ControllerBase
    {

        private ICUGestionEquipo _CUGestionEquipo;
        private ICUEquipoDisponible _CUEquipoDisponible;

        public GestionEquipoController(ICUGestionEquipo CUGestionEquipo, ICUEquipoDisponible CUEquipoDisponible)
        {
            _CUGestionEquipo = CUGestionEquipo;
            _CUEquipoDisponible = CUEquipoDisponible;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_CUGestionEquipo.ObtenerTodos());
            }
            catch (Exception)
            {
                return StatusCode(500, "Error de servidor");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_CUGestionEquipo.ObtenerPorId(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error de servidor");
            }
        }

        [HttpPost]
        public IActionResult Create(DTOGestionEquipo dto)
        {

            try
            {
                _CUGestionEquipo.Alta(dto);
                return StatusCode(200, "Equipo creado con exito");
            }
            catch (DatoVacioONuloException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (ValorDebeSerMayorACeroException e)
            {
                return BadRequest(e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error de servidor");
            }
        }

        [HttpPut]
        public IActionResult Edit([FromBody] DTOGestionEquipo dto)
        {
            try
            {
                _CUGestionEquipo.Edit(dto);
                return StatusCode(200, "Equipo editado con exito");
            }
            catch (DatoVacioONuloException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (ValorDebeSerMayorACeroException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error de servidor");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _CUGestionEquipo.Delete(id);
                return StatusCode(200, "Equipo Eliminado con exito");
            }
            catch (EquipoNoExisteException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (EquipoEnPrestamoException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error de servidor");
            }
        }
        [AllowAnonymous]
        [HttpGet("disponibilidad/{id}")]
            public IActionResult GetDisponibilidad(int id)
            {
                try
                {
                    var dto = _CUEquipoDisponible.Ejecutar(id);
                    return StatusCode (200, dto);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }

        [AllowAnonymous]
        [HttpGet("combo")]
        public IActionResult Combo()
        {
            return Ok(_CUGestionEquipo.ObtenerTodos());
        }
    }
}

