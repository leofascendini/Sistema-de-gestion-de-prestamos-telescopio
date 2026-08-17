using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using Libreria.LogicaAplicacion.CasosUso.CUUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private ICUAltaUsuario _CUAltaUsuario;
        private ICUUsuarioListado _CUUsuarioListado;

        public UsuarioController(ICUAltaUsuario CUAltaUsuario, ICUUsuarioListado CUUsuarioListado)
        {
            _CUAltaUsuario = CUAltaUsuario;
            _CUUsuarioListado = CUUsuarioListado;
        }

        [HttpPost]
        public IActionResult Create(DTOAltaUsuario dto)
        {
            try
            {
                _CUAltaUsuario.Ejecutar(dto);
                return StatusCode(200, "Usuario creado con éxito");
            }
            catch (UsuarioYaExisteExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (NombreIncorrectoException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (ApellidoIncorrectoException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (DireccionIncorrectoExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (EmailIncorrectoExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (ContraseñaIncorrectaExceptions e)
            {
                return StatusCode(400, e.Message);
            }
            catch (RolIncorrectoException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (DatoVacioONuloException e)
            {
                return StatusCode(400, e.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error de servidor");
            }
        }

        [AllowAnonymous]
        [HttpGet("combo")]
        public IActionResult Combo()
        {
            return Ok(_CUUsuarioListado.Ejecutar());
        }

    }
}
