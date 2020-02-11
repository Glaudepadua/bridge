using bridge.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace bridge.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var apiUrl = "https://api.github.com/repositories";
            var data = await GetAsync(apiUrl);
            return View(JsonConvert.DeserializeObject<List<Repositorio>>(data));
        }

        public async Task<ActionResult> Detalhes(string usuario, string repositorio)
        {
            var apiUrl = $"https://api.github.com/repos/{usuario}/{repositorio}";
            var data = await GetAsync(apiUrl);
            var detalhes = JsonConvert.DeserializeObject<Detalhes>(data);

            apiUrl = $"https://api.github.com/users/{usuario}/repos";
            data = await GetAsync(apiUrl);
            var repositoriosRelacionados = JsonConvert.DeserializeObject<List<Repositorio>>(data) ?? new List<Repositorio>();
            detalhes.RepositoriosRelacionados = repositoriosRelacionados;

            return View(detalhes);
        }

        public ActionResult Favoritos()
        {
            return View();
        }

        private static async Task<string> GetAsync(string apiUrl)
        {
            var data = string.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("request");//Set the User Agent to "request"

                var response = client.GetAsync(apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    data = await response.Content.ReadAsStringAsync();
                }
            }

            return data;
        }
    }
}