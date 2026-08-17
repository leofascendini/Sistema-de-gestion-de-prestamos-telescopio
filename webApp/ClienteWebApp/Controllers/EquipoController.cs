using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.Json;

    public class EquipoController : Controller
    {
        private HttpClient _httpClient;

        public EquipoController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> List()
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync("api/GestionEquipo");

            if (!response.IsSuccessStatusCode)
                return View(new List<EquipoModel>());

            var json = await response.Content.ReadAsStringAsync();

            var equipos = JsonSerializer.Deserialize<List<EquipoModel>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(equipos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipoModel model)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/GestionEquipo", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("List");

            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/GestionEquipo/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("List");

            var json = await response.Content.ReadAsStringAsync();

            var equipo = JsonSerializer.Deserialize<EquipoModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EquipoModel model)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var json = JsonSerializer.Serialize(model);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/GestionEquipo", content);

            if (response.IsSuccessStatusCode)
                return RedirectToAction("List");

            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"api/GestionEquipo/{id}");

            if (!response.IsSuccessStatusCode)
                return RedirectToAction("List");

            var json = await response.Content.ReadAsStringAsync();

            var equipo = JsonSerializer.Deserialize<EquipoModel>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return View(equipo);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EquipoModel model)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync(
                $"api/GestionEquipo/{model.EquipoId}"
            );

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Equipo eliminado correctamente";
                return RedirectToAction("List");
            }

            ViewBag.Error = await response.Content.ReadAsStringAsync();

            var responseGet = await _httpClient.GetAsync(
                $"api/GestionEquipo/{model.EquipoId}"
            );

            if (responseGet.IsSuccessStatusCode)
            {
                var json = await responseGet.Content.ReadAsStringAsync();

                var equipo = JsonSerializer.Deserialize<EquipoModel>(
                    json,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return View(equipo);
            }

            return View(model);
        }
    }
}

