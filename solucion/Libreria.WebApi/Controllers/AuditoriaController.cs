using Libreria.LogicaAplicacion.CasosUso.CUAuditoria;
using Libreria.LogicaAplicacion.ICasosUso.ICUAuditoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApi.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuditoriaController : ControllerBase
    {
        private ICUAuditoria _icuAuditoria;

        public AuditoriaController(ICUAuditoria icuAuditoria)
        {
            _icuAuditoria = icuAuditoria;
        }

        [HttpGet]
        public IActionResult Get(int? coordinadorId)
        {
            try
            {
                var auditorias = _icuAuditoria.Obtener(coordinadorId);

                Console.WriteLine($"Coordinador recibido: {coordinadorId}");
                var resultado = _icuAuditoria.Obtener(coordinadorId);


                Console.WriteLine($"Cantidad encontrada: {resultado.Count}");

                return StatusCode(200, auditorias);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error de servidor");
            }
        }

        [HttpGet("{prestamoId}")]
        public IActionResult GetByPrestamo(int prestamoId)
        {
            try
            {
                var auditorias = _icuAuditoria.ObtenerPorPrestamo(prestamoId);
                Console.WriteLine("ENTRO AL DETALLE");
                Console.WriteLine($"Prestamo recibido: {prestamoId}");
                Console.WriteLine($"Cantidad encontrada: {auditorias.Count}");

                return StatusCode (200, auditorias);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error de servidor");
            }
        }
    }
}