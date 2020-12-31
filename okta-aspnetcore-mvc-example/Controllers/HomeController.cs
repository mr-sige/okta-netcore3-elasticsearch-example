using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using okta_aspnetcore_mvc_example.Models;

namespace okta_aspnetcore_mvc_example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISearchClient searchClient;

        public HomeController(ISearchClient searchClient)
        {
            this.searchClient = searchClient;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        [HttpPost]
        public IActionResult Index(string searchText)
        {
            var response = searchClient.SearchOrder(searchText);
            var model = new SearchResultsModel {Results = response.Documents.ToList()};
            return View(model);
        }  
        
        public IActionResult Privacy()
        {
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            return View(HttpContext.User.Claims);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}