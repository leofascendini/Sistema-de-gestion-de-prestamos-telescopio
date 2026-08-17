using Libreria.DTOs.DataTransferObjects.DTOsEquipo;
using Libreria.LogicaAplicacion.ICasosUso.ICUEquipo;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApp.Controllers
{
    public class EquipoController : Controller
    {
        private ICUGestionEquipo _cuGestionEquipo;

        public EquipoController(ICUGestionEquipo cuGestionEquipo)
        {
            _cuGestionEquipo = cuGestionEquipo;
        }

        //LISTADO
        public IActionResult Index()
        {
            var equipos = _cuGestionEquipo.ObtenerTodos();
            return View(equipos);
        }

        //FORM ALTA
        public IActionResult Create()
        {
            return View();
        }

        //ALTA
        [HttpPost]
        public IActionResult Create(DTOGestionEquipo dto)
        {
            try
            {
                _cuGestionEquipo.Alta(dto);

                TempData["msg"] = "Equipo dado de alta correctamente";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                return View(dto);
            }
        }

        //EDITAR (GET)
        public IActionResult Edit(int id)
        {
            // opcional: traer datos y mapear a DTO
            return View();
        }

        //EDITAR (POST)
        [HttpPost]
        public IActionResult Edit(DTOGestionEquipo dto)
        {
            try
            {
                _cuGestionEquipo.Edit(dto);

                TempData["msg"] = "Equipo modificado correctamente";

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                return View(dto);
            }
        }

        //BAJA
        public IActionResult Delete(int id)
        {
            try
            {
                _cuGestionEquipo.Delete(id);

                TempData["msg"] = "Equipo eliminado correctamente";
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }

            return RedirectToAction("Index");
        }
    }
}
