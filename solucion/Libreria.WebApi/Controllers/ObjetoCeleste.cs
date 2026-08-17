using Libreria.LogicaAplicacion.ICasosUso.ICUObjetoCeleste;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Socio")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ObjetoCeleste : ControllerBase
    {
        private ICUObjetoCelesteListado _CUObjetoListado;
        public ObjetoCeleste(ICUObjetoCelesteListado cuObjetoListado)
        {
            _CUObjetoListado = cuObjetoListado;
        }

        [AllowAnonymous]
        [HttpGet("combo")]
        public IActionResult ObjetosCelestes()
        {
            try
            {
                var objetos = _CUObjetoListado.Listar();

                return StatusCode(200, objetos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Problema de servidor");
            }
        }
    }
}
