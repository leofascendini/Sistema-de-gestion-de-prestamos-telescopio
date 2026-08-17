using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;

    public class DevolucionPrestamoController : Controller
    {
        private HttpClient _httpClient;

        public DevolucionPrestamoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> PrestamosActivos(int usuarioId)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(
                $"api/DevolucionPrestamo/usuario/{usuarioId}/prestamo-activo"
            );

            if (!response.IsSuccessStatusCode)
                return View(new List<ListadoPrestamoModel>());

            var json = await response.Content.ReadAsStringAsync();

            var prestamos = JsonSerializer.Deserialize<List<ListadoPrestamoModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(prestamos);
        }

        [HttpPost]
        public async Task<IActionResult> Devolver(DevolucionPrestamoModel model)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(model);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync(
                "api/DevolucionPrestamo/devolver",
                content
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Préstamo devuelto correctamente";
                return RedirectToAction("PrestamosActivos", new { usuarioId = model.UsuarioId });
            }

            var error = await response.Content.ReadAsStringAsync();
            TempData["Error"] = error;

            return RedirectToAction("PrestamosActivos", new { usuarioId = model.UsuarioId });
        }
    }
}
