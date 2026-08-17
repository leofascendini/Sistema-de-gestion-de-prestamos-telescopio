using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{
    using System.Net.Http.Headers;
    using System.Text.Json;

    public class RankingObjetoCelesteController : Controller
    {
        private HttpClient _httpClient;

        public RankingObjetoCelesteController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> List()
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(
                "api/RankingObjetoCeleste"
            );

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = await response.Content.ReadAsStringAsync();
                return View(new List<RankingObjetoCelesteModel>());
            }

            var json = await response.Content.ReadAsStringAsync();

            var ranking = JsonSerializer.Deserialize<List<RankingObjetoCelesteModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(ranking);
        }
    }
}
