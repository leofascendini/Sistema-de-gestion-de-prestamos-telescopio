using Microsoft.AspNetCore.Mvc;
using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{
    using System.Net.Http.Headers;
    using System.Text.Json;

    public class AuditoriaController : Controller
    {
        private HttpClient _httpClient;

        public AuditoriaController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> List(int? coordinadorId)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var url = coordinadorId.HasValue
                ? $"api/auditoria?coordinadorId={coordinadorId}"
                : "api/auditoria";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return View(new List<AuditoriaModel>());

            var json = await response.Content.ReadAsStringAsync();

            var auditorias = JsonSerializer.Deserialize<List<AuditoriaModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(auditorias);
        }

        public async Task<IActionResult> Detail(int prestamoId)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(
                $"api/auditoria/{prestamoId}"
            );

            if (!response.IsSuccessStatusCode)
                return View(new List<AuditoriaModel>());

            var json = await response.Content.ReadAsStringAsync();

            var auditorias = JsonSerializer.Deserialize<List<AuditoriaModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(auditorias);
        }
    }
}
