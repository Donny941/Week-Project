// Controllers/HomeController.cs
using Microsoft.AspNetCore.Mvc;
using Polizia_Municipale.Services;

namespace Polizia_Municipale.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }


        public async Task<IActionResult> Index()
        {
            try
            {
                var dashboard = await _homeService.GetDashboardDataAsync();
                return View(dashboard);
            }
            catch (Exception ex)
            {


                TempData["ErrorMessage"] = "Errore nel caricamento della dashboard. Riprova più tardi.";
                return View();
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}