using Libreria.DTOs.DataTransferObjects.DTOsUsuario;
using Libreria.LogicaAplicacion.CasosUso.CUUsuario;
using Libreria.LogicaAplicacion.ICasosUso.ICUUsuario;
using Libreria.LogicaNegocio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace Libreria.WebApp.Controllers
{
    public class LoginController : Controller
    {
        private ICULoginUsuario _CULoginUsuario;

        public LoginController(ICULoginUsuario CULoginUsuario)
        {
            _CULoginUsuario = CULoginUsuario;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(DTOLoginUsuario dto)
        {
            try
            {
                Usuario user = _CULoginUsuario.Ejecutar(dto);

                // Guardar usuario en sesión
                HttpContext.Session.SetString("Usuario", user.NombreUsuario);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                ViewBag.msg = e.Message;
                return View();
            }
        }
    }

}
