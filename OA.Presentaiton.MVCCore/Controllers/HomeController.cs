using Microsoft.AspNetCore.Mvc;
using OA.Application.Contracts.User;
using OA.Presentaiton.MVCCore.Models;
using System.Diagnostics;

namespace OA.Presentaiton.MVCCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserApplication _userApplication;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUserApplication userApplication)
        {
            _logger = logger;
            _userApplication = userApplication;
        }

        public IActionResult Index()
        {
            var users = _userApplication.GetAll();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
