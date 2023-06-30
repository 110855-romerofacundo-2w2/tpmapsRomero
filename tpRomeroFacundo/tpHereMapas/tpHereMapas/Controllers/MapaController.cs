using APITpHereMap.Resultados.Usuarios;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;
using tpHereMapas.Models;

namespace APIConsumingExample.Controllers
{
    [Route("apiMaps/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(marcadorModel marcador)
        {
            try
            {
                string nombreUsuario = "marcador";
                string password = "password";

                
                string apiUrl = "https://prog3.nhorenstein.com/api/usuario/LoginUsuarioWeb";
                var payload = new
                {
                    nombreUsuario,
                    password
                };

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, payload);

                   
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadFromJsonAsync<UsuarioResultado>(); 
                        string token = data.Token;

                        
                        string marcadoresApiUrl = "https://prog3.nhorenstein.com/api/marcador/GetMarcadores";
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        HttpResponseMessage marcadoresResponse = await client.GetAsync(marcadoresApiUrl);

                        
                        if (marcadoresResponse.IsSuccessStatusCode)
                        {
                            var responseJson = await marcadoresResponse.Content.ReadAsStringAsync();
                            var responseObject = JsonSerializer.Deserialize<JsonElement>(responseJson);

                           

                            var result = new Marcadores();
                            var listadoMarcadores = new List<MarcadorResultado>();

                            if (responseObject.TryGetProperty("litadoMarcadores", out JsonElement listadoMarcadoresElement))
                            {
                                foreach (var itemMarcador in listadoMarcadoresElement.EnumerateArray())

                                {
                                    var marcadore = new MarcadorResultado
                                    {
                                        Latitud = itemMarcador.GetProperty("latitud").GetString(),
                                        Longitud = itemMarcador.GetProperty("longitud").GetString(),
                                        Info = itemMarcador.GetProperty("info").GetString()
                                    };

                                    listadoMarcadores.Add(marcadore);
                                }
                            }
                            var marcadores = new Marcadores
                            {
                                ListadoMarcadores = listadoMarcadores
                            };
                            return Ok(marcadores);
                        }
                        else
                        {
                            return BadRequest("Error al realizar la solicitud a la otra API");
                        }
                    }
                    else
                    {
                        return BadRequest("Error al realizar la solicitud a la API de terceros");
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}