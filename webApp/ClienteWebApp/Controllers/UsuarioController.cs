using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{

    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;

    public class UsuarioController : Controller
    {
        private readonly HttpClient _httpClient;

        public UsuarioController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        [HttpGet]
        public IActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Alta(UsuarioAltaModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var json = JsonSerializer.Serialize(model);

            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsync(
                "api/Usuario",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            if (!response.IsSuccessStatusCode)
            {
                var mensaje = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError("", System.Text.Json.JsonDocument.Parse(mensaje).RootElement.TryGetProperty("errors", out var errors) ? errors.EnumerateObject().First().Value[0].GetString() : mensaje);
                return View(model);
            }

            TempData["Mensaje"] = "Usuario creado correctamente";
            return RedirectToAction("Alta");
        }
    }
}
    


