using System.Diagnostics;
using APIProjeto.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIProjeto.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var cliente = _httpClientFactory.CreateClient();
            var response = await cliente.GetFromJsonAsync<List<Postagem>>("https://jsonplaceholder.typicode.com/posts?_limit=6");
            return View(response);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
