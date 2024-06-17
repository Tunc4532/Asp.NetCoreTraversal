using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TravesalCore_Proje.Areas.Admin.Models;

namespace TravesalCore_Proje.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class Api2TopMovieController : Controller
    {
        public async Task <ActionResult> Index()
        {
            List<ApiMovieViewModel> apiMoviet = new List<ApiMovieViewModel>();

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
            {
          { "X-RapidAPI-Key", "5ea89e0241mshb044f3efcc81911p1d851fjsn37fa5d9887e8" },
          { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
              },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                apiMoviet = JsonConvert.DeserializeObject<List<ApiMovieViewModel>>(body);
                return View(apiMoviet);
            }
        }
    }
}
