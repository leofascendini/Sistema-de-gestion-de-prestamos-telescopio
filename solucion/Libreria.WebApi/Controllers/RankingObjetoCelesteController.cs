using Libreria.LogicaAplicacion.ICasosUso.ICUObjetoCeleste;
using Libreria.LogicaNegocio.CustomExceptions.ObjetosObservadosExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RankingObjetoCelesteController : ControllerBase
    {
        private ICURankingObjetosCelestes _cuRankingObjetosCelestes;

        public RankingObjetoCelesteController(
            ICURankingObjetosCelestes cuRankingObjetosCelestes)
        {
            _cuRankingObjetosCelestes = cuRankingObjetosCelestes;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return StatusCode(200,_cuRankingObjetosCelestes.Ejecutar());
            }
            catch (NoHayObjetosObservadosExceptions e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}
