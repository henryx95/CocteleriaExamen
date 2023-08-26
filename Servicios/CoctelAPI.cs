using Newtonsoft.Json;
using CoctelesExamen.Models;
using System.Net.Http.Headers;
using System.Text;

namespace CoctelesExamen.Servicios
{

    public class CoctelAPI : ICoctelAPI
    {
        private static string _baseUrl;
        public CoctelAPI()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSettings:baseUrl").Value;
        }



        public async Task<List<Coctel>> ListaPorCoctel(string coctel)
        {
            List<Coctel> lista = new List<Coctel>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"api/json/v1/1/search.php?s={coctel}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaApi>(responseBody);
                lista.AddRange(respuesta.drinks); // Agregar los cócteles individuales a la lista
            }
            return lista;
        }

        public async Task<List<Coctel>> ListaPorIngrediente(string ingrediente)
        {
            List<Coctel> lista = new List<Coctel>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"api/json/v1/1/filter.php?i={ingrediente}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaApi>(responseBody);
                lista.AddRange(respuesta.drinks); // Agregar los cócteles individuales a la lista
            }
            return lista;
        }


        public async Task<List<Coctel>> ListaPorId(string id)
        {
            List<Coctel> lista = new List<Coctel>();
            var cliente = new HttpClient();
            cliente.BaseAddress = new Uri(_baseUrl);
            var response = await cliente.GetAsync($"api/json/v1/1/lookup.php?i={id}");
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var respuesta = JsonConvert.DeserializeObject<RespuestaApi>(responseBody);
                lista.AddRange(respuesta.drinks); // Agregar los cócteles individuales a la lista
            }
            return lista;
        }
    }
}
