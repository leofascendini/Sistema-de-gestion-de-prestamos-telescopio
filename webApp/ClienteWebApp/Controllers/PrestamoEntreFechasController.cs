using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{
    using System.Net.Http.Headers;
    using System.Text.Json;

    public class PrestamoEntreFechasController : Controller
    {
        private HttpClient _httpClient;

        public PrestamoEntreFechasController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> List(int mes, int anio)
        {
            if (mes == 0 || anio == 0)
                return View(new List<PrestamoEntreFechaModel>());

            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(
                $"api/PrestamoSocio?mes={mes}&anio={anio}"
            );

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<PrestamoEntreFechaModel>());
            }

            var json = await response.Content.ReadAsStringAsync();

            var prestamos = JsonSerializer.Deserialize<List<PrestamoEntreFechaModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(prestamos);
        }
    }
}
