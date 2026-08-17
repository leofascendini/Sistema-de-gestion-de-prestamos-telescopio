using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;

    public class ObservacionController : Controller
    {
        private HttpClient _httpClient;

        public ObservacionController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> PrestamosVigentes()
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(
                "api/Observacion/prestamos-vigentes"
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
        public async Task<IActionResult> Evaluar(ObservacionModel model)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(
                "api/Observacion/evaluar",
                content
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Observacion evaluada correctamente";
                TempData[$"Eval_{model.PrestamoId}"] = "OK";
                return RedirectToAction("PrestamosVigentes");
            }

            TempData["Error"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("PrestamosVigentes");
        }

        [HttpPost]
        public async Task<IActionResult> Confirmar(ObservacionModel model)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(
                "api/Observacion/confirmar",
                content
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Observación confirmada correctamente";
                return RedirectToAction("PrestamosVigentes");
            }

            TempData["Error"] = await response.Content.ReadAsStringAsync();
            return RedirectToAction("PrestamosVigentes");
        }
    }
}
