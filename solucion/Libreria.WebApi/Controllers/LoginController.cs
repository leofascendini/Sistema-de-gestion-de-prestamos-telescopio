using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaAplicacion.IServicios;
using Libreria.LogicaNegocio.CustomExceptions.GenericasExceptions;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Libreria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ICULoginUsuario _CULoginUsuario;
        private IServicioAuth _servicioAuth;

        public LoginController(ICULoginUsuario CULoginUsuario, IServicioAuth servicioAuth)
        {
            _CULoginUsuario = CULoginUsuario;
            _servicioAuth = servicioAuth;
        }

        [HttpPost]
        public IActionResult Create(DTOLoginUsuario dto) 
        {
            try
            {
               Usuario usuario = _CULoginUsuario.Ejecutar(dto);
                string token = _servicioAuth.GenerarToken(usuario);

                return StatusCode(200, new {token = token, rol = usuario.Rol.Nombre});
            }
            catch (DatoVacioONuloException e)
            {
                return StatusCode(409, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error de servidor");
            }

        }
    }
}
