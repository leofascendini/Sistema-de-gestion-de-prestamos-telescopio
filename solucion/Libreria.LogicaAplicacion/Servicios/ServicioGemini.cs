using Libreria.DTOs.DataTransferObjects.DTOsObservacionAstro;
using Libreria.LogicaAplicacion.IServicios;
using Libreria.LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.LogicaAplicacion.Servicios
{
    using Libreria.DTOs.IntegracionAPI;
    using Microsoft.Extensions.Configuration;
    using System.Net.Http;
    using System.Net.Http;
    using System.Text;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json;

    public class ServicioGemini : IServicioGemini
    {
        private HttpClient _httpClient;
        private string _apiKey;

        public ServicioGemini(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["Gemini:ApiKey"];
        }

        public async Task<DTOResultadoAltaObservacion> EvaluarObservacion(
            Prestamo prestamo,
            ObjetoCeleste objeto)
        {
            // ---------------------------
            // 1. PROMPT
            // ---------------------------
            string prompt = $@"Analiza la siguiente configuración astronómica:
                            PRESTAMO:
                            - Telescopio ID: {prestamo.TelescopioId}
                            - Montura ID: {prestamo.MonturaId}
                            - Cámara ID: {prestamo.CamaraId}
                            - Ocular ID: {prestamo.OcularId}

                            OBJETO CELESTE:
                            - Nombre: {objeto.nombre}
                            - Tipo: {objeto.tipo}

                            Devuelve SOLO JSON con este formato:
                            {{
                              ""resultado"": ""IDEAL | ADECUADO | NO_RECOMENDABLE"",
                              ""explicacionIA"": ""máximo 300 caracteres""
                            }}
                            ";

            // ---------------------------
            // 2. REQUEST GEMINI
            // ---------------------------
            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new { text = prompt }
                    }
                }
            }
            };

            string jsonRequest = JsonSerializer.Serialize(requestBody);

            var response = await _httpClient.PostAsync(
                $"https://generativelanguage.googleapis.com/v1/models/gemini-2.0-flash:generateContent?key={_apiKey}",
                new StringContent(jsonRequest, Encoding.UTF8, "application/json")
            );


            //string contenido = await response.Content.ReadAsStringAsync();

            //if (!response.IsSuccessStatusCode)
            //{
            //    throw new Exception(contenido);
            //}

            response.EnsureSuccessStatusCode();

            // ---------------------------
            // 3. LEER RESPUESTA
            // ---------------------------
            string responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
            // ---------------------------
            // 4. DESERIALIZAR WRAPPER GEMINI
            // ---------------------------
            GeminiResponse geminiResponse =
                JsonSerializer.Deserialize<GeminiResponse>(responseBody);

            if (geminiResponse == null ||
                geminiResponse.candidates == null ||
                geminiResponse.candidates.Count == 0)
            {
                throw new Exception("Respuesta inválida de Gemini");
            }

            // ---------------------------
            // 5. EXTRAER JSON INTERNO
            // ---------------------------
            string jsonInterno = geminiResponse
                .candidates[0]
                .content
                .parts[0]
                .text;

            // ---------------------------
            // 6. LIMPIEZA (markdown possible)
            // ---------------------------
            jsonInterno = jsonInterno
                .Replace("```json", "")
                .Replace("```", "")
                .Trim();

            // ---------------------------
            // 7. PARSE FINAL A DTO
            // ---------------------------
            DTOResultadoAltaObservacion resultado = JsonSerializer.Deserialize<DTOResultadoAltaObservacion>(jsonInterno);

            if (resultado == null)
                throw new Exception("No se pudo parsear la respuesta de Gemini");

            // ---------------------------
            // 8. RETURN FINAL
            // ---------------------------
            return resultado;
        }
    }
}
