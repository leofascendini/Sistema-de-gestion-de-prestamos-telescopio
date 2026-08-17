using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{
    public class PrestamoController : Controller
    {
        private HttpClient _httpClient;

        public PrestamoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> List()
        {
            var token = HttpContext.Session.GetString("token");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            var response = await _httpClient.GetAsync("api/Prestamo");

            if (!response.IsSuccessStatusCode)
                return View(new List<AltaPrestamoModel>());

            var json = await response.Content.ReadAsStringAsync();

            var prestamos = JsonSerializer.Deserialize<List<AltaPrestamoModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(prestamos);
        }

        public IActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Alta(AltaPrestamoModel model)
        {
            var token = HttpContext.Session.GetString("token");

            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);
            }

            var json = JsonSerializer.Serialize(model);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/AltaPrestamo", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Mensaje"] = "Prestamo creado correctamente";
                return RedirectToAction("Alta");
            }

            var error = await response.Content.ReadAsStringAsync();
            ViewBag.Error = error;

            return View(model);
        }
    }
}