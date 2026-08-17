using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.CustomExceptions.UsuarioExceptions;
using Libreria.LogicaNegocio.IRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Libreria.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private ICUAltaUsuario _CUAltaUsuario;
        private IRepositorioRol _repoRol;

        public UsuarioController(ICUAltaUsuario CUAltaUsuario, IRepositorioRol repoRol)
        {
            _CUAltaUsuario = CUAltaUsuario;
            _repoRol = repoRol;
        }

        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(
            _repoRol.FindAll(), "RolId", "Nombre"
         );
            return View();
        }

        [HttpPost]
        public IActionResult Create(DTOAltaUsuario dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            try
            {
                _CUAltaUsuario.Ejecutar(dto);

                TempData["msg"] = "Usuario dado de alta correctamente";

                return RedirectToAction("Create");
            }
            catch (UsuarioYaExisteExceptions e)
            {
                ViewBag.Roles = new SelectList(
                    _repoRol.FindAll(),
                    "RolId",
                    "Nombre"
                );

                ViewBag.msg = "Ya hay una persona con ese email";

                return View(dto);
            }
            catch (Exception e)
            {
                ViewBag.Roles = new SelectList(
                    _repoRol.FindAll(),
                    "RolId",
                    "Nombre"
                );

                ViewBag.msg = "Error inesperado, contacte al admin";

                return View(dto);
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Index()
        {
            var usuario = HttpContext.Session.GetString("Usuario");

            if (usuario == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
