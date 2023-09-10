using ConsumoApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumoApi.Controllers
{
    public class HomeroController : Controller
    {
        private readonly HttpClient httpClient;

        public HomeroController()
        {
            httpClient = new HttpClient();
        }

        public async Task<IActionResult> Index()
        {
            var apiUrl = "https://apisimpsons.fly.dev/api/personajes?limit=20&page=3";
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var homero = JsonConvert.DeserializeObject<ApiResponse<Homero>>(content);
                return View(homero.Docs);
            }

            return View(new List<Homero>());
        }

        public class ApiResponse<T>
        {
           
            public List<T> Docs { get; set; }
        }
    }

}
