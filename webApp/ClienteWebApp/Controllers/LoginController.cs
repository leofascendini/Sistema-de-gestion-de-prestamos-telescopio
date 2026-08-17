using ClienteWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace ClienteWebApp.Controllers
{
    public class LoginController : Controller
    {
        private HttpClient _httpClient;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("API");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var json = JsonSerializer.Serialize(model);

            var response = await _httpClient.PostAsync(
                "api/Login",
                new StringContent(json, Encoding.UTF8, "application/json")
            );

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Usuario o contraseña incorrectos");
                return View(model);
            }

            var content = await response.Content.ReadAsStringAsync();

            var doc = JsonDocument.Parse(content);

            var token = doc.RootElement.GetProperty("token").GetString();
            var rol = doc.RootElement.GetProperty("rol").GetString();

            HttpContext.Session.SetString("token", token ?? "");
            HttpContext.Session.SetString("Rol", rol ?? "");

            return RedirectToAction("Index", "Home");
        }
    }
}