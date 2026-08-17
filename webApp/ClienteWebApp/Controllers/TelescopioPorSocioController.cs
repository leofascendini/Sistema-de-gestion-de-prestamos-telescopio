using ClienteWebApp.Models;
using ClienteWebApp.Models.ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{
    using System.Net.Http.Headers;
    using System.Text.Json;

    public class TelescopioPorSocioController : Controller
    {
        private HttpClient _httpClient;

        public TelescopioPorSocioController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public async Task<IActionResult> List(int? telescopioId)
        {
            var token = HttpContext.Session.GetString("token");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);

            var vista = new TelescopioPorSocioVistaModel();

            var responseTelescopios = await _httpClient.GetAsync(
                "api/TelescopioListado"
            );

            if (responseTelescopios.IsSuccessStatusCode)
            {
                var jsonTelescopios =
                    await responseTelescopios.Content.ReadAsStringAsync();

                vista.Telescopios =
                    JsonSerializer.Deserialize<List<TelescopioListadoModel>>(
                        jsonTelescopios,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    ) ?? new List<TelescopioListadoModel>();
            }

            if (!telescopioId.HasValue)
            {
                return View(vista);
            }

            vista.TelescopioId = telescopioId.Value;

            var responseSocios = await _httpClient.GetAsync(
                $"api/TelescopioPorSocio/{telescopioId}"
            );

            if (!responseSocios.IsSuccessStatusCode)
            {
                ViewBag.Error = await responseSocios.Content.ReadAsStringAsync();
                return View(vista);
            }

            var jsonSocios =
                await responseSocios.Content.ReadAsStringAsync();

            vista.Socios =
                JsonSerializer.Deserialize<List<TelescopioPorSocioModel>>(
                    jsonSocios,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                ) ?? new List<TelescopioPorSocioModel>();

            return View(vista);
        }
    }
}

