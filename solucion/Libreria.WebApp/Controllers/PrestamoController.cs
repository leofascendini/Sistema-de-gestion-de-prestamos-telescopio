using Libreria.DTOs.DataTransferObjects.DTOsPrestamo;
using Libreria.LogicaAplicacion.ICasosUso.ICUPrestamo;
using Libreria.LogicaNegocio.IRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.WebApp.Controllers
{
    public class PrestamoController : Controller
    {
        private  ICUAltaPrestamo _cuAltaPrestamo;
        private  ICUPrestamoListado _cuListado;
        private  ICUCargarDatosPrestamo _cuCargarDatosPrestamo;

        public PrestamoController(
            ICUAltaPrestamo cuAltaPrestamo,
            ICUPrestamoListado cuListado,
            ICUCargarDatosPrestamo cuCargarDatosPrestamo)
        {
            _cuAltaPrestamo = cuAltaPrestamo;
            _cuListado = cuListado;
            _cuCargarDatosPrestamo = cuCargarDatosPrestamo;
        }
                    
        // LISTADO
        public IActionResult Index(int usuarioId)
        {
            return View(_cuListado.ListarPrestamo(usuarioId));
        }

        // CREATE (GET)
        public IActionResult Create()
        {
            return View(_cuCargarDatosPrestamo.Ejecutar());
        }

        // CREATE (POST)
        [HttpPost]
        public IActionResult Create(DTOAltaPrestamo dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(_cuCargarDatosPrestamo.Ejecutar());
                }

                _cuAltaPrestamo.AltaPrestamo(dto);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["error"] = ex.Message;
                return View(_cuCargarDatosPrestamo.Ejecutar());
            }
        }
    }
}